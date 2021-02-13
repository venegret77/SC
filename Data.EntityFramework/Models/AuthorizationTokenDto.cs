using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EntityFramework.Models
{
    [Table("AuthorizationToken")]
    public sealed class AuthorizationTokenDto
    {
        [Required, ForeignKey("FK_Account_Id")]
        public long AccountId { get; set; }
        public AccountDto Account { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime ExpirationDateTime { get; set; }
    }
}
