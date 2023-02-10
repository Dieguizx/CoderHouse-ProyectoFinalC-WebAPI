using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalWebAPI
{
    public class ManejadorVentas
    {
        // Cadena de Conexión
        public static string cadenaConexion = "Data Source=DESKTOP-7QBII56\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True";

        // OBTENER VENTA POR ID
        public static Venta ObtenerVenta(long id)
        {
            Venta venta = new Venta();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE Id = @id", conexion);
                comando.Parameters.AddWithValue("@id", id);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    venta.Id = reader.GetInt64(0);
                    venta.Comentarios = reader.GetString(1);
                    venta.IdUsuario = reader.GetInt64(2);
                }
            }
            return venta;
        }

        // OBTENER LISTA VENTAS RECIBE ID USUARIO
        public static List<Venta> ObtenerVentas(long idUsuario)
        {
            List<long> ventaRealizada = new List<long>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT Id FROM Venta " +
                    " WHERE IdUsuario = @idUsuario", conexion);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ventaRealizada.Add(reader.GetInt64(0));
                    }
                }
            }
            List<Venta> listaVentasRealizadas = new List<Venta>();
            foreach (var id in ventaRealizada)
            {
                Venta ventaTempporal = ObtenerVenta(id);
                listaVentasRealizadas.Add(ventaTempporal);
            }
            return listaVentasRealizadas;
        }
    }
}
