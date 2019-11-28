namespace RateYourIdea.Entity.Context
{
    using RateYourIdea.Entity.Context.Entities;
    using RateYourIdea.Entity.Migrations;
    using System.Data.Entity;

    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<AnswerOption> AnswerOptions { get; set; }
        public virtual DbSet<AnswerType> AnswerTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyQuestion>()
                .HasMany(x => x.AnswerOptions)
                .WithRequired(x => x.SurveyQuestion)
                .HasForeignKey(x => x.SurveyQuestionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Survey>()
                .HasMany(x => x.SurveyQuestions)
                .WithRequired(x => x.Survey)
                .HasForeignKey(x => x.SurveyID)
                .WillCascadeOnDelete(false);
        }
    }

}