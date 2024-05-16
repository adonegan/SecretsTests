using System.ComponentModel.DataAnnotations;

namespace WebAppSecretsTest.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DebutDate { get; set; }
        public string Description { get; set; }
    }
}
