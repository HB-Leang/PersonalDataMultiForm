namespace PersonalDataMultiForm;

public class Person
{
    private static int count = 0;
    public int No { get; init; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public byte Age { get; set; }
    public Person(byte a, string n = "", string g = "")
    {
        Name = n;Gender = g; Age = a; No = ++count;
    }
}