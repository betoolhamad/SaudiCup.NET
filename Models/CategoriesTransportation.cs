using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cup.Models;

public class CategoriesTransportation {
    [Key]

    public int Id { get; set; }

    public string Name { get; set; } //seedan jeeb small

}
