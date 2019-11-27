using RateYourIdea.Core.BaseModels;

namespace RateYourIdea.BL.Repos
{
    public interface IBaseDAL<T> : IBaseRepository<T>
        where T : BaseModel, IEntity
    {
    }
}
