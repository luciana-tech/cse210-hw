using System;

public class MathAssignment : Assignment
{
    private string _textbookSection = "";
     private string _problems = "";

public MathAssignment(string studentName, string topic) : base(studentName, topic)
    {
        
    }
public MathAssignment() : base()    
    {
        
    }    

    public string GetTextbookSection()
    {
        return _textbookSection;
    }
    
    public string GetProblems()
    {
        return _problems;
    }

    public void SetProblems(string problems)
    {
        _problems = problems;
    }
    public void SetTextbookSection(string textbookSection)
    {
        _textbookSection = textbookSection;
    }
    public string GetHomeworkList()
    {
        return $"{GetSummary()} \nSection {_textbookSection}, problems {_problems}";
    }
    
   
}