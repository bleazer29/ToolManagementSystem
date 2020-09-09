using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{

    [Route("api/NRI/Statuses")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly TMSdbContext db;

        public StatusesController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Statuses
        [HttpGet]
        public List<ToolStatus> GetStatuses(string name)
        {
            List<ToolStatus> statuses = new List<ToolStatus>();
            statuses = db.ToolStatus.ToList();
            if (string.IsNullOrEmpty(name) == false)
            {
                statuses = statuses.Where(x => x.Name == name).ToList();
            }
            return statuses;
        }

        // GET api/NRI/Statuses/5
        [HttpGet("{id}")]
        public ToolStatus GetStatus(int id)
        {
            ToolStatus status = db.ToolStatus.Single(x => x.ToolStatusId == id);
            return status;
        }

        // POST api/NRI/Statuses
        [HttpPost]
        public void AddStatus([FromBody] ToolStatus value)
        {
            try
            {
                ToolStatus status = new ToolStatus();
                status = value;
                db.ToolStatus.Add(status);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Statuses/5
        [HttpPut("{id}")]
        public void EditStatus(int id, [FromBody] ToolStatus value)
        {
            try
            {
                ToolStatus status = db.ToolStatus.Single(x => x.ToolStatusId == id);
                if (status != null)
                {
                    status.Name = value.Name;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Statuses/5
        [HttpDelete("{id}")]
        public void DeleteStatus(int id)
        {
            try
            {
                ToolStatus status = db.ToolStatus.Single(x => x.ToolStatusId == id);
                db.ToolStatus.Remove(status);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
