using AthelasAPI.Models;
using AthelasAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI.Controllers
{
    [Route("/service/")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public readonly IServiceService mServiceService;

        public ServiceController(IServiceService serviceService)
        {
            mServiceService = serviceService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] ServiceAddAndUpdateDto addDto)
        {
            var newDto = mServiceService.Add(addDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceDto> Get([FromRoute] int id)
        {
            var dto = mServiceService.GetById(id);
            return Ok(dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceDto>> Get()
        {
            var dtos = mServiceService.GetAll();
            return Ok(dtos);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ServiceAddAndUpdateDto updateDto, [FromRoute] int id)
        {
            mServiceService.Update(id, updateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            mServiceService.Delete(id);
            return Ok();
        }
    }
}
