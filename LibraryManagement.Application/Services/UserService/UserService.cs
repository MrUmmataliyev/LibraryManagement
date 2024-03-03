using LibraryManagement.Application.Abstractions;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string> CreateUser(UserDTO userDTO)
        {
            var res = await _userRepo.GetAll();
            var email = res.Any(x => x.Email == userDTO.Email);
            var login = res.Any(x => x.Login == userDTO.Email);
            if (!email)
            {
                if(!login)
                {
                    var newUser = new User()
                    {
                        FullName = userDTO.FullName,
                        
                        Login = userDTO.Login,
                        Password = userDTO.Password,
                        Email = userDTO.Email,
                        Role = userDTO.Role

                    };
                    await _userRepo.Create(newUser);
                    return "Created";

                }
                return "Such login already exists";
            }
            return "Such email already exists";
        }

        public async Task<string> DeleteUser(int id)
        {
            var result = await _userRepo.Delete(x=> x.UserId == id);
            if (result)
            {
                return "Deleted";
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var get = await _userRepo.GetAll();

           var result= get.Select(x => new UserViewModel
            {
                UserId = x.UserId,
                FullName = x.FullName,
                Email = x.Email,
                Role = x.Role
            }).ToList();
            return result;
           
        }

        public async Task<UserViewModel> GetByEmail(string email)
        {
            var get = await _userRepo.GetByAny(x=>x.Email==email);

            var result = new UserViewModel()
            {
                UserId=get.UserId,
                FullName = get.FullName,
                Email = get.Email,
                Role = get.Role

            };

            return result;
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var get = await _userRepo.GetByAny(x => x.UserId == id);

            var result = new UserViewModel()
            {
                UserId = get.UserId,
                FullName = get.FullName,
                Email = get.Email,
                Role = get.Role

            };

            return result;
        }

        public async Task<List<UserViewModel>> GetByName(string fullName)
        {
            var get = await _userRepo.GetAll();
            var find =  get.Where(x=>x.FullName==fullName);

            var result = find.Select(x => new UserViewModel
            {
                UserId = x.UserId,
                FullName = x.FullName,
                Email = x.Email,
                Role = x.Role
            }).ToList();
            return result;
        }

        public async Task<List<UserViewModel>> GetByRole(string role)
        {
            var get = await _userRepo.GetAll();
            var find = get.Where(x => x.Role == role);

            var result = find.Select(x => new UserViewModel
            {
                UserId = x.UserId,
                FullName = x.FullName,
                Email = x.Email,
                Role = x.Role
            }).ToList();
            return result;
        }

        public async Task<string> UpdateUser(int id, UserDTO userDTO)
        {
            var res = await _userRepo.GetAll();
            var email = res.Any(x => x.Email == userDTO.Email);
            var login = res.Any(x => x.Login == userDTO.Email);
            if (!email)
            {
                if (!login)
                {
                    var old = await _userRepo.GetByAny(x=> x.UserId == id);

                    if (old == null) return "Failed";
                    old.FullName = userDTO.FullName;

                    old.Login = userDTO.Login;
                    old.Password = userDTO.Password;
                    old.Email = userDTO.Email;
                    old.Role = userDTO.Role;

                    
                    await _userRepo.Update(old);
                    return "Updated";

                }
                return "Such login already exists";
            }
            return "Such email already exists";
        }
    }

}
