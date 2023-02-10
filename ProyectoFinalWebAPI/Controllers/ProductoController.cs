using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("/producto/{descripciones}")]
        public Producto ObtenerProductoByDescripciones(string descripciones)
        {
            Producto producto = ManejadorProducto.ObtenerProducto(descripciones);
            return producto;
        }

        [HttpGet("/productos")]
        public List<Producto> ObtenerProductos()
        {
            return ManejadorProducto.ObtenerProductos();
        }

    }
}
