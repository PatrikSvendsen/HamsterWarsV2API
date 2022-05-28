using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Match
{
    [Key]
    [Column("MatchId")]
    public int? Id { get; set; }
    public int? WinnerId { get; set; }
    public int? LoserId { get; set; }
    public DateTime TimeStamp { get; set; }

    public ICollection<Hamster>? Hamsters { get; set; }

}
