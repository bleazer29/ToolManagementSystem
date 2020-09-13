using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Counterparties")]
    [ApiController]
    public class CounterpartiesController : ControllerBase
    {
        private readonly TMSdbContext db;

        public CounterpartiesController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Counterparties
        [HttpGet]
        public async Task<IActionResult> GetCounterparties(string name, string edrpou, string address)
        {
            try
            {
                List<Counterparty> counterparties = new List<Counterparty>();
                counterparties = await db.Counterparty.ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    counterparties = counterparties.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                }
                if (string.IsNullOrEmpty(edrpou) == false)
                {
                    counterparties = counterparties.Where(x => x.Edrpou.ToLower().Contains(edrpou.ToLower())).ToList();
                }
                if (string.IsNullOrEmpty(address) == false)
                {
                    counterparties = counterparties.Where(x => x.Address.ToLower().Contains(address.ToLower())).ToList();
                }
                return Ok(counterparties);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/NRI/Counterparties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCounterparty(int id)
        {
            try
            {
                Counterparty counterparty = await db.Counterparty.SingleAsync(x => x.CounterpartyId == id);
                return Ok(counterparty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/NRI/Counterparties
        [HttpPost]
        public async Task<IActionResult> AddCounterparty([FromBody] Counterparty value)
        {
            try
            {
                await db.Counterparty.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/NRI/Counterparties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCounterparty(int id, [FromBody] Counterparty value)
        {
            try
            {
                Counterparty counterparty = await db.Counterparty.SingleAsync(x => x.CounterpartyId == id);
                if(counterparty != null)
                {
                    counterparty.Name = value.Name;
                    counterparty.Address = value.Address;
                    counterparty.Edrpou = value.Edrpou;
                }
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/NRI/Counterparties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounterparty(int id)
        {
            try
            {
                Counterparty counterparty = await db.Counterparty.SingleAsync(x => x.CounterpartyId == id);
                db.Counterparty.Remove(counterparty);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
