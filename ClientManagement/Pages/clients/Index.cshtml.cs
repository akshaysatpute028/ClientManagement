using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ClientManagement.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> clientsList = new List<ClientInfo>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-19LGOJJ2\\SQLEXPRESS;Initial Catalog=clients;Persist Security Info=True;User ID=sa;Password=cdac123;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM client_info";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.created_at = reader.GetDateTime(5).ToString();

                                clientsList.Add(clientInfo);

                                Console.WriteLine("Collection : " + clientsList[0]);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : "+ex.ToString());
            }
        }
    }
    public class ClientInfo
    {
        public string id="";
        public string name="";
        public string email="";
        public string phone="";
        public string address ="";
        public string created_at="";
    }
}
