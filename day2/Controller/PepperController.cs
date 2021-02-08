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
using System.Threading.Tasks;

namespace day2.Controller
{
    public class PepperController : ApiController
    {
        protected IPepperService _service;

        public PepperController(IPepperService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> SavePepperAsync(PepperModel model)
        {
            string response = await _service.SavePepperAsync(model);
            
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
        public async Task<HttpResponseMessage> GetAllPeppersAsync()
        {
            List<PepperViewModel> viewModel = new List<PepperViewModel>();
                     
            List<PepperModel> response = await _service.GetAllPeppersAsync();
            
            foreach(PepperModel model in response)
            {
                viewModel.Add(new PepperViewModel() { Name = model.Name });
            }
                       
            if (viewModel != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, viewModel);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Unsuccessful!");
            }
        }

        [Route("update/{id}/{name}")]
        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePepperAsync(PepperModel model)
        {
            int response = await _service.UpdatePepperAsync(model);

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
        public async Task<HttpResponseMessage> DeletePepperAsync([FromUri]int id)
        {
            int response = await _service.DeletePepperAsync(id);

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
