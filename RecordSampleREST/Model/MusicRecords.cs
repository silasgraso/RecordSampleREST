namespace RecordSampleREST.Model
{
    public class MusicRecords
    {
        public int Id { get; set; }
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public int PublicationYear { get; set; }

        public int Duration { get; set; }


        public MusicRecords() { }

        public void ValidateArtist()
        {
            if (Artist == null)
            {
                throw new ArgumentNullException("Artist name must be provided");
            }
            if (Artist.Length < 2)
            {
                throw new ArgumentException("Artist name must be at least 2 characters long");
            }
        }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title must be provided");
            }
            if (Title.Length < 2)
            {
                throw new ArgumentException("Title must be at least 2 characters long");
            }
        }

        public void ValidatePublicationYear()
        {
            if (PublicationYear < 1900)
            {
                throw new ArgumentOutOfRangeException("Publication year must be at least 1900");
            }
        }

        public void ValidateDuration()
        {
            if (Duration < 1)
            {
                throw new ArgumentOutOfRangeException("Duration must be at least 1 second");
            }
        }

        public void Validate()
        {
            ValidateArtist();
            ValidateTitle();
            ValidatePublicationYear();
            ValidateDuration();
        }
    }
}
