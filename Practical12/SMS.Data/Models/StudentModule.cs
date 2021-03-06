using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SMS.Data.Models
{
    public class StudentModule
    {
        public int Id { get; set; }
        [Range(0,100)]
        public double Mark {get; set; }

        // Foreign key for related Student model
        [JsonIgnore]public int StudentId { get; set; }
        [JsonIgnore]public Student Student { get; set; }

        // Foreign key for related Module model
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
