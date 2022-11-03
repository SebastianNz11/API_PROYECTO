using Microsoft.EntityFrameworkCore;
namespace web_api_1.Models{
    class Conexion : DbContext{
        public Conexion(DbContextOptions<Conexion> options) : base(options){}
        public DbSet<Producto> producto{get; set;}
    }

    class Conectar{
        private const string cadenaConexion = "server=localhost;port=3306;database=pruebap;userid=root;pwd=";
        public static Conexion Create(){
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion(constructor.Options);
            return cn;
        }
    }
}