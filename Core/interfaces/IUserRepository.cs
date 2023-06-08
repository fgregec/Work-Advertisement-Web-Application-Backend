using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<User>> Search(string input);
    }
}
