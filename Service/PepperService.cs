using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Common;
using Repository.Common;
using Repository;
using Model;

namespace Service
{
    public class PepperService: IPepperService
    {
        protected IPepperRepository Repository { get; set; }

        public PepperService(IPepperRepository pepperRepository)
        {
            Repository = pepperRepository;
        }

        public async Task<string> SavePepperAsync(PepperModel model)
        {
            return await Repository.SavePepperAsync(model);
        }

        public async Task<List<PepperModel>> GetAllPeppersAsync()
        {
            return await Repository.GetAllPeppersAsync();
        }

        public async Task<int> UpdatePepperAsync(PepperModel model)
        {
            return await Repository.UpdatePepperAsync(model);
        }

        public async Task<int> DeletePepperAsync(int id)
        {
            return await Repository.DeletePepperAsync(id);
        }
    }
}
