using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Availabilities2.Models
{
    public class Availability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BrokerId { get; set; }
        public DateTime? BusinnessDate { get; set; }
        public string BrokerCode { get; set; }
        public string Symbol { get; set; }
        public long Quantity { get; set; }
        public decimal Rate { get; set; }
        public BrokerSource? BrokerSource { get; set; }
    }
}
