using System.Text.Json.Serialization;

namespace Chat_App.Models
{
    public class Contact
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Server { get; set; }

        public string Last { get; set; }

        public DateTime LastDate { get; set; }

        [JsonIgnore]
        public List<Message> Messages { get; set; }

        //[JsonIgnore]
        public string UserName { get; set; }
    }
}
