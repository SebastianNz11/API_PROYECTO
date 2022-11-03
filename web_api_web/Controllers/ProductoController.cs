using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using web_api_1.Models;
namespace web_api_1.Controllers{
    [Route("api/[controller]")]
    public class ProductoController : Controller{
        private Conexion dbConexion;
        public ProductoController(){
            dbConexion = Conectar.Create();
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.producto.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult>Get(int id){
            var producto = await dbConexion.producto.FindAsync(id);
            if (producto != null)
            {
                return Ok(producto);
            }else
            {
                return NotFound();
            } 
        }

        [HttpPost]
        public async Task<ActionResult>Post([FromBody] Producto producto){
            if (ModelState.IsValid)
            {
                dbConexion.producto.Add(producto);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else
            {
                return BadRequest();
            }
        }

        public async Task<ActionResult> Put([FromBody] Producto producto){
            var v_producto = dbConexion.producto.SingleOrDefault(a => a.id_producto == producto.id_producto);
            if (v_producto != null && ModelState.IsValid){
               dbConexion.Entry(v_producto).CurrentValues.SetValues(producto); 
               await dbConexion.SaveChangesAsync();
               return Ok();
            }else
            {
               return BadRequest(); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id){
            var producto = dbConexion.producto.SingleOrDefault(a => a.id_producto == id);
            if (producto != null)
            {
                dbConexion.producto.Remove(producto);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else
            {
                return BadRequest();
            }
        }
    }
}
