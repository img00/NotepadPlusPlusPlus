
using System;

namespace NotepadPlusPlusPlus.Model
{
    public class Message
    {
        public string Username { get; }
        public string Content { get; }
        public DateTime Timestamp { get; } = DateTime.Now;

        public Message(string username, string content)
        {
            Username = username;
            Content = content;
        }

        public override string? ToString()
        {
            return $"<{Username}> {Content}{Environment.NewLine}";
        }
    }
}
