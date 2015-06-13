using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarikeRest.Models;

namespace WarikeRest.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [ActionName("GetUserByID")]
        public User Get(int id)
        {
            //return listEmp.First(e => e.ID == id);
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=(local);Initial Catalog=VamosPalHuarique;Integrated Security=True;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select Id,Usuario,Nombre,FecNacimiento from usuario where Id=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            User usr = null;
            while (reader.Read())
            {
                usr = new User();
                usr.Id = Convert.ToInt32(reader.GetValue(0));
                usr.Codigo= Convert.ToString(reader.GetValue(1).ToString());
                usr.Nombre = Convert.ToString(reader.GetValue(2).ToString());
                usr.Fecha = Convert.ToString(reader.GetValue(3).ToString());
            }
            return usr;
            myConnection.Close();
        }

        

        [HttpPost]
        [ActionName("AddUser")]
        public void AddUser(User usr)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=(local);Initial Catalog=VamosPalHuarique;Integrated Security=True;";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO usuario (Usuario,Clave,Nombre,FecNacimiento) Values (@Usuario,@Clave,@Nombre,@FecNacimiento)";
            sqlCmd.Connection = myConnection;


            sqlCmd.Parameters.AddWithValue("@Usuario", usr.Codigo);
            sqlCmd.Parameters.AddWithValue("@Clave", usr.Clave);
            sqlCmd.Parameters.AddWithValue("@Nombre", usr.Nombre);
            sqlCmd.Parameters.AddWithValue("@FecNacimiento", usr.Fecha);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }


    }
}
