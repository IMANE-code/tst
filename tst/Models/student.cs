using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tst.Models
{
    [Table("student")]
    public class student
    {
        [Key]
        public int id { get; set; }
        public string cin { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string adresse { get; set; }
    }
}
