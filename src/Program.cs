using System.Text.RegularExpressions;

class Program {

    static void Main(string[] args){
         
         if (args.Length > 0 && args[0] == "filename" && args.Length == 2){
            string filePath = args[1];

            if (File.Exists(filePath)) AddIntervalFromFile(filePath); 
            else Console.WriteLine("File not found.");
           
        }
        
        while(true){
            Console.WriteLine("Enter time interval of the break in format HH:mmHH:mm (or 'q' to quit):");
            string input = Console.ReadLine();

            if (input.ToLower() == "q") break;

            AddIntervalFromInput(input);
            
        }
        
    }
    static void AddIntervalFromFile(string filePath) {
        var lines = File.ReadAllLines(filePath);
        
        foreach (var line in lines){
            AddIntervalFromInput(line); 
        }
    }

    static void AddIntervalFromInput(string input)
    {
        try{
           
            string regex = @"^\d{2}:\d{2}\d{2}:\d{2}$";
            var match = Regex.Match(input, regex);

            if(match.Success){
                string start = input.Substring(0, 5); 
                string end = input.Substring(5, 5);  
                Console.WriteLine($"Start: {start}, End: {end}"); 
                
                var interval = new TimeInterval(start, end);
            }
            else Console.WriteLine("Input must be in format HH:mmHH:mm with valid time values.");
        
        }
        catch (Exception ex) {
            Console.WriteLine($"Invalid input: {ex.Message}");
        }
    }
}

