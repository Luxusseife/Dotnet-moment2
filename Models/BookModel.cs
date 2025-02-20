using System.ComponentModel.DataAnnotations;
namespace Moment2.Models;

public class BookModel
{
    // Properties.
    public int Id { get; set; }

    [Display(Name = "Title:")]
    public required string BookName { get; set; }

    [Display(Name = "Author:")]
    public required string Author { get; set; }

    [Display(Name = "Release year:")]
    public required int ReleaseYear { get; set; }

    [Display(Name = "Read:")]
    public required bool Read { get; set; }

    // Beräknade (formaterade) properties.

    // Gör boktitel till versaler.
    public string Title => BookName.ToUpper();
    
    // Sätter status utifrån booleans värde.
    public string Status => Read ? "Yes" : "No";
}