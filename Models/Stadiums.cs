using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cup.Models;

public class Stadiums
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public int Capacity { get; set; }

    public string City { get; set; }

    public string Type { get; set; }

    public DateTime ConstractionDate { get; set; }

    public string Owner { get; set; }

    public double Length { get; set; }

    public double width { get; set; }

    public string Images { get; set; }

    public string Desc { get; set; }


    public List<string> Facility { get; set; } = new List<string>(); //تفاصيل داخل الملعب

}