using BeyondOne.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeyondOne.Data.Models
{
    public class Products: _BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int AvailableStock { get; set; }
    }
}
