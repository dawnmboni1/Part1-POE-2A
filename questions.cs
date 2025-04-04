using System;
using System.Collections.Generic;

namespace WavPlayer
{
    public static class QuestionsAndResponses
    {
        // Dictionary to hold keyword groups and corresponding responses
        public static readonly (string[] Keywords, string Response)[] Responses = new (string[], string)[]
        {
            (new[] { "how", "are", "you" }, "I'm just a program, but I'm here to assist you!"),
            (new[] { "purpose", "why", "exist" }, "My purpose is to help you learn about cybersecurity awareness."),
            (new[] { "questions", "can", "ask", "about" }, "You can ask me general questions about cybersecurity and how to stay safe online."),
            (new[] { "cybersecurity", "define", "what" }, "Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks."),
            (new[] { "safe", "stay", "online" }, "To stay safe online, use strong passwords, avoid clicking on suspicious links, and keep your software up to date."),
            (new[] { "phishing", "explain", "what" }, "Phishing is a type of social engineering attack used to steal user data by pretending to be a trustworthy entity.")
        };
    }
}
