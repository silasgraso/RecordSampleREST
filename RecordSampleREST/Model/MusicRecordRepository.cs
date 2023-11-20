using OpenQA.Selenium.Interactions;

namespace RecordSampleREST.Model
{
    public class MusicRecordRepository : IMusicRepository
    {
        private List<MusicRecords> _musicRecords = new();
        private int _nextId = 1;

        public MusicRecordRepository(List<MusicRecords> musicRecords)
        {
            _musicRecords = musicRecords;
        }

        public MusicRecordRepository() 
        {
            _musicRecords.Add(new MusicRecords { Id = _nextId++, Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1969, Duration = 47 });
            _musicRecords.Add(new MusicRecords { Id = _nextId++, Artist = "Oasis", Title = "Sgt. Pepper's Lonely Hearts Club Band", PublicationYear = 1967, Duration = 41 });
            _musicRecords.Add(new MusicRecords { Id = _nextId++, Artist = "The Beatles", Title = "Revolver", PublicationYear = 1966, Duration = 35 });
        }



        public IEnumerable<MusicRecords> GetAllRecords(string? artist = null, string? title = null, int? publicationYearOlderThen = null, int? durationGreaterThen = null)
        {
            IEnumerable<MusicRecords> filteredMusicRecords = new List<MusicRecords>(_musicRecords);

            if (artist != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.Artist == artist).ToList();
            }
            if (title != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.Title == title).ToList();
            }
            if (publicationYearOlderThen != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.PublicationYear > publicationYearOlderThen).ToList();
            }
            if (durationGreaterThen != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.Duration > durationGreaterThen).ToList();
            }
           

            return filteredMusicRecords;
        }

        public MusicRecords Add(MusicRecords musicRecords)
        {
            musicRecords.Validate();
            musicRecords.Id = _nextId++;
            _musicRecords.Add(musicRecords);
            return musicRecords;
        }

        public MusicRecords? Delete(int id)
        {
            MusicRecords? musicRecord = _musicRecords.FirstOrDefault(musicRecord => musicRecord.Id == id);
            if (musicRecord == null)
            {
                return null;
            }
            _musicRecords.Remove(musicRecord);
            return musicRecord;
        }

        public MusicRecords? Update(int id, MusicRecords musicRecord)
        {
            MusicRecords? musicRecordToUpdate = _musicRecords.FirstOrDefault(musicRecord => musicRecord.Id == id);
            if (musicRecordToUpdate == null)
            {
                return null;
            }
            musicRecordToUpdate.Artist = musicRecord.Artist;
            musicRecordToUpdate.Title = musicRecord.Title;
            musicRecordToUpdate.PublicationYear = musicRecord.PublicationYear;
            musicRecordToUpdate.Duration = musicRecord.Duration;
            return musicRecordToUpdate;
        }

    }
}