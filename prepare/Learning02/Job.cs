public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display() 
    {
        System.Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

    public Job(string _company
    , string _jobTitle
    , int _startYear
    , int _endYear)
    {
        this._company = _company;
        this._jobTitle = _jobTitle;
        this._startYear = _startYear;
        this._endYear = _endYear;
    }


}