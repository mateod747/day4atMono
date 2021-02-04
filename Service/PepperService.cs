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
        public PepperService()
        {
            Repository = new PepperRepository();
        }

        public int SavePepperOrShop(int id, string name, int pepperOrShop)
        {
            return Repository.SavePepperOrShop(id, name, pepperOrShop);
        }

        public PepperModel GetPepperOrShopDomainModel(int id, int pepperOrShop)
        {
            return Repository.ShowPepperOrShop(id, pepperOrShop);
        }

        public int UpdatePepperOrShop(int id, int pepperOrShop, string newName)
        {
            return Repository.UpdatePepperOrShop(id, pepperOrShop, newName);
        }

        public int DeletePepperOrShop(int id, int pepperOrShop)
        {
            return Repository.DeletePepperOrShop(id, pepperOrShop);
        }
    }
}
