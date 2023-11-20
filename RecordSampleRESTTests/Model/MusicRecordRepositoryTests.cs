using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordSampleREST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSampleREST.Model.Tests
{
    [TestClass()]
    public class MusicRecordRepositoryTests
    {
        private const bool useDatabase = true;
        private static MusicRecordDBContext? _context;
        private static IMusicRepository _musicRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            if (useDatabase)
            {
                var optionBuilder = new DbContextOptionsBuilder<MusicRecordDBContext>();
                optionBuilder.UseSqlServer("Data Source = mssql9.unoeuro.com; Initial Catalog = fabgras_dk_db_elearning; Persist Security Info = True; User ID = fabgras_dk; Password = pm4txrcBHhnFfRakG25y; TrustServerCertificate = True");
                _context = new MusicRecordDBContext(optionBuilder.Options);
                _musicRepository = new MusicRecordrepositoryDB(_context);
            }
            else
            {
                _musicRepository = new MusicRecordRepository();
            }
        }

        [TestMethod()]
        public void GetAllRecordsTest()
        {
           MusicRecordRepository musicRecordRepository = new MusicRecordRepository();
           IEnumerable<MusicRecords> musicRecords = musicRecordRepository.GetAllRecords();
           Assert.AreEqual(3, musicRecords.Count());
        }

        [TestMethod()]
        public void AddTest()
        {
            MusicRecordRepository musicRecordRepository = new MusicRecordRepository();
            MusicRecords musicRecords = new MusicRecords { Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1969, Duration = 47 };
            musicRecordRepository.Add(musicRecords);
            IEnumerable<MusicRecords> musicRecordsList = musicRecordRepository.GetAllRecords();
            Assert.AreEqual(4, musicRecordsList.Count());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            MusicRecordRepository musicRecordRepository = new MusicRecordRepository();
            MusicRecords? deletedMusicRecord = musicRecordRepository.Delete(1);
            Assert.IsNotNull(deletedMusicRecord);
            IEnumerable<MusicRecords> musicRecordsList = musicRecordRepository.GetAllRecords();
            Assert.AreEqual(2, musicRecordsList.Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            MusicRecordRepository musicRecordRepository = new MusicRecordRepository();
            MusicRecords musicRecords = new MusicRecords { Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1969, Duration = 47 };

            MusicRecords? updatedMusicRecord = musicRecordRepository.Update(1, musicRecords);
            Assert.IsNotNull(updatedMusicRecord);
            Assert.IsNotNull(updatedMusicRecord?.Artist);
            Assert.AreEqual("The Beatles", updatedMusicRecord?.Artist);
            Assert.AreEqual(1969, updatedMusicRecord?.PublicationYear);
        }
    }
}