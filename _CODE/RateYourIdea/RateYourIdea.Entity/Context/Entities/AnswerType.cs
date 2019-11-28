using RateYourIdea.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateYourIdea.Entity.Context.Entities
{
    public class AnswerType : BaseModel, IEntity
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
