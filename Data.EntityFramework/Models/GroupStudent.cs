using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.Data.EntityFramework.Models
{
    [Table("GroupStudent")]
    public sealed class GroupStudent
    {
        [ForeignKey("FK_StudentId")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("FK_GroupId")]
        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
