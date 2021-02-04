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
        int SavePepperOrShop(int id, string name, int pepperOrShop);
        PepperModel GetPepperOrShopDomainModel(int id, int pepperOrShop);
        int UpdatePepperOrShop(int id, int pepperOrShop, string newName);
        int DeletePepperOrShop(int id, int pepperOrShop);
    }
}
