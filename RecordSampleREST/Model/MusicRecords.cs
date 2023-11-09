namespace RecordSampleREST.Model
{
    public class MusicRecords
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }

        public int Duration { get; set; }


        public MusicRecords() { }
    }
}
