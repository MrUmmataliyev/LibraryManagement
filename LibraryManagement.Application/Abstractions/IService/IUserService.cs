using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Abstractions.IService
{
    public interface IUserService
    {
        public Task<string> CreateUser(UserDTO userDTO);
        public Task<string> UpdateUser(int id, UserDTO userDTO);
        public Task<string> DeleteUser(int id);
        public Task<List<UserViewModel>> GetAll();
        public Task<List<UserViewModel>> GetByRole(string role);
        public Task<List<UserViewModel>> GetByName(string fullName);
        public Task<UserViewModel> GetById(int id);
        public Task<UserViewModel> GetByEmail(string email);
        Task<string> GetPdfPath();


    }
}
