using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.Core.DTO;

namespace Titan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ProvinciaController : ControllerBase
    {
        public IProvinciaBL provinciaBL { get; set; }
        public ProvinciaController(IProvinciaBL provinciaBL)
        {
            this.provinciaBL = provinciaBL;
        }

        [HttpGet]
        public ActionResult<ProvinciaDTO> Get(int id)
        {
            return Ok(provinciaBL.Get(id));
        }

        [HttpGet]
        [Route("All")]
        public ActionResult<List<ProvinciaDTO>> GetAll()
        {
            return Ok(provinciaBL.GetAll());
        }

        [Authorize]
        [HttpPost]
        [Route("Filter")]
        public ActionResult<List<ProvinciaDTO>> Filter(ProvinciaCriteriaDTO criteriaDTO)
        {
            return Ok(provinciaBL.Filter(criteriaDTO));
        }
    }
}
