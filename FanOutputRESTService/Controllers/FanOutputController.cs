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
        public static List<FanOutputModel> FanOutputReadings = new List<FanOutputModel>()
        {
            new FanOutputModel("First Output", 15, 30){ Id = 1},
            new FanOutputModel("Second Output", 18, 41){ Id = 2},
            new FanOutputModel("Thrid Output", 24, 69){ Id = 3},
            new FanOutputModel("Fourth Output", 22, 49){ Id = 4},
            new FanOutputModel("Sixth Output", 20, 75){ Id = 5},
        };

        // GET: api/<FanOutputController>
        [HttpGet]
        public IEnumerable<FanOutputModel> Get()
        {
            return FanOutputReadings;
        }

        // GET api/<FanOutputController>/5
        [HttpGet("{id}")]
        public FanOutputModel Get(int id)
        {
            return FanOutputReadings.Find(i => i.Id == id);
        }

        // POST api/<FanOutputController>
        [HttpPost]
        public void Post([FromBody] FanOutputModel value)
        {
            value.Id = FanOutputReadings.Last().Id + 1;
            FanOutputReadings.Add(value);
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
            FanOutputReadings.Remove(fanOutput);
        }
    }
}
