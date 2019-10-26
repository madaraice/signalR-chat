using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Models;
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
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName)
                && !string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password)
                && !string.IsNullOrEmpty(againPassword) && !string.IsNullOrWhiteSpace(againPassword))
            {
                //TODO запилить проверку введенных данных пользователем
                var user = _context.Users
                    .FirstOrDefault(x => x.Name == userName);

                if (user == null)
                {
                    if (password == againPassword)
                    {
                        _context.Users.Add(new User()
                        {
                            Name = userName,
                            //TODO добавить шифрование пароля
                            Password = password
                        });
                        _context.SaveChanges();
                    }
                    else
                    {
                        await Clients.Caller.SendAsync("Password != AgainPassword");
                    }
                }
                else
                {
                    await Clients.Caller.SendAsync("ChangeOtherName");
                }
            }
            else
            {
                await Clients.Caller.SendAsync("EmptySpace");
            }
        }
    }
}
