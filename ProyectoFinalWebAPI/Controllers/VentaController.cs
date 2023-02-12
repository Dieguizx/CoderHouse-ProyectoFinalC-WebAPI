using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ProyectoFinalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("{idusuario}")]
        public void CrearVenta(List<Producto> productos, long idUsuario)
        {
            ManejadorVentas.InsertarVenta(productos, idUsuario);
        }
    }
}
