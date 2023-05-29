namespace WebApi.Models.Ships;

using System.ComponentModel.DataAnnotations;


public class CreateRequest
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public int? Length { get; set; }

    [Required]
    public int? Width { get; set; }

    [Required]
    [RegularExpression(@"^[A-Za-z]{4}-\d{4}-[A-Za-z]\d$", 
    ErrorMessage = "Invalid format. It should be AAAA-1111-A1")]
    public string? Code { get; set; }

}