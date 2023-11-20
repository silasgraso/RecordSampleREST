namespace RecordSampleREST.Model
{
    public class MusicRecordrepositoryDB : IMusicRepository
    {
        private readonly MusicRecordDBContext _musicRecordDBContext;

        public MusicRecordrepositoryDB(MusicRecordDBContext musicRecordDBContext)
        {
            _musicRecordDBContext = musicRecordDBContext;
        }

        public MusicRecords Add(MusicRecords musicRecords)
        {
            musicRecords.Validate();
            _musicRecordDBContext.MusicRecords.Add(musicRecords);
            _musicRecordDBContext.SaveChanges();
            return musicRecords;
        }

        public IEnumerable<MusicRecords> GetAllRecords(string? artist = null, string? title = null, int? publicationYearOlderThen = null, int? durationGreaterThen = null) 
        {
            IEnumerable<MusicRecords> filteredMusicRecords = _musicRecordDBContext.MusicRecords.AsEnumerable();
                       if (artist != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.Artist == artist);
            }
            if (title != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.Title == title);
            }
            if (publicationYearOlderThen != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.PublicationYear > publicationYearOlderThen);
            }
            if (durationGreaterThen != null)
            {
                filteredMusicRecords = filteredMusicRecords.Where(musicRecord => musicRecord.Duration > durationGreaterThen);
            }
            return filteredMusicRecords;
        }

        public MusicRecords? Delete(int id)
        {
            MusicRecords? musicRecord = _musicRecordDBContext.MusicRecords.FirstOrDefault(musicRecord => musicRecord.Id == id);
            if (musicRecord == null)
            {
                return null;
            }
            _musicRecordDBContext.MusicRecords.Remove(musicRecord);
            _musicRecordDBContext.SaveChanges();
            return musicRecord;
        }

        public MusicRecords? Update(int id, MusicRecords musicRecord)
        {
            MusicRecords? musicRecordToUpdate = _musicRecordDBContext.MusicRecords.FirstOrDefault(musicRecord => musicRecord.Id == id);

            if (musicRecord == null)
            {
                return null;
            }

            musicRecord.Validate();
            musicRecordToUpdate.Artist = musicRecord.Artist;
            musicRecordToUpdate.Title = musicRecord.Title;
            musicRecordToUpdate.PublicationYear = musicRecord.PublicationYear;
            musicRecordToUpdate.Duration = musicRecord.Duration;
            return musicRecordToUpdate;
        }

    }
}
