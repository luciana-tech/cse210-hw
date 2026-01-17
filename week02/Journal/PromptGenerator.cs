using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Adicione esta linha: lista de prompts para o método GetRandomPrompt()
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    
    // Gets prompts by category number
    public string GetRandomPromptByCategoryNumber(int categoryNumber)
    {
        // Creates lists for each category
        List<string>[] categories = new List<string>[7];
        
        // CATEGORY 1: FAITH & DISCIPLESHIP
        categories[0] = new List<string>
        {
            "How did I overcome my natural inclination to do my own will instead of God's will today?",
            "Have I refrained from sharp or unkind comments when frustrated today?",
            "When did I choose patience over irritation in a challenging situation today?",
            "How did I demonstrate Christlike love when it was difficult today?",
            "In what moment did I practice humility instead of pride today?",
            "When did I choose forgiveness over holding a grudge today?",
            "Where did I see God's hand guiding my decisions today?",
            "How did I turn to prayer instead of worry in a difficult moment today?",
            "When did I choose service over self-interest today?",
            "How did I share my faith through actions rather than words today?",
            "When did I practice gratitude as an act of worship today?",
            "How did I align my thoughts with God's truth in a moment of doubt today?",
            "Did I resist the temptation to complain and instead give thanks today?",
            "Did I choose to bless someone who irritated me today?",
            "Did I speak truth with love instead of remaining silent or being harsh today?",
            "Did I practice self-control in my thoughts, words, or actions today?",
            "Did I prioritize spiritual growth over worldly distractions today?",
            "Did I respond to criticism with grace rather than defensiveness today?",
        };
        
        // CATEGORY 2: CHALLENGES & GROWTH
        categories[1] = new List<string>
        {
            "What was the most challenging part of my day?",
            "How could I have made today better?",
            "What did I learn today?",
            "What obstacle did I overcome today?",
            "When did I practice patience today?",
            "What fear did I confront today?",  
        };
        
        // CATEGORY 3: GRATITUDE & POSITIVITY   
        categories[2] = new List<string>
        {
            "What am I grateful for today?",
            "What made me smile today?",
            "What was a small victory I had today?",
            "Who or what brought me joy today?",
            "What beautiful moment did I witness today?",
            "What simple pleasure did I enjoy today?",
        };
        
        // CATEGORY 4: SELF-CARE & WELL-BEING
        categories[3] = new List<string>
        {
            "How did I take care of myself today?",
            "What did I do for my physical health today?",
            "How did I nurture my mental well-being today?",
            "When did I feel most at peace today?",
            "What boundary did I set for myself today?",
            "How did I practice self-compassion today?",
        };
        
        // CATEGORY 5: GOALS & ACHIEVEMENTS
        categories[4] = new List<string>
        {
            "What goal did I work toward today?",
            "What progress did I make on a long-term goal?",
            "What accomplishment am I proud of today?",
            "How did I move closer to my dreams today?",
            "What skill did I practice or improve today?",
            "What step did I take toward personal growth today?",
        };
        
        // CATEGORY 6: RELATIONSHIPS & SERVICE
        categories[5] = new List<string>
        {
            "Who did I help today and how?",
            "How did I show kindness to someone today?",
            "Who inspired me today and why?",
            "What meaningful conversation did I have today?",
            "How did I connect with a loved one today?",
            "What act of service did I perform today?",
        };
        
        // CATEGORY 7: REFLECTION & FUTURE
        categories[6] = new List<string>
        {
            "What would I tell my future self about today?",
            "What lesson will I carry forward from today?",
            "How did today shape my perspective?",
            "What from today do I want to remember in one year?",
            "How did today prepare me for tomorrow?",
            "What insight did I gain about myself today?"  
        };
        
        // Check if category number is valid
        if (categoryNumber >= 1 && categoryNumber <= 7)
        {
            List<string> categoryPrompts = categories[categoryNumber - 1];
            Random random = new Random();
            return categoryPrompts[random.Next(categoryPrompts.Count)];
        }
        
        // If category is invalid, returns random prompt
        return GetRandomPrompt();
    }
    
    // Method: gets category names
    public string GetCategoryName(int categoryNumber)
    {
        string[] categoryNames = {
            "Faith & Discipleship",
            "Challenges & Growth",
            "Gratitude & Positivity",
            "Self-Care & Well-Being",
            "Goals & Achievements",
            "Relationships & Service",
            "Reflection & Future"
        };
        
        if (categoryNumber >= 1 && categoryNumber <= 7)
        {
            return categoryNames[categoryNumber - 1];
        }
        
        return "Random";
    }
    
    // Method: gets random prompt from all prompts
    public string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
}