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

        public string SavePepperOrShop(PepperModel model, int pepperOrShop)
        {
            return Repository.SavePepperOrShop(model, pepperOrShop);
        }

        public PepperModel GetPepperOrShopDomainModel(int id, int pepperOrShop)
        {
            return Repository.ShowPepperOrShop(id, pepperOrShop);
        }

        public int UpdatePepperOrShop(PepperModel model, int pepperOrShop)
        {
            return Repository.UpdatePepperOrShop(model, pepperOrShop);
        }

        public int DeletePepperOrShop(int id, int pepperOrShop)
        {
            return Repository.DeletePepperOrShop(id, pepperOrShop);
        }
    }
}
