using System;

public class PromptGenerator
{
    private static readonly string[] _prompts = 
    {
        "What are you thankful for today?",
        "What did you learn today?",
        "What was the best part of your day today?",
        "What was the most challenging part of your day today?",
        "What are you looking forward to tomorrow?",
        "What are your goals for the week?",
        "What are your goals for the month?",
        "What are your goals for the year?",
        "What is something you accomplished recently that you are proud of?",
        "What is something you would like to improve about yourself?",
        "What is something you are grateful for in your life?",
        "What is something you are looking forward to in the future?",
        "What is something you are passionate about?",
        "What is something you are excited to learn more about?",
        "What is something you are looking forward to experiencing?",
        "What is something you are proud of?",
        "What is something you are thankful for?",
        "What is something you are happy about?",
        "What is something you are excited about?",
        "What is something you are hopeful for?"
    };
    private static readonly Random _random = new Random();

    public string GeneratePrompt()
    {
        return _prompts[_random.Next(0, _prompts.Length)];
    }
}