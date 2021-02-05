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
        string SavePepperOrShop(PepperModel model, int pepperOrShop);
        Task<List<PepperModel>> GetPepperOrShopDomainModelAsync(int pepperOrShop);
        int UpdatePepperOrShop(PepperModel model, int pepperOrShop);
        int DeletePepperOrShop(int id, int pepperOrShop);
    }
}
