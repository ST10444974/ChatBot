using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// References used in this to help in this assignment:
// 1. National Institute of Standards and Technology (NIST) (2017) NIST Special Publication 800-63B: Digital Identity Guidelines. Available at: https://pages.nist.gov/800-63-3/sp800-63b.html (Accessed: 20 May 2025).
// 2. OWASP Foundation (2025) OWASP Top Ten Web Application Security Risks. Available at: https://owasp.org/www-project-top-ten/ (Accessed: 20 May 2025).
// 3. Microsoft (2024) Random Class (System). Available at: https://learn.microsoft.com/dotnet/api/system.random (Accessed: 24 May 2025).
// 4. Microsoft (2024) Regex Class (System.Text.RegularExpressions). Available at: https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex (Accessed: 24 May 2025).
// 5. Wikipedia contributors (2025) “Phishing,” Wikipedia, The Free Encyclopedia. Available at: https://en.wikipedia.org/wiki/Phishing (Accessed: 24 May 2025).
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
