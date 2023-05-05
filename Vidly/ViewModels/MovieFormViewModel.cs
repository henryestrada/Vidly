using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Vidly.Models;

namespace Vidly.ViewModels;

[DataContract]
public class MovieFormViewModel
{
    public MovieFormViewModel()
    {
        Id = 0;
    }
    public MovieFormViewModel(MovieFormViewModel other)
    {
        other ??= new MovieFormViewModel();

        Id = other.Id;
        Name = other.Name;
        ReleaseDate = other.ReleaseDate;
        NumberInStock = other.NumberInStock;
        GenreId = other.GenreId;
    }

    [DataMember]
    public int? Id { get; set; }

    [DataMember]
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "Release Date")]
    public DateTime? ReleaseDate { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "Number In Stock")]
    [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
    public int? NumberInStock { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "Genre")]
    public byte? GenreId { get; set; }

    [DataMember]
    public IEnumerable<Genre>? Genres { get; set; }
}
