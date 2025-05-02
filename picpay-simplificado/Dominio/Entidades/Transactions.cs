using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Transactions
    {
        public long Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public long Sender { get; set; }

        [Required]
        public long Recive { get; set; }

        public DateTime TimeStamp { get; set; }

        public Transactions(decimal amount, long sender, long recive, DateTime timeStamp)
        {
            Amount = amount;
            Sender = sender;
            Recive = recive;
            TimeStamp = timeStamp;
        }
    }
}
