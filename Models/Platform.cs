using System.ComponentModel.DataAnnotations;

namespace AssessmentOne.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string UniqueName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<Well> Well { get; set; }
    }
}
