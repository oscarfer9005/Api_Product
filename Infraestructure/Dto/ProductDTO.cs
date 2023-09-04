using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Dto
{
    [Table("protuct")]
    public class ProductDto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Name { get; set; }
        [Column("descripcion")]
        public string Description { get; set; }
        [Column("categoria")]
        public string Category { get; set; }
        [Column("precio")]
        public decimal Price { get; set; }
        [Column("cantidad inicial")]
        public int Stock { get; set; }
    }
}
