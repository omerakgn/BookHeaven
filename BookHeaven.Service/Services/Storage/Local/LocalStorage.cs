using BookHeaven.Core.DTOs;
using BookHeaven.Core.Services.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Service.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task DeleteAsync(string path, string fileName)
            => File.Delete($"{path}/{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}/{fileName}");
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
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(path, file.Name, HasFile);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
           
            }

            return datas;
        }

        public Task<Core.Models.File> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Core.Models.File> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Core.Models.File> Where(Expression<Func<Core.Models.File, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Core.Models.File, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Models.File> AddAsync(Core.Models.File Entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Core.Models.File>> AddRangeAsync(IEnumerable<Core.Models.File> entities)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<Core.Models.File>> RemoveAsync(Core.Models.File entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Core.Models.File> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Core.Models.File entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Models.File entity)
        {
            throw new NotImplementedException();
        }
    }
}
