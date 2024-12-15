using System.ComponentModel.DataAnnotations;
namespace EmrePracticeDbOne.Models
{
public class Game
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    [RegularExpression(@"^(PC|PlayStation|Xbox)$", ErrorMessage = "Invalid Platform")]
    public string Platform { get; set; }

    [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
    public decimal Rating { get; set; }
}
}