using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatingDadJokes.Data.Model
{
    [Table("JOKES")]
    public class Joke
    {
        [Key]
        public string Id { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public string Type { get; set; }
    }
}