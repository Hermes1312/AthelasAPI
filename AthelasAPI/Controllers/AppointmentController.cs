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
    [Route("/appointment/")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public readonly IAppointmentService mAppointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            mAppointmentService = appointmentService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] AppointmentAddAndUpdateDto addDto)
        {
            mAppointmentService.Add(addDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<AppointmentDto> GetById([FromRoute] int id)
        {
            return Ok(mAppointmentService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppointmentDto>> GetAll()
        {
            return Ok(mAppointmentService.GetAll());
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] AppointmentAddAndUpdateDto updateModel)
        {
            mAppointmentService.Update(id, updateModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            mAppointmentService.Delete(id);
            return Ok();
        }
    }
}
