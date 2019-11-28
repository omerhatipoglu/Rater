using RateYourIdea.BL.Repos;
using RateYourIdea.Core.BaseModels;
using RateYourIdea.Entity.Context.Entities;
using RateYourIdea.Entity.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace RateYourIdea.BL.BLs.AnswerTypeBL
{
    public class AnswerTypeBL : IAnswerTypeBL
    {
        private readonly UnitOfWork uow = new UnitOfWork();

        public Result<List<AnswerTypeDTO>> GetAnswerTypes()
        {
            List<AnswerType> answerTypes = uow.AnswerTypeRepository.GetAll().ToList();
            List<AnswerTypeDTO> responseModel = new List<AnswerTypeDTO>();
            foreach (var item in answerTypes)
            {
                responseModel.Add(new AnswerTypeDTO() { ID = item.ID, Name = item.Name, Type = item.Type });
            }

            return new Result<List<AnswerTypeDTO>>(responseModel);
        }
    }
}
