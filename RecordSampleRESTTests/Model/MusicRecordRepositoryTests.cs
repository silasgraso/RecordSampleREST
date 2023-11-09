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
        [TestMethod()]
        public void GetAllRecordsTest()
        {
           MusicRecordRepository musicRecordRepository = new MusicRecordRepository();
           List<MusicRecords> musicRecords = musicRecordRepository.GetAllRecords();
           Assert.AreEqual(3, musicRecords.Count);
        }
    }
}