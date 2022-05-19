using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Hamster
{
    [Key]
    [Column("HamsterId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name field is required")]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Age field is required")]
    public int Age { get; set; }

    [MaxLength(20)]
    [Required(ErrorMessage = "Food field is required")]
    public string FavFood { get; set; } = string.Empty;

    [MaxLength(20)]
    [Required(ErrorMessage = "Loves field is required")]
    public string Loves { get; set; } = string.Empty;

    public string ImgName { get; set; } = string.Empty;
    public int Wins { get; set; } = 0;
    public int Defeats { get; set; } = 0;
    public int Games { get; set; } = 0;


    [ForeignKey(nameof(Match))]
    public int MatchId { get; set; }
    public Match? Match { get; set; }
}
