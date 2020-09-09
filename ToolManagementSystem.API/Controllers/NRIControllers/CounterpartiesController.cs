using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.Shared.RequestModels.NRI;

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
        public async Task<List<Counterparty>> GetCounterparties([FromBody] CounterpartyFilterRequest request)
        {
            List<Counterparty> counterparties = new List<Counterparty>();
            counterparties = await db.Counterparty.ToListAsync();
            if (string.IsNullOrEmpty(request.Name) == false)
            {
                counterparties = counterparties.Where(x => x.Name == request.Name).ToList();
            }
            if (string.IsNullOrEmpty(request.EDRPOU) == false)
            {
                counterparties = counterparties.Where(x => x.Edrpou == request.EDRPOU).ToList();
            }
            return counterparties;
        }

        // GET api/NRI/Counterparties/5
        [HttpGet("{id}")]
        public async Task<Counterparty> GetCounterparty(int id)
        {
            try
            {
                Counterparty counterparty = await db.Counterparty.SingleAsync(x => x.CounterpartyId == id);
                return counterparty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Counterparty() { CounterpartyId = -1 };
            }
        }

        // POST api/NRI/Counterparties
        [HttpPost]
        public async Task AddCounterparty([FromBody] Counterparty value)
        {
            try
            {
                await db.Counterparty.AddAsync(value);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Counterparties/5
        [HttpPut("{id}")]
        public async Task EditCounterparty(int id, [FromBody] Counterparty value)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Counterparties/5
        [HttpDelete("{id}")]
        public async Task DeleteCounterparty(int id)
        {
            try
            {
                Counterparty counterparty = await db.Counterparty.SingleAsync(x => x.CounterpartyId == id);
                db.Counterparty.Remove(counterparty);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
