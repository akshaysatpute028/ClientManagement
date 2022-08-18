using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientManagement.Pages.clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> clientsList = new List<ClientInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "";
            }
            catch
            {

            }
        }
    }
    public class ClientInfo
    {
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
    }
}
