using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
            message = TextHandler.HandleMessage(message);

            await _context.Messages.AddAsync(new Message()
            {
                Name = user,
                MessageText = message,
                ReceiveTime = DateTime.Now.ToString()
            });
            _context.SaveChanges();

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task NewUser(string userName)
        {
            var messages = _context
                .Messages
                .Select(x => new { x.Name, x.MessageText })
                .Take(100)
                .ToList();

            await Clients.Caller.SendAsync("DownloadOtherMessages", Newtonsoft.Json.JsonConvert.SerializeObject(messages));
            await Clients.All.SendAsync("GreetingMessage", userName);
        }

    }

    public class TextHandler
    {
        private static readonly List<string> _badWords = new List<string>
        {
            "бля",
            "блять",
            "блядь",
            "блядина",
            "блядский",
            "блядская",
            "блядское",
            "выблядок",
            "выебон",
            "выёбывается",
            "выебывается",
            "выёбываешься",
            "выебываешься",
            "выёбываются",
            "выебываются",
            "выёбываюсь",
            "выебываюсь",
            "доебался",
            "ебало",
            "ебать",
            "ёб",
            "ебанул",
            "ебанула",
            "ебанулся",
            "ебанулась",
            "ебанешься",
            "ебаный",
            "ёбаный",
            "ебаный",
            "ебанный",
            "ебашит",
            "заебал",
            "заебала",
            "заебало",
            "заебись",
            "заеб",
            "выебнулся",
            "выебнулась",
            "наебнулся",
            "наебнулась",
            "наебнуться",
            "наеб",
            "наебка",
            "наебал",
            "наебала",
            "объебал",
            "пизда",
            "пёзды",
            "пёзда",
            "песда",
            "пидор",
            "пиздабол",
            "пиздатый",
            "пиздец",
            "пиздецкий",
            "пиздоблошка",
            "поебень",
            "распиздяй",
            "пиздил",
            "уебался",
            "уебалось",
            "уебаться",
            "уебище",
            "уёбищенски",
            "уебищенски",
            "хуево",
            "хуёво",
            "хуйня",
            "шароёбится",
            "хуй",
            "сука",
            "хер",
            "херня",
            "нахуй", 
            "гавно",
            "говно"
        };
        public static string HandleMessage(string userMessage)
        {
            HtmlEncoder.Default.Encode(userMessage);

            string[] message = userMessage.ToLower().Split(' ');
            userMessage = "";
            
            for (int i = 0; i < message.Length; i++)
            {
                if (_badWords.Any(phrase => message[i].Contains(phrase)))
                {
                    string badPhrase = "";
                    for (int j = 0; j < message[i].Length; j++)
                    {
                        badPhrase += "*";
                    }

                    message[i] = badPhrase;
                }

                userMessage += message[i] + " ";
            }
            
            return userMessage;
        }
    }
}