using Microsoft.EntityFrameworkCore;

namespace RecordSampleREST.Model

{
    public class MusicRecordDBContext : DbContext
    {
        public MusicRecordDBContext(DbContextOptions<MusicRecordDBContext> options) : base(options)
        {
        }

        public DbSet<MusicRecords> MusicRecords { get; set; } = null!;
    }
}
