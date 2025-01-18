using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cup.Models;

public class FootballTabels {
    [Key]
    public int Id { get; set; }
    public int Stadiums_Id { get; set; } //foriegn key

    public string Ateam1 { get; set; }

    public string Ateam2 { get; set; }

    public DateTime MatchTime { get; set; }


}