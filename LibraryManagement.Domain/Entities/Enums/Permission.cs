using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities.Enums
{
    public enum Permission
    {
        CreateUser=1,
        GetAll=2,
        GetByUserId=3,
        GetByUserEmail=4,
        GetByRole=5,
        GetByUserFullName=6,
        UpdateUser=7,
        DeleteUser=8,
        AddBook=9,
        GetByBookId=10,
        GetSector=11,
        GetAllBook=12,
        GetByBookName=13,
        GetByCategory=14,
        GetByPublishedYear=15,
        GetBySector=16,
        GetByAuthor=17,
        UpdateBook=18,
        DeleteBook=19,
        GetUserPDF=20

    }
}
