using System.ComponentModel.DataAnnotations;

namespace Chat_App.Models
{
    public class Rate
    { 
        public int Id { get; set; }

        public string UserName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }

        public DateTime DateTime { get; set; }

    }
}
