using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api_OsteoHealth_Tesis.Repository
{
    /// <summary>
    /// Interface para la clase LoginBL
    /// </summary>
    public interface ILoginBL
    {
        Task<string> GenerateJwtToken(string userId, string role);
        Task<(bool isValid, string userId, string role)> ValidateUserAsync(string username, string password);
    }
}
