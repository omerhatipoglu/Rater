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
                    IsActive = true,
                    IsAdmin = true,
                    IsDeleted = false,
                    FirstName = "Ömer",
                    LastName = "Last",
                    Password = "1234",
                    UserName = "qwer"
                });

                context.Users.AddRange(defaultUser);
            }

            response = context.AnswerTypes.Where(x => x.Type == "SingleSelect").Any();

            if (!response)
            {
                IList<AnswerType> answerTypes = new List<AnswerType>();

                answerTypes.Add(new AnswerType() {
                    CreateDate = DateTime.Now,
                    CreateUserID = 1,
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Tekli Seçim",
                    Type = "SingleSelect"
                });
                context.AnswerTypes.AddRange(answerTypes);
            }

            response = context.AnswerTypes.Where(x => x.Type == "MultiSelect").Any();

            if (!response)
            {
                IList<AnswerType> answerTypes = new List<AnswerType>();

                answerTypes.Add(new AnswerType()
                {
                    CreateDate = DateTime.Now,
                    CreateUserID = 1,
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Çoklu Seçim",
                    Type = "MultiSelect"
                });
                context.AnswerTypes.AddRange(answerTypes);
            }

            response = context.AnswerTypes.Where(x => x.Type == "CommentField").Any();

            if (!response)
            {
                IList<AnswerType> answerTypes = new List<AnswerType>();

                answerTypes.Add(new AnswerType()
                {
                    CreateDate = DateTime.Now,
                    CreateUserID = 1,
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Yorum Alaný",
                    Type = "CommentField"
                });
                context.AnswerTypes.AddRange(answerTypes);
            }

            base.Seed(context);
        }
    }
}
