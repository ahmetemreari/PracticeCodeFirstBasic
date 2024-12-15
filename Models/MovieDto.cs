using System.ComponentModel.DataAnnotations;

namespace EmrePracticeDbOne.Models
{
    public class MovieDto
    {
        public string Title { get; set; }

        [RegularExpression(@"^(Action|Comedy|Drama)$", ErrorMessage = "Invalid Genre")]
        public string Genre { get; set; }

        public int ReleaseYear { get; set; }
    }
}