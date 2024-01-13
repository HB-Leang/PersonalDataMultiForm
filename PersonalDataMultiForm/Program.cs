namespace PersonalDataMultiForm;

public delegate void PersonEventHandler(object? sender, Person p);
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
    public static List<Person> people = new();
    public static List<Person> _editing = new();
}
