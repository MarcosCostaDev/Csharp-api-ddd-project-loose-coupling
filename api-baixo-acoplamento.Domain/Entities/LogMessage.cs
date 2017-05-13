using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_baixo_acoplamento.Domain.Entities
{
    public class LogMessage
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Application { get; set; }

        public string MessageType { get; set; }

        public string message { get; set; }

        public DateTime CurrentDate { get; set; }
    }
}
