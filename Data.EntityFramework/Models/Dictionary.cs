using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EntityFramework.Models
{
    [Table("Dictionary")]
    public sealed class Dictionary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        [MaxLength(50)]
        public string MUIIconName { get; set; }
    }
}
