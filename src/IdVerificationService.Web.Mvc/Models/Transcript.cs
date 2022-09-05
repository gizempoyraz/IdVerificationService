using Microsoft.Data.SqlClient;

namespace IdVerificationService.Web.Models
{
    public class Transcript
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        void GetData()
        {
            string connectionString = "Data Source=localhost/SQLEXPRESS; Initital Catalog=IdVerificationServiceDb; Integrated Security =true";
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();

        string sqlQuery = "select Email, PhoneNumber from Persons where CitizenId=1";
        SqlCommand cmd = new SqlCommand(sqlQuery, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Email = dr["Email"].ToString();
            PhoneNumber = dr["PhoneNumber"].ToString();
    }
    con.Close();
    }
}
}
    

