using System.ComponentModel.DataAnnotations;
namespace web_api_1.Models{
    public class Producto{
        [Key]
        public int id_producto{get; set;}
        public string Nombre{get; set;}
        public string Ruta{get; set;}
        public string id_marca{get; set;}
        public string descripcion{get; set;}
        public string precio_costo{get; set;}
        public string precio_venta{get; set;}
        public string existencia{get; set;}
        public string fecha_ingreso{get; set;}
    }
}