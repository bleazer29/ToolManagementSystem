using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers
{
    [Route("api/Contracts")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly TMSdbContext db;

        public ContractsController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/Contracts
        [HttpGet("{startDate:datetime?}/{endDate:datetime?}")]
        public async Task<IActionResult> GetContracts(string name, string counterparty, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                List<Contract> contracts = await db.Contract
                    .Include(x => x.Counterparty)
                    .ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    contracts = contracts.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                }
                if (string.IsNullOrEmpty(counterparty) == false)
                {
                    contracts = contracts.Where(x => x.Counterparty.Name.ToLower().Contains(counterparty.ToLower())).ToList();
                }
                if(startDate != null)
                {
                    contracts = contracts.Where(x => x.DateStart >= startDate).ToList();
                }
                if (endDate != null)
                {
                    contracts = contracts.Where(x => x.DateStart <= endDate).ToList();
                }
                return Ok(contracts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/Contracts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract(int id)
        {
            try
            {
                Contract contract = await db.Contract.SingleAsync(x => x.ContractId == id);
                return Ok(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Contracts
        [HttpPost]
        public async Task<IActionResult> AddContract([FromBody] Contract value)
        {
            try
            {
                await db.Contract.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/Contracts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditContract(int id, [FromBody] Contract value)
        {
            try
            {
                Contract contract = await db.Contract.SingleAsync(x => x.ContractId == id);
                if(contract != null)
                {
                    contract.Name = value.Name;
                    contract.DateStart = value.DateStart;
                    contract.DateEnd = value.DateEnd;
                    contract.CounterpartyId = value.CounterpartyId;
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

        // DELETE api/Contracts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            try
            {
                Contract contract = await db.Contract.SingleAsync(x => x.ContractId == id);
                db.Contract.Remove(contract);
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
