using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Vidly.Models;

namespace Vidly.ViewModels;

[DataContract]
public class MovieFormViewModel
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "Number In Stock")]
    [Range(0, int.MaxValue)]
    public int NumberInStock { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "Genre")]
    public byte GenreId { get; set; }

    [DataMember]
    public IEnumerable<Genre> Genres { get; set; }
}
