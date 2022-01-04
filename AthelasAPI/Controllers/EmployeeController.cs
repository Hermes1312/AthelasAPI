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
    [Route("/employee/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService mEmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            mEmployeeService = employeeService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] EmployeeAddDto addDto)
        {
            var newDto = mEmployeeService.Add(addDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get([FromRoute] int id)
        {
            var dto = mEmployeeService.GetById(id);
            return Ok(dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> Get()
        {
            var dtos = mEmployeeService.GetAll();
            return Ok(dtos);
        }

        [HttpGet("{id}/appoinments")]
        public ActionResult<IEnumerable<AppointmentDto>> GetAppointments([FromRoute] int id)
        {
            var dtos = mEmployeeService.GetAppointments(id);
            return Ok(dtos);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] EmployeeUpdateDto updateModel, [FromRoute] int id)
        {
            mEmployeeService.Update(id, updateModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            mEmployeeService.Delete(id);
            return Ok();
        }
    }
}
