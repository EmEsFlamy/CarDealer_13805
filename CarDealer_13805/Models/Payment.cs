﻿using System.Text.Json.Serialization;

namespace CarDealer_13805.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        public virtual int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public DateTime TranscationDate { get; set; }
    }
}
