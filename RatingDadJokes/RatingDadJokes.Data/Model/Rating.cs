using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatingDadJokes.Data.Model
{
    [Table("RATINGS")]
    public class Rating
    {
        [Key]
        public string Id { get; set; }
        public Joke Joke { get; set; }
        public int Stars { get; set; }
    }
}