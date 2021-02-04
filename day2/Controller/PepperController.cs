using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Service.Common;
using Service;
using Model;
using ViewModel;

namespace day2.Controller
{
    public class PepperController : ApiController
    {
        protected IPepperService service = new PepperService();
                
        [HttpPost]
        public HttpResponseMessage SavePepperOrShop(PepperModel model, int pepperOrShop)
        {
            string response = service.SavePepperOrShop(model, pepperOrShop);
            
            if(response == "Ok")
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated database.");
            } else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }
                
        [Route("show/{id}")]
        [HttpGet]
        public HttpResponseMessage ShowPepperOrShop(int id, int pepperOrShop)
        {
            PepperModel response = service.GetPepperOrShopDomainModel(id, pepperOrShop);
            PepperViewModel viewModel = new PepperViewModel();
            viewModel.Name = response.Name;

            if (viewModel.Name != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, viewModel.Name);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Unsuccessful!");
            }
        }

        [Route("update/{id}/{name}")]
        [HttpPut]
        public HttpResponseMessage UpdatePepperOrShop(PepperModel model, int pepperOrShop)
        {
            int response = service.UpdatePepperOrShop(model, pepperOrShop);

            if (response == 200)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated database.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Unsuccessful!");
            }
        }

        [Route("delete/{id}/{option}")]
        [HttpDelete]
        public HttpResponseMessage DeletePepperOrShop([FromUri]int id, [FromUri]int pepperOrShop)
        {
            int response = service.DeletePepperOrShop(id, pepperOrShop);

            if (response == 200)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted record.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Unsuccessful!");
            }
        }
    }
}
