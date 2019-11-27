using RateYourIdea.Core.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateYourIdea.Entity.Context.Entities
{
    [Table("AnswerOption")]
    public class AnswerOption : BaseModel, IEntity
    {
        [Required]
        [StringLength(200)]
        public string Answer { get; set; }
        [Required]
        public int SurveyQuestionID { get; set; }

        public virtual SurveyQuestion SurveyQuestion { get; set; }
    }
}
