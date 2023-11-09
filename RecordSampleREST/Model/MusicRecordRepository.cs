namespace RecordSampleREST.Model
{
    public class MusicRecordRepository
    {
        private List<MusicRecords> _musicRecords = new();

        public MusicRecordRepository(List<MusicRecords> musicRecords)
        {
            _musicRecords = musicRecords;
        }

        public MusicRecordRepository() 
        {
            _musicRecords.Add(new MusicRecords { Id = 1, Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1969, Duration = 47 });
            _musicRecords.Add(new MusicRecords { Id = 2, Artist = "Oasis", Title = "Sgt. Pepper's Lonely Hearts Club Band", PublicationYear = 1967, Duration = 41 });
            _musicRecords.Add(new MusicRecords { Id = 3, Artist = "The Beatles", Title = "Revolver", PublicationYear = 1966, Duration = 35 });
        }



        public List<MusicRecords> GetAllRecords()
        {
            return _musicRecords;
        }

    }
}
