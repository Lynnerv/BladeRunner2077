using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BladeRunner2077.Models
{
    [Table("t_Account")]
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public decimal InitialDeposit { get; set; }
    }
}