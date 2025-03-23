using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticaWebApiSonia.Model
{
    public class ProductCategory
    {
        [Table("ProductCategory", Schema = "Production")]
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ProductCategoryID { get; set; }

            [Required]
            [Column(TypeName = "dbo.Name")]
            public string Name { get; set; }

            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public Guid RowGuid { get; set; } = Guid.NewGuid();

            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}

