﻿using OpenQA.Selenium.Interactions;

namespace RecordSampleREST.Model
{
    public class MusicRecordRepository
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



        public List<MusicRecords> GetAllRecords(string? artist = null, string? title = null, int? publicationYearOlderThen = null, int? durationGreaterThen = null)
        {
            List<MusicRecords> filteredMusicRecords = new List<MusicRecords>(_musicRecords);

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

    }
}
