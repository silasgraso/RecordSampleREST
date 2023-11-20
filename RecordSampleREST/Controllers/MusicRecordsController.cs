using Microsoft.AspNetCore.Mvc;
using RecordSampleREST.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecordSampleREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {
        private IMusicRepository _musicRecordRepository;
        public MusicRecordsController(IMusicRepository musicRecordRepository)
        {
            _musicRecordRepository = musicRecordRepository;
        }

        // GET: api/<MusicRecordsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<MusicRecordRepository>> GetAll([FromQuery] string? artist, [FromQuery] string? title, [FromQuery] int? publicationYearOlderThen, [FromQuery] int? durationGreaterThen)
        {
            return Ok(_musicRecordRepository.GetAllRecords(artist, title, publicationYearOlderThen, durationGreaterThen));
        }

        // GET api/<MusicRecordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicRecordsController>
        [HttpPost]
        public ActionResult<MusicRecords?> Post([FromBody] MusicRecords newMusicRecords)
        {
            MusicRecords? addedMusicRecords = _musicRecordRepository.Add(newMusicRecords);
            try
            {
                return Created("/" + addedMusicRecords.Id, addedMusicRecords);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        public ActionResult<MusicRecords?> Put(int id, [FromBody] MusicRecords value)
        {
            MusicRecords? musicRecord = _musicRecordRepository.GetAllRecords().FirstOrDefault(musicRecord => musicRecord.Id == id);
            try
            {
                return Ok(_musicRecordRepository.Update(id, value));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        public ActionResult<MusicRecords?> Delete(int id)
        {
            MusicRecords? musicRecord = _musicRecordRepository.Delete(id);
            if (musicRecord == null)
            {
                return NotFound();
            }
            return Ok(musicRecord);
        }
    }
}
