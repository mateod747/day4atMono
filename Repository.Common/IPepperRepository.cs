using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository.Common
{
    public interface IPepperRepository
    {
        int SavePepperOrShop(int id, string name, int pepperOrShop);
        PepperModel ShowPepperOrShop(int id, int pepperOrShop);
        int UpdatePepperOrShop(int id, int pepperOrShop, string newName);
        int DeletePepperOrShop(int id, int pepperOrShop);
    }
}
