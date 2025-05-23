﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    /*
     * Cybersecurity response handler
     * Uses keyword matching to provide cybersecurity advice
     * Maintains a dictionary of trigger words/phrases mapped to responses
     */
    public static class CybersecurityResponder
    {
        /*
         * Dictionary mapping keyword arrays to responses:
         * - Keys: Arrays of trigger words/phrases
         * - Values: Either direct responses or method-generated content
         * Note: First match wins in the lookup process
         */
        private static readonly Dictionary<string[], string> Responses = new Dictionary<string[], string>
        {
            /* Greeting responses */
            { new[] { "hello", "hi", "hey" }, "Hello! How can I help you with cybersecurity today?" },
            
            /* Bot status responses */
            { new[] { "how are you", "how's it going" }, "I'm a bot, always ready to help with cybersecurity matters!" },
            
            /* Purpose explanation */
            { new[] { "purpose", "why are you here" }, "I help you understand cybersecurity fundamentals and stay safe online." },
            
            /* Topic suggestions */
            { new[] { "ask", "questions", "topics" }, "You can ask me about:\n- Password safety\n- Phishing attacks\n- Safe browsing\n- Malware protection" },
            
            /* Dynamic responses (generated by methods below) */
            { new[] { "password", "credentials" }, PasswordTips() },
            { new[] { "phishing", "scam", "email" }, PhishingTips() },
            { new[] { "browsing", "internet", "online" }, BrowsingTips() },
            
            /* Exit command */
            { new[] { "exit", "quit", "bye" }, "Exiting the program..." }
        };

        /*
         * Main response lookup method
         * Parameters:
         *   input - user's query in lowercase
         * Returns:
         *   string - matched response or default help message
         * Behavior:
         *   - Checks input against all keywords
         *   - Returns first matching response found
         *   - Returns default message if no matches
         */
        public static string GetResponse(string input)
        {
            /* Check each keyword group in dictionary */
            foreach (var pair in Responses)
            {
                /* Test each keyword in current group */
                foreach (string keyword in pair.Key)
                {
                    if (input.Contains(keyword))
                        return pair.Value;  /* First match returns immediately */
                }
            }

            /* Fallback response when no keywords match */
            return "I'm not sure I understand. Try asking about:\n- Password safety\n- Phishing\n- Safe browsing\nOr type 'exit' to quit.";
        }

        /*
         * Password security recommendations
         * Returns formatted multi-line string with best practices
         * Includes emoji for visual distinction
         */
        private static string PasswordTips() => @"🔐 Password Safety Tips:
            - Use at least 12 characters
            - Combine letters, numbers, and symbols
            - Never reuse passwords across accounts
            - Use a password manager
            - Enable 2FA
            - Change passwords after breaches";

        /*
         * Phishing awareness guidelines
         * Returns formatted multi-line string with red flags
         * Includes emoji for visual distinction
         */
        private static string PhishingTips() => @"🎣 Phishing Awareness:
            - Verify sender email addresses
            - Don't click suspicious links
            - Watch for threatening language
            - Check for spelling errors
            - Never share info via email
            - Report scams";

        /*
         * Safe browsing practices
         * Returns formatted multi-line string with recommendations
         * Includes emoji for visual distinction
         */
        private static string BrowsingTips() => @"🌐 Safe Browsing:
            - Use HTTPS websites
            - Keep your browser updated
            - Use ad-blockers
            - Avoid public Wi-Fi for sensitive tasks
            - Use a VPN";
    }
}
