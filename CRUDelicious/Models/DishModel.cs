#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models;

public class Dish
{
    [Key]
    public int id { get; set; }
    [Required(ErrorMessage = "is required")]
    public string name { get; set; }
    [Required(ErrorMessage = "is required")]
    public string chef { get; set; }
    [Required(ErrorMessage = "is required")]
    [Range(1, 9999)]
    public int calories { get; set; }
    [Required(ErrorMessage = "is required")]
    public int tastiness { get; set; }
    [Required(ErrorMessage = "is required")]
    public string description { get; set; }
    [Required(ErrorMessage = "is required")]
    public DateTime created_at { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "is required")]
    public DateTime updated_at { get; set; } = DateTime.Now;
}