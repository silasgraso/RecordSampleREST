using Microsoft.AspNetCore.Mvc;
using RecordSampleREST.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecordSampleREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {
        private readonly MusicRecordRepository _musicRecordRepository;

        public MusicRecordsController(MusicRecordRepository musicRecordRepository)
        {
            _musicRecordRepository = musicRecordRepository;
        }

        // GET: api/<MusicRecordsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<MusicRecordRepository>> GetAll([FromQuery] string? artist, [FromQuery] string? title, [FromQuery] int? publicationYearOlderThen, [FromQuery] int? durationGreaterThen)
        {   
            return Ok(_musicRecordRepository.GetAllRecords(artist,title,publicationYearOlderThen,durationGreaterThen));
        }

        // GET api/<MusicRecordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicRecordsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
