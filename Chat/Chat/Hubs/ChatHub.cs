using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Chat.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly Context _context;

        public ChatHub(Context context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            var msg = HtmlEncoder.Default.Encode(message);
            
            await _context.Messages.AddAsync(new Message()
            {
                Name = user,
                MessageText = msg,
                ReceiveTime = DateTime.Now.ToString()
            });
            _context.SaveChanges();

            await Clients.All.SendAsync("ReceiveMessage", user, msg);
        }
        
        public async Task NewUser(string user)
        {
            var messages = _context
                .Messages
                .Select(x => new { x.Name, x.MessageText})
                .Take(100)
                .ToList();

            await Clients.Caller.SendAsync("DownloadOtherMessages", Newtonsoft.Json.JsonConvert.SerializeObject(messages));
            await Clients.All.SendAsync("GreetingMessage", user);
        }
    }
}