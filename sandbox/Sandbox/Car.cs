class Car
{
    public Person owner;
    public string model;
    public string make;
    public float milesPerGallon;
    public float gallonCapacity;

    public float TotalRange()
    {
        return gallonCapacity * milesPerGallon;
    }

    public void DisplayData()
    {
        System.Console.WriteLine($"{make}, {model}: total range = {TotalRange()}");
    }

    public Car(string make, string model, int milesPerGallon, int gallonCapacity) {
        this.make = make;
        this.model = model;
        this.milesPerGallon = milesPerGallon;
        this.gallonCapacity = gallonCapacity;
    }
}

