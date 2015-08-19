using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleMediator
{
    public class ChatRoom
    {
        private readonly TextWriter _writer;
        private readonly List<User> _users;
        
        public ChatRoom(TextWriter writer)
        {
            _writer = writer;
            _users = new List<User>();
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void ShowMessage(User sender, string message)
        {
            _writer.WriteLine("{0} [{1}] Sending Message : {2}", DateTime.UtcNow, sender.Name, message);

            _users
                .Where(user => user != sender)
                .ToList()
                .ForEach(user => _writer.WriteLine("{0} [{1}] Receiving Message: {2}", DateTime.UtcNow, sender.Name, message));
        }
    }
}