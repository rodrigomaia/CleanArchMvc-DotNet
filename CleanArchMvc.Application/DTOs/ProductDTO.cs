using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    [Column(TypeName ="decimal(10,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    [Required]
    [Range(1, 9999)]
    public int Stock { get; set; }
    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string Image { get; set; }
    [Required]
    [DisplayName("Categories")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}