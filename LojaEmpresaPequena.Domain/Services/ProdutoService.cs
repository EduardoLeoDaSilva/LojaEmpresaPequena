﻿using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.HttpClients.DropBox;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LojaEmpresaPequena.Domain.HttpClients.DropBox;

namespace LojaEmpresaPequena.Domain.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository _repository) : base(_repository)
        {

        }

        public string SaveImagem(IFormFile file,string pasta)
        {
            var imagemHandler = new ImageHandler();
            return imagemHandler.SaveImage(file, pasta);
        }

        public async Task<DropbBoxResponseSave> SendImageToDropBox(IFormFile file, string pasta)
        {
            var sender = new DroboxIntegrationService(); 
            return await sender.SendImage(file, pasta);
        }

        public async Task<DropBoxResponseSharedAndTemporaryLink> GetTemporaryLink(string path)
        {
            var sender = new DroboxIntegrationService();
            return await sender.GetTemporaryLink(path);
        }

        public async Task<DropBoxResponseSharedAndTemporaryLink> GetSharedLink(string path)
        {
            var sender = new DroboxIntegrationService();
            return await sender.GetSharedLink(path);
        }

    }
}
