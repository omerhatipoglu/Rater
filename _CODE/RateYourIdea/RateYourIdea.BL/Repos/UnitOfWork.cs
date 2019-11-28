using RateYourIdea.Entity.Context;
using RateYourIdea.Entity.Context.Entities;
using System;

namespace RateYourIdea.BL.Repos
{
    public class UnitOfWork : IDisposable
    {
        private DBContext context = new DBContext();

        private IBaseDAL<User> userRepository;

        public IBaseDAL<User> UserRepository
        {
            get 
            { 
                return userRepository ?? new BaseDAL<User>(context);
            }
        }

        private IBaseDAL<Survey> surveyRepository;

        public IBaseDAL<Survey> SurveyRepository
        {
            get 
            { 
                return surveyRepository ?? new BaseDAL<Survey>(context); 
            }
        }

        private IBaseDAL<SurveyQuestion> surveyQuestionRepository;

        public IBaseDAL<SurveyQuestion> SurveyQuestionRepository
        {
            get 
            { 
                return surveyQuestionRepository ?? new BaseDAL<SurveyQuestion>(context); 
            }
        }

        private IBaseDAL<AnswerOption> answerOptionRepository;

        public IBaseDAL<AnswerOption> AnswerOptionRepository
        {
            get 
            { 
                return answerOptionRepository ?? new BaseDAL<AnswerOption>(context); 
            }
        }

        private IBaseDAL<AnswerType> answerTypeRepository;

        public IBaseDAL<AnswerType> AnswerTypeRepository
        {
            get 
            { 
                return answerTypeRepository ?? new BaseDAL<AnswerType>(context); 
            }
        }



        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
