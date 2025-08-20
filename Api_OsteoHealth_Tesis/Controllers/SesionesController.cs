// Controllers/SesionesController.cs
using Api_OsteoHealth_Tesis.Models;                    // OsteoHealthContext, SesionDraft
using Api_OsteoHealth_Tesis.ModelsCustom.Sesiones;     // DraftPayloadDto, SessionFormDto
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static Api_OsteoHealth_Tesis.Utils.Utils; // SafeDeserialize

namespace Api_OsteoHealth_Tesis.Controllers
{
    /// <summary>
    /// Endpoints de sesiones (autosave + submit). 
    /// Por ahora el submit es stub y el autosave persiste en sesion_drafts.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/{version:ApiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class SesionesController : ControllerBase
    {
        private readonly OsteoHealthContext _db;
        public SesionesController(OsteoHealthContext db) => _db = db;

        /// <summary>
        /// Submit final del formulario de sesión. 
        /// Devuelve un id para compatibilidad; luego podemos persistir (sesiones_raw o modelo tipado).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SessionFormDto dto)
        {
            if (dto == null) return BadRequest("Body requerido");
            if (string.IsNullOrWhiteSpace(dto.fecha)) return BadRequest("fecha requerida");

            var id = Guid.NewGuid();
            var json = System.Text.Json.JsonSerializer.Serialize(dto);

            _db.SesionesRaw.Add(new SesionRaw
            {
                id = id,
                createdat = DateTimeOffset.UtcNow, // <-- importante, Offset
                payloadjson = ParseJsonOrEmpty(json),
                pacienteid = dto.pacienteid,
                fecha = dto.fecha,
                profesionalid = dto.profesionalid
            });

            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPost("get-or-create")]
        public async Task<IActionResult> GetOrCreate([FromBody] SessionFormDto dto)
        {
            if (dto is null || string.IsNullOrWhiteSpace(dto.fecha))
                return BadRequest("fecha requerida");

            var existente = await _db.SesionesRaw
                .Where(s => s.pacienteid == dto.pacienteid && s.fecha == dto.fecha)
                .OrderByDescending(s => s.createdat)
                .Select(s => new { s.id })
                .FirstOrDefaultAsync();

            if (existente is not null) return Ok(new { id = existente.id });

            var id = Guid.NewGuid();
            var json = System.Text.Json.JsonSerializer.Serialize(dto);

            _db.SesionesRaw.Add(new SesionRaw
            {
                id = id,
                createdat = DateTimeOffset.UtcNow,
                payloadjson = ParseJsonOrEmpty(json),
                pacienteid = dto.pacienteid,
                fecha = dto.fecha,
                profesionalid = dto.profesionalid
            });

            await _db.SaveChangesAsync();
            return Ok(new { id });
        }



        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string? pacienteId, [FromQuery] string? fecha)
        {
            var q = _db.SesionesRaw.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pacienteId)) q = q.Where(x => x.pacienteid == pacienteId);
            if (!string.IsNullOrWhiteSpace(fecha)) q = q.Where(x => x.fecha == fecha);

            var items = await q
                .OrderByDescending(x => x.createdat)
                .Select(x => new { x.id, x.createdat, x.pacienteid, x.fecha })
                .ToListAsync();

            return Ok(items);
        }


        /// <summary>
        /// Placeholder para CreatedAtAction. Luego puede devolver la sesión persistida.
        /// </summary>
        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(new { id });
        }

        /// <summary>
        /// Autosave por paso. Upsert en sesion_drafts {SesionId, Step}.
        /// </summary>
        [HttpPost("{id:guid}/draft")]
        public async Task<IActionResult> SaveDraft([FromRoute] Guid id, [FromBody] DraftPayloadDto dto)
        {
            if (dto == null) return BadRequest("Body requerido");
            if (dto.Step < 0) return BadRequest("Step inválido");

            var json = SafeSerialize(dto.Data);

            var draft = await _db.SesionDrafts
                .FirstOrDefaultAsync(x => x.SesionId == id && x.Step == dto.Step);

            if (draft == null)
            {
                draft = new SesionDraft
                {
                    id = Guid.NewGuid(),
                    SesionId = id,
                    Step = dto.Step,
                    DataJson = json, // ✅ nuevo
                    UpdatedAt = DateTimeOffset.UtcNow
                };
                _db.SesionDrafts.Add(draft);
            }
            else
            {
                draft.DataJson = json;             // ✅ te faltaba esto
                draft.UpdatedAt = DateTimeOffset.UtcNow;
                // No hace falta _db.SesionDrafts.Update(draft) si el contexto lo está trackeando
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }


        /// <summary>
        /// Devuelve todos los borradores guardados para una sesión (ordenados por step).
        /// </summary>
        [HttpGet("{id:guid}/drafts")]
        public async Task<IActionResult> GetDrafts([FromRoute] Guid id)
        {
            var items = await _db.SesionDrafts
                .Where(x => x.SesionId == id)        // ✅ SesionId (no pacienteid)
                .OrderBy(x => x.Step)
                .ToListAsync();

            var result = items.Select(x => new
            {
                x.Step,
                x.UpdatedAt,
                Data = SafeDeserialize(x.DataJson)   // ✅ deserializa cada payload
            });

            return Ok(result);
        }


        /// <summary>
        /// Devuelve el último borrador de cada step (útil para rehidratar el wizard).
        /// </summary>
        [HttpGet("{id:guid}/drafts/latest")]
        public async Task<IActionResult> GetDraftsLatest([FromRoute] Guid id)
        {
            var row = await _db.SesionDrafts
                .Where(d => d.SesionId == id)                 // ✅ SesionId
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new { d.Step, d.UpdatedAt, d.DataJson })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (row is null) return NotFound();

            return Ok(new
            {
                row.Step,
                row.UpdatedAt,
                Data = SafeDeserialize(row.DataJson)          // ✅ string -> object
            });
        }

        /// <summary>
        /// Deserializa JSON a object de forma segura (evita 500 si hay payloads viejos).
        /// </summary>
        private static object SafeDeserialize(string json)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<object>(json) ?? new { };
            }
            catch
            {
                // En caso de corrupción, devolvemos string crudo para no romper Swagger/consumidores
                return json;
            }
        }
    }
}
