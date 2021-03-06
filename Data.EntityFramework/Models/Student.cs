﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.Data.EntityFramework.Models
{
    [Table("Student")]
    public sealed class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("FK_GenderId")]
        [Required]
        public int GenderId { get; set; }
        public Dictionary Gender { get; set; }

        [Required, MaxLength(40)]
        public string LastName { get; set; }

        [Required, MaxLength(40)]
        public string FirstName { get; set; }

        [MaxLength(60)]
        public string MiddleName { get; set; }

        [MinLength(6), MaxLength(16)]
        public string Identifer { get; set; }
    }
}
