using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class Diamond
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string DiamondType { get; set; }
        [ForeignKey("RetailerId")]
        public int RetailerId { get; set; }            
        public Retailer Retailer { get; set; }     
        public virtual List<Image> Images { get; set; }       
    }
}