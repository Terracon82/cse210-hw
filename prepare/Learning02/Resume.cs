public class Resume
{
    public string _name;
    public List<Job> _jobs = new();

    public void Display()
    {
        System.Console.WriteLine($"Name: {_name}\nJobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
    
}