using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace crud.Models
{
    public class EmpRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["dbcon"].ToString();
        public void AddEmployee(EmpModel obj)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("proc_add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

         public List<EmpModel> GetAllEmployees()
          {
              SqlConnection con = new SqlConnection(constr);
              List<EmpModel> obj = new List<EmpModel>();
              SqlCommand com = new SqlCommand("proc_view", con);
              com.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                obj.Add(new EmpModel
                {
                    Empid = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    City = Convert.ToString(dr["City"]),
                    Address = Convert.ToString(dr["Address"])
                });
            }
            return obj;

         }

        public void UpdateEmployee(EmpModel obj)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("proc_update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteEmployee(int Id)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("proc_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    }
}