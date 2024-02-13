using BarinakAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage :Storage, IILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task DeleteAsync(string path, string fileName)
        =>  File.Delete($"{path}\\{fileName}");
        
        
        

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        => File.Exists($"{path}\\{fileName}");


         async Task<bool> CopyFileAsync(string path, IFormFile file)
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
                //todo log! 
                throw ex;

            }



        }

        public async Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {

            string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(UploadPath))
                Directory.CreateDirectory(UploadPath);
             
            List<(string fileName, string path)> datas = new();
             foreach (IFormFile file in files)
            {
                string fileNewName = await FileRemoveAsync(path, file.Name, HasFile);


                await CopyFileAsync($"{UploadPath}\\{fileNewName}", file);

                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
                 

            }
             
            return datas;
        }
    }
}
