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
        string SavePepperOrShop(PepperModel model, int pepperOrShop);
        PepperModel ShowPepperOrShop(int id, int pepperOrShop);
        int UpdatePepperOrShop(PepperModel model, int pepperOrShop);
        int DeletePepperOrShop(int id, int pepperOrShop);
    }
}
