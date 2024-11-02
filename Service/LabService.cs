using BusinessObject.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Reposiory.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LabService : ILabService
    {
        private readonly ILabRepository _repository;
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;
        public LabService(ILabRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
            var acc = new Account
            {
                Cloud = _configuration.GetSection("CloudinarySetting:CloudName").Value,
                ApiKey = _configuration.GetSection("CloudinarySetting:ApiKey").Value,
                ApiSecret = _configuration.GetSection("CloudinarySetting:ApiSecret").Value
            };

            _cloudinary = new Cloudinary(acc);
        }

        public async Task Add(Lab lab)
        {
            await _repository.Add(lab);
        }

        public async Task Delete(int id)
        {
            await _repository.Remove(id);
        }

        public async Task<List<Lab>> GetAll(int page, int pageSize, string? searchTerm)
        {
            return await _repository.GetAll(page, pageSize, searchTerm);
        }

        public async Task<Lab> GetById(int id)
        {
            return await _repository.GetById(id); 
        }

        public async Task Update(int id,Lab lab)
        {
            lab.Id = id;
            await _repository.UpdateAsync(lab);
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(200).Width(200)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);

            }
            return uploadResult.SecureUrl.ToString();
        }
    }
}
