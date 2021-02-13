using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EntityFramework.Models
{
    [Table("Dictionary")]
    public sealed class DictionaryDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("FK_Dictionary_ParentId")]
        public long ParentId { get; set; }
        public DictionaryDto Parent { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        [MaxLength(50)]
        public string MUIIconName { get; set; }
    }
}
