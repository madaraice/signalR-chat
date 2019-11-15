using System.Threading.Tasks;
using Chat.Models;
using Chat.Tools;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Chat.Hubs
{
    public class AuthHub : Hub
    {
        private readonly Context _context;

        public AuthHub(Context context)
        {
            _context = context;
        }

        public async Task Auth(string userName, string password)
        {
            var user = await _context
                .Users
                .FirstOrDefaultAsync(x => x.Name == userName && x.Password == PasswordEncryption.Encrypt(password));

            if (user == null)
            {
                await Clients.Caller.SendAsync("ErrorAuth");
            }
            else
            {
                await Clients.Caller.SendAsync("AccessAuth", userName);
            }
        }
    }
}
