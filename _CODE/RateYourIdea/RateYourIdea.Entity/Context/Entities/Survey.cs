using RateYourIdea.Core.BaseModels;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateYourIdea.Entity.Context.Entities
{
    [Table("Survey")]
    public class Survey : BaseModel, IEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }

    }
}
