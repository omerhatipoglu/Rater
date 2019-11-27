namespace RateYourIdea.Entity.Migrations
{
    using RateYourIdea.Entity.Context;
    using RateYourIdea.Entity.Context.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "RateYourIdea.Entity.Context.DBContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DBContext context)
        {
            bool response = context.Users.Where(x => x.FirstName == "Ömer" && x.LastName == "Last").Any();

            if (!response)
            {
                IList<User> defaultUser = new List<User>();

                defaultUser.Add(new User()
                {
                    CreateDate = DateTime.Now,
                    CreateUserID = 1,
                    FirstName = "Ömer",
                    IsActive = true,
                    IsAdmin = true,
                    IsDeleted = false,
                    LastName = "Last",
                    Password = "1234",
                    UserName = "qwer"
                });

                context.Users.AddRange(defaultUser);
            }

            base.Seed(context);
        }
    }
}
