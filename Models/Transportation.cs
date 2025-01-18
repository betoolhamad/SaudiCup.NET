using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cup.Models;

public class Transportation {
    [Key]
    public int Id { get; set; }

    public int Capacity { get; set; }
    
    public int  veichcle { get; set; } //foriegn key
    public string Name { get; set; }

    public string color { get; set; }

    public string Images { get; set; }

    public string Model { get; set; }

    public string Modelversion { get; set; }

    public string Km { get; set; }

    
}