using Destek.Application.Abstractions.Storage.Local;
using Destek.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {

                //todo log:
                throw ex;
            }
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            File.Delete($"{pathOrContainerName}\\{fileName}");
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            DirectoryInfo directoryInfo = new(pathOrContainerName);
            return directoryInfo.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName);
            string fullPath = Path.Combine(uploadPath, $"{fileName}");
            return File.Exists(fullPath);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);


            List<(string fileName, string pathOrContainerName)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                //string fileNewName = await FileRenameAsync(uploadPath, file.FileName);
                string fileNewName = await FileRenameAsync(pathOrContainerName, file.FileName, HasFile);
                string fullPath = Path.Combine(uploadPath, $"{fileNewName}");
                bool result = await CopyFileAsync(fullPath, file);
                datas.Add((fileNewName, $"{pathOrContainerName}\\{fileNewName}"));
                results.Add(result);
            }

            if (results.TrueForAll(r => r.Equals(true)))
            {
                return datas;
            }

            //todo Eğer ki tüm dosyslar yüklenmediyse, alınan hatayı exception oluştur ve fırlat.
            return null;
        }

 

    }
}
