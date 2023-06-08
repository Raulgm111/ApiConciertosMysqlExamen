using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConciertosMysqlExamen.Models
{
    [Table("categoriaevento")]
    public class CategoriaEvento
    {
        [Key]
        [Column("idcategoria")]
        public int IDCategoria { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
