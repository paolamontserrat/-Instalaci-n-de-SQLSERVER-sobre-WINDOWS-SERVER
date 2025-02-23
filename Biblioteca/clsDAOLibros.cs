using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Biblioteca
{
    public class clsDaoLibros
    {
        private string connectionString;

        public clsDaoLibros()
        {
            connectionString = "Server=localhost;Database=Biblioteca;Integrated Security=True;";
        }

        public string AgregarLibro(clsLibro libro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM Libros WHERE ISBN = @ISBN";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    return "El libro ya existe en la base de datos.";
                }

                string query = "INSERT INTO Libros (ISBN, TITULO, NUMERO_EDICION, AÑO_PUBLICACION, AUTORES, PAIS, SINOPSIS, CARRERA, MATERIA) " +
                               "VALUES (@ISBN, @TITULO, @NUMERO_EDICION, @AÑO_PUBLICACION, @AUTORES, @PAIS, @SINOPSIS, @CARRERA, @MATERIA)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                cmd.Parameters.AddWithValue("@TITULO", libro.Titulo);
                cmd.Parameters.AddWithValue("@NUMERO_EDICION", libro.NumeroEdicion);
                cmd.Parameters.AddWithValue("@AÑO_PUBLICACION", libro.AnioPublicacion);
                cmd.Parameters.AddWithValue("@AUTORES", libro.Autores);
                cmd.Parameters.AddWithValue("@PAIS", libro.Pais);
                cmd.Parameters.AddWithValue("@SINOPSIS", libro.Sinopsis);
                cmd.Parameters.AddWithValue("@CARRERA", libro.Carrera);
                cmd.Parameters.AddWithValue("@MATERIA", libro.Materia);

                cmd.ExecuteNonQuery();
                return "Libro guardado exitosamente.";
            }
        }

        public List<clsLibro> ObtenerLibros()
        {
            List<clsLibro> libros = new List<clsLibro>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Libros";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsLibro libro = new clsLibro
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        ISBN = reader["ISBN"].ToString(),
                        Titulo = reader["TITULO"].ToString(),
                        NumeroEdicion = Convert.ToInt32(reader["NUMERO_EDICION"]),
                        AnioPublicacion = Convert.ToInt32(reader["AÑO_PUBLICACION"]),
                        Autores = reader["AUTORES"].ToString(),
                        Pais = reader["PAIS"].ToString(),
                        Sinopsis = reader["SINOPSIS"].ToString(),
                        Carrera = reader["CARRERA"].ToString(),
                        Materia = reader["MATERIA"].ToString()
                    };
                    libros.Add(libro);
                }
            }
            return libros;
        }
    }
}
