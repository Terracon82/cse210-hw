class Assignment
{
    private string _studentName;
    public string StudentName { get { return _studentName; } }
    private string _topic;
    public string Topic { get { return _topic; } }

    protected Assignment(string studentName, string topic)
    {
        this._studentName = studentName;
        this._topic = topic;
    }

    public string GetSummary()
    {
        return
        $"""
        Student Name: {_studentName}
        Topic: {_topic}
        """;
    }
}