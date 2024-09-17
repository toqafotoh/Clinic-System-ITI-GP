using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(10)]
        public string Content { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
