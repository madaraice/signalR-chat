using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Chat.Models;
using Chat.Tools;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class RegistrationHub : Hub
    {
        private readonly UserContext _context;

        public RegistrationHub(UserContext context)
        {
            _context = context;
        }
        public async Task Registration(string userName, string password, string againPassword)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName)
                || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrEmpty(againPassword) || string.IsNullOrWhiteSpace(againPassword))
            {
                await Clients.Caller.SendAsync("EmptySpace");
                return;
            }

            var user = _context.Users
                .FirstOrDefault(x => x.Name == HtmlEncoder.Default.Encode(userName));

            if (user != null)
            {
                await Clients.Caller.SendAsync("ChangeOtherName");
                return;
            }

            if (password != againPassword)
            {
                await Clients.Caller.SendAsync("ChangePassword");
                return;
            }

            _context.Users.Add(new User()
            {
                Name = userName,
                Password = PasswordEncryption.Encrypt(password) 
            });
            _context.SaveChanges();
            await Clients.Caller.SendAsync("RegistrationComplete");
        }
    }
}
