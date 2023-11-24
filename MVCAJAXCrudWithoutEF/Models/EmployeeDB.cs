using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCAJAXCrudWithoutEF.Models
{
    
    public class EmployeeDB
    {
        string CS = ConfigurationManager.ConnectionStrings["EmployeeEntities"].ConnectionString;

        public List<Employee> ListAll()
        {
            List<Employee> list = new List<Employee>();
            using (SqlConnection con=new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AllCurd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "Get");
                SqlDataReader rdr=cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Employee { 
                        EmployeeID =Convert.ToInt32(rdr["EmployeeID"]),
                        Name = rdr["Name"].ToString(),
                        Age =Convert.ToInt32(rdr["Age"]),
                        State = rdr["state"].ToString(),
                        Country = rdr["Country"].ToString(),
                    });
                }
            }
            return list;
        }

        //Method for Adding an Employee
        public int Add(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AllCurd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@employeeid", emp.EmployeeID);
                com.Parameters.AddWithValue("@name", emp.Name);
                com.Parameters.AddWithValue("@age", emp.Age);
                com.Parameters.AddWithValue("@state", emp.State);
                com.Parameters.AddWithValue("@country", emp.Country);
                com.Parameters.AddWithValue("@flag", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Employee record
        public int Update(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AllCurd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@flag", "Update");
                com.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Age", emp.Age);
                com.Parameters.AddWithValue("@State", emp.State);
                com.Parameters.AddWithValue("@Country", emp.Country);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AllCurd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@flag", "Delete");
                com.Parameters.AddWithValue("@EmployeeID", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

    }
}