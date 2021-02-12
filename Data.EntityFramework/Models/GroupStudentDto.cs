using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EntityFramework.Models
{
    [Table("GroupStudent")]
    public sealed class GroupStudentDto
    {
        [ForeignKey("FK_StudentId")]
        [Required]
        public int StudentId { get; set; }
        public StudentDto Student { get; set; }

        [ForeignKey("FK_GroupId")]
        [Required]
        public int GroupId { get; set; }
        public GroupDto Group { get; set; }
    }
}
