using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanPutputModelLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FanOutputRESTService.Controllers
{
    [Route("api/FanOutputModel")]
    [ApiController]
    public class FanOutputController : ControllerBase
    {
        public static List<FanOutputModel> fanOutputReadings = new List<FanOutputModel>()
        {
            new FanOutputModel(1, "First Output", 15, 30),
            new FanOutputModel(2, "Second Output", 18, 41),
            new FanOutputModel(3, "Thrid Output", 24, 69),
            new FanOutputModel(4, "Fourth Output", 22, 49),
            new FanOutputModel(5, "Sixth Output", 20, 75),
        };

        // GET: api/<FanOutputController>
        [HttpGet]
        public IEnumerable<FanOutputModel> Get()
        {
            return fanOutputReadings;
        }

        // GET api/<FanOutputController>/5
        [HttpGet("{id}")]
        public FanOutputModel Get(int id)
        {
            return fanOutputReadings.Find(i => i.Id == id);
        }

        // POST api/<FanOutputController>
        [HttpPost]
        public void Post([FromBody] FanOutputModel value)
        {
            value.Id = fanOutputReadings.Count + 1;
            fanOutputReadings.Add(value);
        }

        // PUT api/<FanOutputController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutputModel value)
        {
            FanOutputModel fanOutput = Get(id);
            if(fanOutput != null)
            {
                fanOutput.Name = value.Name;
                fanOutput.Temp = value.Temp;
                fanOutput.Humidity = value.Humidity;
            }
        }

        // DELETE api/<FanOutputController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutputModel fanOutput = Get(id);
            fanOutputReadings.Remove(fanOutput);
        }
    }
}
