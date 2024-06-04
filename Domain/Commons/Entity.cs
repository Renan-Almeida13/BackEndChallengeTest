using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? RemovalDate { get; set; }
        public int RegisteredByUserId { get; set; }
        public int? ModifiedByUserId { get; set; }
        public int? RemovedByUserId { get; set; }
    }
}
