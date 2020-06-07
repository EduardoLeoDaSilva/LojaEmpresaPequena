using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.HttpClients.DropBox;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface IProdutoService : IBaseService<Produto>
    {
        string SaveImagem(IFormFile file, string pasta);
        Task<DropbBoxResponseSave> SendImageToDropBox(IFormFile file, string pasta);
        Task<DropBoxResponseSharedAndTemporaryLink> GetTemporaryLink(string path);
        Task<DropBoxResponseSharedAndTemporaryLink> GetSharedLink(string path);
    }
}
