using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Match
{
    [Key]
    [Column("MatchId")]
    public int Id { get; set; }

    [ForeignKey(nameof(Hamster))]
    public int WinnerId { get; set; }

    [ForeignKey(nameof(Hamster))]
    public int LoserId { get; set; }
}
