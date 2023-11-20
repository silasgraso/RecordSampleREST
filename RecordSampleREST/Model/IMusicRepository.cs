namespace RecordSampleREST.Model
{
    public interface IMusicRepository
    {
        MusicRecords Add(MusicRecords musicRecords);
        IEnumerable<MusicRecords> GetAllRecords(string? artist = null, string? title = null, int? publicationYearOlderThen = null, int? durationGreaterThen = null);
        MusicRecords? Delete(int id);
        MusicRecords? Update(int id, MusicRecords musicRecord);
    }
}
