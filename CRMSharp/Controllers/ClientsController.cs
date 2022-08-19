using CRMSharp.Models;
using CRMSharp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRMSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public IAsyncEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var obj = await _clientRepository.GetById(id);
            if (obj is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            await _clientRepository.Create(client);
            return CreatedAtAction(nameof(GetByID), new { id=client.Id }, client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _clientRepository.TryRemove(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Client client)
        {
            if (id == client.Id)
            {
                await _clientRepository.Update(client);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
