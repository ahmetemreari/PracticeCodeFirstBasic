using System.ComponentModel.DataAnnotations;
namespace EmrePracticeDbOne.Models
{
public class Movie
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }

    [RegularExpression(@"^(Action|Comedy|Drama)$", ErrorMessage = "Invalid Genre")]
    public string Genre { get; set; }

    public int ReleaseYear { get; set; }
}
}