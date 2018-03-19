using System.ComponentModel.DataAnnotations;

namespace ProvalusApplicantTrackingHub.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser Author { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string Content { get; set; }

        public virtual JobApp JobApp { get; set; }
    }
}