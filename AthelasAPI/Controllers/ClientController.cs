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
    [Route("/client/")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public readonly IClientService mClientService;

        public ClientController(IClientService clientService)
        {
            mClientService = clientService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] ClientAddDto addDto)
        {
            var clientNew = mClientService.Add(addDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<ClientDto> Get([FromRoute] int id)
        {
            var client = mClientService.GetById(id);
            return Ok(client);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> Get()
        {
            var clients = mClientService.GetAll();
            
            return Ok(clients);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ClientUpdateDto updateModel, [FromRoute] int id)
        {
            mClientService.Update(id, updateModel);
            return Ok();
        }

        [HttpPut("{id}/notes")]
        public ActionResult UpdateNotes([FromRoute] int id, [FromBody] string notes)
        {
            mClientService.UpdateNotes(id, notes);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            mClientService.Delete(id);
            return Ok();
        }
    }
}
