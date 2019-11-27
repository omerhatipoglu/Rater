using RateYourIdea.Core.BaseModels;
using RateYourIdea.Entity.Context.Entities;
using System.Collections.Generic;

namespace RateYourIdea.BL.BLs.UserBL
{
    public interface IUserBL
    {
        Result<List<User>> GetUsers();
    }
}
