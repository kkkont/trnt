class BusyIntervalCalc {
    private List<TimeInterval> timeIntervals = new List<TimeInterval>();
     
    // Adding time interval to the list 
    public void AddTimeInterval(TimeInterval interval) {
        timeIntervals.Add(interval);
    }

    // Calculation method
    public void CalculateBusiestPeriod(){

        // Check if there are any time intervals
        if(timeIntervals.Count == 0){
            Console.WriteLine("No time intervals available.");
            return;
        }
        
        // Dictionary to hold key-value pairs
        Dictionary<DateTime, int> timeline = new Dictionary<DateTime, int>();
        

        // Going through all the time intervals in the list
        foreach (var interval in timeIntervals)
        {
            // Checking time with minute accuracy if it already is in the timeline, if not add it to the timeline
            // Increase the number of repetitions as needed
            for (var time = interval.start; time <= interval.end; time = time.AddMinutes(1))
            {
                if (timeline.ContainsKey(time))
                {
                    timeline[time]++;
                }
                else
                {
                    timeline[time] = 1;
                }
            }
        }

        // Find the maximum number of repetitions from the timeline dictionary
        int maxDrivers = timeline.Values.Max();
        
        List<DateTime> busiestTimes = new List<DateTime>();

        // For each entry in timeline check if the repetitions on that time match maximum number of repetitions,
        // if so add the time to busiest time list
        foreach (var entry in timeline){
            if (entry.Value == maxDrivers) busiestTimes.Add(entry.Key);
        }
        busiestTimes.Sort();

        // Find the start and end time of the busiest interval
        DateTime startTime = busiestTimes.First();
        DateTime endTime = busiestTimes.Last();

        Console.WriteLine($"Busiest period: {startTime:HH:mm}-{endTime:HH:mm} with {maxDrivers} drivers on break.");
    
    }

}