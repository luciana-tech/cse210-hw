using System;

class Program
{
    static void Main(string[] args)
    {
     Job job1 = new Job();
     job1._jobTitle = "Software Developer";
     job1._company = "Microsoft";
     job1._startYear = 2019;
     job1._endYear = 2021;

     Job job2 = new Job();
     job2._jobTitle = "Software Architect";
     job2._company = "Apple";
     job2._startYear = 2022;
     job2._endYear = 2024;
     
     Resume myResume = new Resume();
     myResume._personName = "Luciana Oliveira";
     myResume._jobs.Add(job1);
     myResume._jobs.Add(job2);

     myResume.Display();

    }
    
}
