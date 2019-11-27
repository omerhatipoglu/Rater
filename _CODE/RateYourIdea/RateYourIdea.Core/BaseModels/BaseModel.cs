using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateYourIdea.Core.BaseModels
{
    public class BaseModel
    {
        public BaseModel()
        {
            IsActive = true;
            IsDeleted = false;
            CreateDate = DateTime.Now;
        }
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [Required]
        public int CreateUserID { get; set; }

        public int? UpdateUserID { get; set; }
    }
}
