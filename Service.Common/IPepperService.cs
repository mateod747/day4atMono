using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service.Common
{
    public interface IPepperService
    {
        Task<string> SavePepperAsync(PepperModel model);
        Task<List<PepperModel>> GetAllPeppersAsync();
        Task<int> UpdatePepperAsync(PepperModel model);
        Task<int> DeletePepperAsync(int id);
    }
}
