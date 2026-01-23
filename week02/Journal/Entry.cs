public class Entry
{
    public string _date;
    public string _promptText;
    public string _response;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string GetSaveString()
    {
        return $"{_date}|{_promptText}|{_response}";
    }
}
