public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry()
    {
        //get prompts from the Promptgenerator and 
        // add entries to the _entries list with the help of the Entry class
        string date = DateTime.Now.ToString("dd-MM-yyyy");

        PromptGenerator promptGenerator = new PromptGenerator();
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine("Your response: ");
        string response = Console.ReadLine();

        _entries.Add(new Entry(date, prompt, response));
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayEntries()
    {
        //Displays all added entries if available.
        // if not, informs the user that there are no entries and encourages 
        // the user to keep a journal.

        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal written yet. Please, write a journal now.");
            return;
        }
        
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        // save journal as a file
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }
        // Make sure all entries are cleared before loading
        // a new one. 
        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            //makes sure to properly confirm the entrie has
            //both the date, prompt and userentry.
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
        Console.WriteLine("Journal loaded successfully!");
    }
}
