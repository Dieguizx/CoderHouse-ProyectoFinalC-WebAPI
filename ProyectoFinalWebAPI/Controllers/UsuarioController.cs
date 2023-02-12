using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalWebAPI;

namespace ProyectoFinalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPut]
        public void Actualizar([FromBody] Usuario usuario)
        {
            ManejadorUsuario.UpdateUsuario(usuario);
        }
    }
}