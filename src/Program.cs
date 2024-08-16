using System.Text.RegularExpressions;

class Program {

    private static BusyIntervalCalc calculator = new BusyIntervalCalc();

    static void Main(string[] args){
         
         // Checks if there is arguments so we can look for a file.
         if (args.Length > 0 && args[0] == "filename" && args.Length == 2){
            string filePath = args[1];

            if (File.Exists(filePath)){
                AddIntervalFromFile(filePath); 
                calculator.CalculateBusiestPeriod();
            }
            else Console.WriteLine("File not found.");
           
        }
        
        // After checking for arguments the usual cycle will start
        while(true){
            Console.WriteLine("Enter time interval of the break in format HH:mmHH:mm (or 'q' to quit):");
            string input = Console.ReadLine();

            if (input.ToLower() == "q") break;

            AddIntervalFromInput(input);
            calculator.CalculateBusiestPeriod();
        }
        
    }

    // For creating TimeInterval from file
    static void AddIntervalFromFile(string filePath) {
        var lines = File.ReadAllLines(filePath);
        
        // Iterate over all the lines of text and use AddIntervalFromInput for creating TimeInterval instances
        foreach (var line in lines){
            AddIntervalFromInput(line); 
        }
    }

    
    // For creating TimeInterval from input / line
    static void AddIntervalFromInput(string input)
    {
        try{
           
            // Using regex to check if the format is correct
            string regex = @"^\d{2}:\d{2}\d{2}:\d{2}$";
            var match = Regex.Match(input, regex);

            if(match.Success){
                string start = input.Substring(0, 5); 
                string end = input.Substring(5, 5);  
                Console.WriteLine($"Start: {start}, End: {end}"); 
                
                // Creating TimeInterval object
                var interval = new TimeInterval(start, end);
                calculator.AddTimeInterval(interval);
            }
            else Console.WriteLine("Input must be in format HH:mmHH:mm with valid time values.");
        
        }
        catch (Exception ex) {
            Console.WriteLine($"Invalid input: {ex.Message}");
        }
    }
}

