using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ILabService
    {
        Task<List<Lab>> GetAll(int page, int pageSize, string? searchTerm);
        Task<string> UploadImage(IFormFile file);
        Task<Lab> GetById(int id);

        Task Add(Lab lab);

        Task Update(int id, Lab lab);

        Task Delete(int id);
    }
}
