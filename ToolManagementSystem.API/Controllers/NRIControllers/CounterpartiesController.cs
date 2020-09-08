using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<Counterparty> GetCounterparties(string name, string EDRPOU)
        {
            List<Counterparty> counterparties = new List<Counterparty>();
            counterparties = db.Counterparty.ToList();
            if (string.IsNullOrEmpty(name) == false)
            {
                counterparties = counterparties.Where(x => x.Name == name).ToList();
            }
            if (string.IsNullOrEmpty(EDRPOU) == false)
            {
                counterparties = counterparties.Where(x => x.Edrpou == EDRPOU).ToList();
            }
            return counterparties;
        }

        // GET api/NRI/Counterparties/5
        [HttpGet("{id}")]
        public Counterparty GetCounterparty(int id)
        {
            try
            {
                Counterparty counterparty = db.Counterparty.Single(x => x.CounterpartyId == id);
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
        public void AddCounterparty([FromBody] Counterparty value)
        {
            try
            {
                Counterparty counterparty = new Counterparty();
                counterparty = value;
                db.Counterparty.Add(counterparty);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Counterparties/5
        [HttpPut("{id}")]
        public void EditCounterparty(int id, [FromBody] Counterparty value)
        {
            try
            {
                Counterparty counterparty = db.Counterparty.Single(x => x.CounterpartyId == id);
                counterparty = value;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Counterparties/5
        [HttpDelete("{id}")]
        public void DeleteCounterparty(int id)
        {
            try
            {
                Counterparty counterparty = db.Counterparty.Single(x => x.CounterpartyId == id);
                db.Counterparty.Remove(counterparty);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
