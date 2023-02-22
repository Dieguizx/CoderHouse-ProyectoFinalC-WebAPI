using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public List<Producto> TraerProductosVendidos(long idUsuario)
        {
            return ManejadorProductoVendido.ObtenerProductosVendidos(idUsuario);
        }
    }
}
