using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatBot
{
    public class ConversationContext
    {
        public string CurrentTopic { get; set; }
        public bool AwaitingConfirmation { get; set; }
        public int FollowUpCount { get; set; }

        public Dictionary<string, string> Memory { get; } = new();
    }
}
