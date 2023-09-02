using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Model;

public class Movie
{
    [Key]
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    [Required]
    public string Reviews { get; set; }
}