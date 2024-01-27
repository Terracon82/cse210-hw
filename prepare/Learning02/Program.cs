using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");

        Job job1 = new(
            _company: "Microsoft"
            , _jobTitle: "Software Enfineer"
            , _startYear: 2019
            , _endYear: 2022
            );

        Job job2 = new(
            _company: "Apple"
            , _jobTitle: "Manager"
            , _startYear: 2022
            , _endYear: 2023
            );
        // job1._jobTitle = "Software Enfineer";

        Resume resume1 = new();
        resume1._name = "Allision Rose";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);


        resume1.Display();
    }
}