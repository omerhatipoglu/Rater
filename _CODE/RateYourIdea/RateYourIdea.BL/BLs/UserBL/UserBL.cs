using RateYourIdea.BL.Repos;
using RateYourIdea.Core.BaseModels;
using RateYourIdea.Entity.Context.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RateYourIdea.BL.BLs.UserBL
{
    public class UserBL : IUserBL
    {
        private readonly UnitOfWork uow = new UnitOfWork();

        public Result<List<User>> GetUsers()
        {
            return new Result<List<User>>(uow.UserRepository.GetAll().ToList());
        }
    }
}
