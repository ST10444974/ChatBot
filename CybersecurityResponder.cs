using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    public static class CybersecurityResponder
    {
        private static readonly Dictionary<string[], string> Responses = new Dictionary<string[], string>
    {
        { new[] { "hello", "hi", "hey" }, "Hello! How can I help you with cybersecurity today?" },
        { new[] { "how are you", "how's it going" }, "I'm a bot, always ready to help with cybersecurity matters!" },
        { new[] { "purpose", "why are you here" }, "I help you understand cybersecurity fundamentals and stay safe online." },
        { new[] { "ask", "questions", "topics" }, "You can ask me about:\n- Password safety\n- Phishing attacks\n- Safe browsing\n- Malware protection" },
        { new[] { "password", "credentials" }, PasswordTips() },
        { new[] { "phishing", "scam", "email" }, PhishingTips() },
        { new[] { "browsing", "internet", "online" }, BrowsingTips() },
        { new[] { "exit", "quit", "bye" }, "Exiting the program..." }
    };

        public static string GetResponse(string input)
        {
            foreach (var pair in Responses)
            {
                foreach (string keyword in pair.Key)
                {
                    if (input.Contains(keyword))
                        return pair.Value;
                }
            }

            return "I'm not sure I understand. Try asking about:\n- Password safety\n- Phishing\n- Safe browsing\nOr type 'exit' to quit.";
        }

        private static string PasswordTips() => @"🔐 Password Safety Tips:
- Use at least 12 characters
- Combine letters, numbers, and symbols
- Never reuse passwords across accounts
- Use a password manager
- Enable 2FA
- Change passwords after breaches";

        private static string PhishingTips() => @"🎣 Phishing Awareness:
- Verify sender email addresses
- Don’t click suspicious links
- Watch for threatening language
- Check for spelling errors
- Never share info via email
- Report scams";

        private static string BrowsingTips() => @"🌐 Safe Browsing:
- Use HTTPS websites
- Keep your browser updated
- Use ad-blockers
- Avoid public Wi-Fi for sensitive tasks
- Use a VPN";
    }
}
