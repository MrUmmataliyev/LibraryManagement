using LibraryManagement.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Abstractions.IService
{
    public interface IAuthSevice
    {
        public Task<ResponseLogin> GenerateToken(RequestLogin request);
    }
}
