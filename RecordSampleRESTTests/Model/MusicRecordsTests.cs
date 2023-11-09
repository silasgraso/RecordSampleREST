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
    public class MusicRecordsTests
    {

        [TestMethod()]
        public void ValidateArtistTest()
        {
            MusicRecords musicRecords = new MusicRecords { Id = 1, Artist = "Az", Title = "Abbey Road", PublicationYear = 1969, Duration = 47 };
            musicRecords.ValidateArtist();

            MusicRecords nullArtist = new MusicRecords { Id = 1, Artist = null, Title = "Abbey Road", PublicationYear = 1969, Duration = 47 };
            Assert.ThrowsException<ArgumentNullException>(() => nullArtist.ValidateArtist());

            MusicRecords shortArtist = new MusicRecords { Id = 1, Artist = "A", Title = "Abbey Road", PublicationYear = 1969, Duration = 47 };
            Assert.ThrowsException<ArgumentException>(() => shortArtist.ValidateArtist());
            
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            MusicRecords musicRecords = new MusicRecords { Id = 1, Artist = "The Beatles", Title = "Ab", PublicationYear = 1969, Duration = 47 };
            musicRecords.ValidateTitle();

            MusicRecords nullTitle = new MusicRecords { Id = 1, Artist = "The Beatles", Title = null, PublicationYear = 1969, Duration = 47 };
            Assert.ThrowsException<ArgumentNullException>(() => nullTitle.ValidateTitle());

            MusicRecords shortTitle = new MusicRecords { Id = 1, Artist = "The Beatles", Title = "A", PublicationYear = 1969, Duration = 47 };
            Assert.ThrowsException<ArgumentException>(() => shortTitle.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePublicationYearTest()
        {
            MusicRecords musicRecords = new MusicRecords { Id = 1, Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1900, Duration = 47 };
            musicRecords.ValidatePublicationYear();

            MusicRecords shortPublicationYear = new MusicRecords { Id = 1, Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1899, Duration = 47 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shortPublicationYear.ValidatePublicationYear());

        }

        [TestMethod()]
        public void ValidateDurationTest()
        {
            MusicRecords musicRecords = new MusicRecords { Id = 1, Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1969, Duration = 1 };
            musicRecords.ValidateDuration();

            MusicRecords shortDuration = new MusicRecords { Id = 1, Artist = "The Beatles", Title = "Abbey Road", PublicationYear = 1969, Duration = 0 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shortDuration.ValidateDuration());
        }
    }
}