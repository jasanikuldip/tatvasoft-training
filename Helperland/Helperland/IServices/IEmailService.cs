using Helperland.Models;
using System.Threading.Tasks;

namespace Helperland.IServices
{
    public interface IEmailService
    {
        Task SendEmail(UserEmailOptions userEmailOptions);
    }
}
