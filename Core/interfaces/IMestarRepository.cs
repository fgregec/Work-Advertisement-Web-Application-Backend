using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface IMestarRepository
    {
        Task<IEnumerable<Mestar>> GetMestarByName(string input_value);
        Task<IEnumerable<Mestar>> GetMestarListByCategories(string[] categories);
    }
}
