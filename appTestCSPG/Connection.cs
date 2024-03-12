using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace appTestCSPG
{
  internal class Connection
  {
    static NpgsqlConnection cnx; 
    private static void Connect()
    {
      try
      {
        cnx=new NpgsqlConnection();
        cnx.ConnectionString = "Server=127.0.0.1;Port=5432;Database=test;User Id=fime;Password=fime;";
        cnx.Open();
      }
      catch (Exception ex)
      {

        MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
      }


    }
    private static void Disconnect()
    {
      try
      {
        if (cnx.State == ConnectionState.Open)
        {
          cnx.Close();
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show("Error al desconectar de la base de datos: " + ex.Message);
      }
    }
    //'Create a method to excecute a Selection query
    public static DataTable SelectQuery(string query)
    {
      DataTable dt = new DataTable();
      try
      {
        Connect();
        NpgsqlCommand cmd = new NpgsqlCommand(query, cnx);
        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        da.Fill(dt);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);

      }
      finally
      {
        Disconnect();
      }
        return dt;
    }


  }
}
