using LojaEmpresaPequena.Domain.HttpClients.DropBox;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Integrations
{
    public interface IDroboxIntegrationService
    {
        Task<string> DeleteForlderOrArq(string pasta);
        Task<string> Download(string pathArquivo);
        Task<DropBoxResponseSharedAndTemporaryLink> GetSharedLink(string pathArquivo);
        Task<DropBoxResponseSharedAndTemporaryLink> GetTemporaryLink(string pathArquivo);
        Task<string> GetThumbNail(string pathArquivo);
        Task<DropbBoxResponseSave> SendImage(IFormFile image, string pasta);
    }
}