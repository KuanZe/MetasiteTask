using MetasiteTask.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MetasiteTask.Models
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        public string Msisdn { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; }

    }
}
