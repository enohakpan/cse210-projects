using System;
using System.Collections.Generic;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;
    static bool useConsoleClear = false; // Set to false to avoid Console.Clear() issues

    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "6")
        {
            try
            {
                if (useConsoleClear)
                {
                    try { Console.Clear(); } catch { /* Ignore clear errors */ }
                }
                else
                {
                    Console.WriteLine("\n----------------------------------------");
                }
                
                Console.WriteLine($"You have {score} points.\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");
                
                choice = Console.ReadLine();
                if (choice == null) // Handle potential null from ReadLine
                {
                    Console.WriteLine("Input error detected. Exiting program.");
                    break;
                }

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordGoalEvent();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"Console I/O error: {ex.Message}");
                Console.WriteLine("Press any key to try again or Ctrl+C to exit.");
                try { Console.ReadKey(true); } catch { break; }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                Console.WriteLine("Press any key to try again or Ctrl+C to exit.");
                try { Console.ReadKey(true); } catch { break; }
            }
        }
    }

    static void CreateGoal()
    {
        try
        {
            if (useConsoleClear) try { Console.Clear(); } catch { }
            else Console.WriteLine("\n----------------------------------------");
            
            Console.WriteLine("The types of goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string typeChoice = Console.ReadLine() ?? "";

            Console.Write("Enter the name of your goal: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter a short description: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Enter the amount of points associated with this goal: ");
            string pointsInput = Console.ReadLine() ?? "0";
            
            // Safer parsing with default values
            if (!int.TryParse(pointsInput, out int points))
            {
                Console.WriteLine("Invalid points value. Using 0 as default.");
                points = 0;
            }

            if (typeChoice == "1")  // SimpleGoal
            {
                goals.Add(new SimpleGoal(name, description, points));
            }
            else if (typeChoice == "2")  // EternalGoal
            {
                goals.Add(new EternalGoal(name, description, points));
            }
            else if (typeChoice == "3")  // ChecklistGoal
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string targetInput = Console.ReadLine() ?? "1";
                if (!int.TryParse(targetInput, out int targetCount))
                {
                    Console.WriteLine("Invalid target count. Using 1 as default.");
                    targetCount = 1;
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                string bonusInput = Console.ReadLine() ?? "0";
                if (!int.TryParse(bonusInput, out int bonus))
                {
                    Console.WriteLine("Invalid bonus value. Using 0 as default.");
                    bonus = 0;
                }

                goals.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
            }
            else
            {
                Console.WriteLine("Invalid goal type.");
            }

            Console.WriteLine("Goal created! Press Enter to continue...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating goal: {ex.Message}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static void ListGoals()
    {
        try
        {
            if (useConsoleClear) try { Console.Clear(); } catch { }
            else Console.WriteLine("\n----------------------------------------");
            
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals have been created yet.");
            }
            else
            {
                Console.WriteLine("Here are your goals:");
                foreach (var goal in goals)
                {
                    Console.WriteLine(goal.GetDetailsString());
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing goals: {ex.Message}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static void RecordGoalEvent()
    {
        try
        {
            if (useConsoleClear) try { Console.Clear(); } catch { }
            else Console.WriteLine("\n----------------------------------------");
            
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available to record events.");
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Which goal did you complete?");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }

            Console.Write("Select the number of the goal you completed: ");
            string indexInput = Console.ReadLine() ?? "";
            
            if (!int.TryParse(indexInput, out int goalIndex))
            {
                Console.WriteLine("Invalid selection. Returning to the menu.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
            
            goalIndex--; // Convert from 1-based to 0-based index

            if (goalIndex >= 0 && goalIndex < goals.Count)
            {
                int pointsEarned = goals[goalIndex].RecordEvent();
                score += pointsEarned;

                if (pointsEarned > 0)
                {
                    Console.WriteLine($"You earned {pointsEarned} points!");
                }
                else
                {
                    Console.WriteLine("No points earned. Maybe the goal is already complete.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Returning to the menu.");
            }

            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error recording event: {ex.Message}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static void SaveGoals()
    {
        try
        {
            if (useConsoleClear) try { Console.Clear(); } catch { }
            else Console.WriteLine("\n----------------------------------------");
            
            Console.Write("Enter filename to save: ");
            string filename = Console.ReadLine() ?? "goals.txt";
            
            if (string.IsNullOrWhiteSpace(filename))
            {
                filename = "goals.txt";
            }
            
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(filename))
            {
                // First line: score
                outputFile.WriteLine(score);
                
                // Remaining lines: goals
                foreach (Goal goal in goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            
            Console.WriteLine("Goals saved successfully!");
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static void LoadGoals()
    {
        try
        {
            if (useConsoleClear) try { Console.Clear(); } catch { }
            else Console.WriteLine("\n----------------------------------------");
            
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine() ?? "goals.txt";
            
            if (string.IsNullOrWhiteSpace(filename))
            {
                filename = "goals.txt";
            }
            
            if (System.IO.File.Exists(filename))
            {
                goals.Clear(); // Clear existing goals
                
                string[] lines = System.IO.File.ReadAllLines(filename);
                
                // First line is the score
                if (lines.Length > 0)
                {
                    if (int.TryParse(lines[0], out int loadedScore))
                    {
                        score = loadedScore;
                    }
                }
                
                // Remaining lines are goals
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    if (parts.Length < 3) continue; // Skip invalid lines
                    
                    string goalType = parts[0];
                    
                    try
                    {
                        if (goalType == "SimpleGoal" && parts.Length >= 5)
                        {
                            SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                            if (bool.Parse(parts[4])) // If it's complete
                            {
                                goal.RecordEvent(); // Mark as complete
                            }
                            goals.Add(goal);
                        }
                        else if (goalType == "EternalGoal" && parts.Length >= 4)
                        {
                            goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        }
                        else if (goalType == "ChecklistGoal" && parts.Length >= 7)
                        {
                            ChecklistGoal goal = new ChecklistGoal(
                                parts[1], parts[2], int.Parse(parts[3]), 
                                int.Parse(parts[5]), int.Parse(parts[4]));
                            
                            // Record events for the number of times completed
                            int timesCompleted = int.Parse(parts[6]);
                            for (int j = 0; j < timesCompleted; j++)
                            {
                                goal.RecordEvent();
                            }
                            
                            goals.Add(goal);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading goal on line {i+1}: {ex.Message}");
                    }
                }
                
                Console.WriteLine("Goals loaded successfully!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}