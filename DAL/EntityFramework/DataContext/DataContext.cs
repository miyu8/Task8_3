using Life;

namespace DAL
{
	using System.Data.Entity;

	public class DataContext : DbContext
    {
		public DataContext()
			: base(@"data source=(LocalDB)\MSSQLLocalDB;initial catalog=LifeBase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
		{
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //public virtual DbSet<Score> Scores { get; set; }

        //public virtual DbSet<Student> Students { get; set; }

        //public virtual DbSet<Subject> Subjects { get; set; }
        public DbSet<Coords> CoordsSet { get; set; }
        public DbSet<Game> GameSet { get; set; }
        public DbSet<MSreplication_options> MSreplication_options { get; set; }
        public DbSet<spt_fallback_db> spt_fallback_db { get; set; }
        public DbSet<spt_fallback_dev> spt_fallback_dev { get; set; }
        public DbSet<spt_fallback_usg> spt_fallback_usg { get; set; }
        public DbSet<spt_monitor> spt_monitor { get; set; }
    }

    //public class Student
    //{
    //	public int Id { get; set; }
    //	public string Name { get; set; }
    //}

    //public class Subject
    //{
    //	public int Id { get; set; }
    //	public string Name { get; set; }
    //}

    //public class Score
    //{
    //	public int Id { get; set; }
    //	public int StudentId { get; set; }
    //	public int SubjectId { get; set; }
    //	public int ScoreNumber { get; set; }
    //}


}