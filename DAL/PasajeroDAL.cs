using DEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class PasajeroDAL
    {
        public readonly StringBuilder output = new StringBuilder();
        public void Insert(Pasajero pasajero, string clase)
        {
            output.Clear();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                try
                {
                    cnx.Open();
                    string sqlQuery = "INSERT INTO ";
                    if (!string.IsNullOrEmpty(clase))
                    {
                        sqlQuery += clase + " (Nombre, Cedula, Telefono, Clase, Asiento)" +
                        "VALUES (@Nombre, @Cedula, @Telefono, @Clase, @Asiento)";
                    }
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", pasajero.Nombre);
                        cmd.Parameters.AddWithValue("@Cedula", pasajero.Cedula);
                        cmd.Parameters.AddWithValue("@Telefono", pasajero.Telefono);
                        cmd.Parameters.AddWithValue("@Clase", pasajero.Clase);
                        cmd.Parameters.AddWithValue("@Asiento", pasajero.Asiento);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    output.Append("Error al insertar datos: " + ex.Message);
                }

            }
        }

        public List<Pasajero> GetAll(string clase)
        {
            List<Pasajero> pasajeros = new List<Pasajero>();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                cnx.Open();

                //const string sqlQuery = "SELECT * FROM pasajeros ORDER BY asiento ASC";
                string sqlQuery = "SELECT * FROM ";

                if (!string.IsNullOrEmpty(clase))
                {
                    sqlQuery += clase + " ORDER BY asiento ASC";
                }
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Pasajero pasajero = new Pasajero()
                        {
                            Nombre = Convert.ToString(dataReader["nombre"]),
                            Cedula = Convert.ToInt64(dataReader["cedula"]),
                            Telefono = Convert.ToString(dataReader["telefono"]),
                            Clase = Convert.ToString(dataReader["clase"]),
                            Asiento = Convert.ToInt32(dataReader["asiento"])
                        };
                        pasajeros.Add(pasajero);
                    }
                }
            }
            return pasajeros;
        }

        public Pasajero GetByid(long cedula, string clase)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                cnx.Open();
                string sqlGetByID = "SELECT * FROM ";
                if (!string.IsNullOrEmpty(clase))
                {
                    sqlGetByID += clase + " WHERE cedula = @id";
                }
                using (SqlCommand cmd = new SqlCommand(sqlGetByID, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", cedula);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Pasajero pasajero = new Pasajero()
                        {
                            Nombre = Convert.ToString(dataReader["nombre"]),
                            Cedula = Convert.ToInt64(dataReader["cedula"]),
                            Telefono = Convert.ToString(dataReader["telefono"]),
                            Clase = Convert.ToString(dataReader["clase"]),
                            Asiento = Convert.ToInt32(dataReader["asiento"])
                        };
                        return pasajero;
                    }
                }
            }
            return null;
        }

        public void Update(Pasajero pasajero)
        {
            output.Clear();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                try
                {
                    cnx.Open();
                    const string sqlQuery =
                        "UPDATE pasajeros SET nombre = @Nombre, telefono = @Telefono, clase = @Clase, asiento = @Asiento " +
                        "WHERE cedula = @Cedula";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", pasajero.Nombre);
                        cmd.Parameters.AddWithValue("@Cedula", pasajero.Cedula);
                        cmd.Parameters.AddWithValue("@Telefono", pasajero.Telefono);
                        cmd.Parameters.AddWithValue("@Clase", pasajero.Clase);
                        cmd.Parameters.AddWithValue("@Asiento", pasajero.Asiento);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    output.Append("Error al insertar datos: " + ex.Message);
                }
            }
        }
        public void Delete(long cedula, string clase)
        {
            output.Clear();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                try
                {
                    cnx.Open();
                    //string sqlQuery = "DELETE FROM pasajeros WHERE cedula = @cedula";
                    string sqlQuery = "DELETE FROM ";
                    if (!string.IsNullOrEmpty(clase))
                    {
                        sqlQuery += clase + " WHERE cedula = @cedula";
                    }
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@cedula", cedula);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    output.Append("Error al insertar datos: " + ex.Message);
                }
            }
        }
    }
}
