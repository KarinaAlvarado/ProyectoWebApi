using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ProyectoWebApi.Models;

namespace ProyectoWebApi.Data
{
    public class AlumnoDatacs
    {
        public static bool Registrar(Alumnos oAlumnos)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oAlumnos.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", oAlumnos.Apellidos);
                cmd.Parameters.AddWithValue("@correo", oAlumnos.Correo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Alumnos oAlumnos)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idalumno", oAlumnos.IdAlumno);
                cmd.Parameters.AddWithValue("@nombre", oAlumnos.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", oAlumnos.Apellidos);
                cmd.Parameters.AddWithValue("@correo", oAlumnos.Correo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Alumnos> Listar()
        {
            List<Alumnos> oListaUsuario = new List<Alumnos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Alumnos()
                            {
                                IdAlumno = Convert.ToInt32(dr["IdAlumno"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Correo = dr["Correo"].ToString(),
                               
                            });
                        }

                    }



                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static Alumnos Obtener(int idalumno)
        {
            Alumnos oUsuario = new Alumnos();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idalumno", idalumno);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oUsuario = new Alumnos()
                            {
                                IdAlumno = Convert.ToInt32(dr["IdAlumno"]),  
                                Nombre = dr["Nombre"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Correo = dr["Correo"].ToString(),
                            };
                        }

                    }



                    return oUsuario;
                }
                catch (Exception ex)
                {
                    return oUsuario;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idalumno", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}