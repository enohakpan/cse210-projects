using System;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; " +
                "in all your ways submit to him, and he will make your paths straight."),
            
            new Scripture(new ScriptureReference("1Nephi", 3, 7),
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            
            new Scripture(new ScriptureReference("Ether", 12, 27),
                "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."),

            new Scripture(new ScriptureReference("Jacob", 2, 27),
                "Wherefore, my brethren, hear me, and hearken to the word of the Lord: For there shall not any man among you have save it be one wife; and concubines he shall have none;"),

            new Scripture(new ScriptureReference("2Nephi", 25, 26),
                "And we talk of Christ, we rejoice in Christ, we preach of Christ, we prophesy of Christ, and we write according to our prophecies, that our children may know to what source they may look for a remission of their sins."),

            new Scripture(new ScriptureReference("1Nephi", 19, 23),
                "And I did read many things unto them which were written in the books of Moses; but that I might more fully persuade them to believe in the Lord their Redeemer I did read unto them that which was written by the prophet Isaiah; for I did liken all scriptures unto us, that it might be for our profit and learning."),

            new Scripture(new ScriptureReference("2Nephi", 25, 30),
                "And, inasmuch as it shall be expedient, ye must keep the performances and ordinances of God until the law shall be fulfilled which was given unto Moses."),

            new Scripture(new ScriptureReference("1Nephi", 21, 15),
                "For can a woman forget her sucking child, that she should not have compassion on the son of her womb? (Laman & Lemuel, remember your mother’s love & concern for Jacob & Joseph in the wilderness?)"),

            new Scripture(new ScriptureReference("Enos", 1, 27),
                "And I soon go to the place of my rest, which is with my Redeemer; for I know that in him I shall rest. And I rejoice in the day when my mortal shall put on immortality, and shall stand before him; then shall I see his face with pleasure, and he will say unto me: Come unto me, ye blessed, there is a place prepared for you in the mansions of my Father. Amen."),

            new Scripture(new ScriptureReference("Alma", 29, 9),
                "I know that which the Lord hath commanded me, and I glory in it. I do not glory of myself, but I glory in that which the Lord hath commanded me; yea, and this is my glory, that perhaps I may be an instrument in the hands of God to bring some soul to repentance; and this is my joy.")
        };

        Console.WriteLine("Choose a scripture to memorize:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].Reference}");
        }
        Console.WriteLine("Enter the number of your choice, or type 'random' for a random scripture:");

        Scripture selectedScripture;
        string input = Console.ReadLine();

        if (input.ToLower() == "random")
        {
            Random rand = new Random();
            selectedScripture = scriptures[rand.Next(scriptures.Count)];
        }
        else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= scriptures.Count)
        {
            selectedScripture = scriptures[choice - 1];
        }
        else
        {
            Console.WriteLine("Invalid choice. Defaulting to first scripture.");
            selectedScripture = scriptures[0];
        }

        // Start the memorization process
        while (!selectedScripture.IsFullyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWords(3);
        }

        Console.WriteLine("Well done! You've completed the memorization exercise.");
    }
}
