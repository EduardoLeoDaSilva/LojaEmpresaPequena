using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LojaEmpresaPequena.Domain.Utils
{
    public class ImageHandler
    {
        public string SaveImage(IFormFile file, string pasta)
        {
            var photoName = file.FileName;
            var path = $"{Directory.GetCurrentDirectory()}\\fotos\\{pasta}";

            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);


            using (var stream = file.OpenReadStream())
            using (var fileStream = new FileStream(Path.Combine(path, photoName), FileMode.Create))
            {
                stream.CopyTo(fileStream);
            }

            return Path.Combine(path, photoName);
        }


        public byte[] GetBytesFromImage(IFormFile file)
        {
            var photoName = file.FileName;
            byte[] imagem;
            using (var stream = file.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                imagem = ms.ToArray();
            }

            return imagem;
        }


        public byte[] GetImage(string fileName,string pasta)
        {
            var pathFolder = $"{Directory.GetCurrentDirectory()}\\fotos\\{pasta}";
            var fullPath = Path.Combine(pathFolder, fileName);
            byte[] imagemBytes;
            using (var fs = new FileStream(fullPath, FileMode.Open))
            using (var ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                imagemBytes = ms.ToArray();
            }

            return imagemBytes;
        }


    }
}
