
using RateYourIdea.Core.BaseModels;
using RateYourIdea.Entity.Context;

namespace RateYourIdea.BL.Repos
{
    public class BaseDAL<T> : BaseRepository<T>, IBaseDAL<T>
        where T : BaseModel, IEntity
    {
        public BaseDAL(DBContext context) : base(context)
        {

        }
    }
}
