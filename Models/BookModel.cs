using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Moment2.Models;

public class BookModel
{
    // Properties. 
    // Display är visnings-text. 
    // Required är felmeddelandet som visas vid valideringsfel.
    public int Id { get; set; }

    [Display(Name = "Title:")]
    [Required(ErrorMessage = "Enter a title!")]
    public required string BookName { get; set; }

    [Display(Name = "Author:")]
    [Required(ErrorMessage = "Enter an author!")]
    public required string Author { get; set; }

    [Display(Name = "Release year:")]
    [Required(ErrorMessage = "Enter the release year!")]
    [Range(1500, int.MaxValue, ErrorMessage = "The release year must be between 1500 and the current year.")]
    public required int ReleaseYear { get; set; }

    [Display(Name = "Read (check for yes):")]
    public bool Read { get; set; }


    // Beräknade (formaterade) properties. Lagrar inte dessa i JSON-filen.

    [JsonIgnore]
    // Gör boktitel till versaler.
    public string Title => BookName.ToUpper();

    [JsonIgnore]
    // Sätter status utifrån booleans värde.
    public string Status => Read ? "Yes" : "No";
}