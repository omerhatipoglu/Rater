using RateYourIdea.Core.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateYourIdea.Entity.Context.Entities
{
    [Table("SurveyQuestion")]
    public class SurveyQuestion : BaseModel, IEntity
    {
        [Required]
        [StringLength(200)]
        public string Question { get; set; }
        [Required]
        public int QuestionType { get; set; }
        [Required]
        public int SurveyID { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}
