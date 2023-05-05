using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Vidly.DTO;

public class MovieDto
{
    [DataMember]
    public int? Id { get; set; }

    [DataMember]
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [DataMember]
    [Required]
    public DateTime? ReleaseDate { get; set; }

    [DataMember]
    [Required]
    public DateTime? DateAdded { get; set; }

    [DataMember]
    [Required]
    [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
    public int? NumberInStock { get; set; }

    [DataMember]
    [Required]
    public byte? GenreId { get; set; }

    [DataMember]
    public GenreDto Genre { get; set; }
}
