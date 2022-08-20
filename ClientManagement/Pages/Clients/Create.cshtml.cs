using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ClientManagement.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo=new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            if(clientInfo.name.Length==0 || clientInfo.email.Length == 0 || clientInfo.phone.Length == 0 || clientInfo.address.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }
            
            //Save client into databasetry

            try
            {
                string connectionString = "Data Source=LAPTOP-19LGOJJ2\\SQLEXPRESS;Initial Catalog=clients;Persist Security Info=True;User ID=sa;Password=cdac123;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO client_info " +
                        "(name,email,phone,address) VALUES "+
                        "(@name,@email,@phone,@address);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name",clientInfo.name);
                        command.Parameters.AddWithValue("@email",clientInfo.email);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.Parameters.AddWithValue("@address", clientInfo.address);
                        
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch(Exception ex)
            {
                errorMessage=ex.Message;
                return;
            }

            clientInfo.name = ""; clientInfo.email = ""; clientInfo.phone = ""; clientInfo.address = "";
            successMessage = "New client added successfully";

            Response.Redirect("/Clients/Index");
        }
    }
}
