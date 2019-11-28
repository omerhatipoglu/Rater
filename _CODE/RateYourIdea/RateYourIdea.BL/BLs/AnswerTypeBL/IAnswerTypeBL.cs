using RateYourIdea.Core.BaseModels;
using RateYourIdea.Entity.DTOs;
using System.Collections.Generic;

namespace RateYourIdea.BL.BLs.AnswerTypeBL
{
    public interface IAnswerTypeBL
    {
        Result<List<AnswerTypeDTO>> GetAnswerTypes();
    }
}
