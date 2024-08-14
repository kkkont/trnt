class BusyIntervalCalc {
    private List<TimeInterval> timeIntervals = new List<TimeInterval>();
     
    public void AddTimeInterval(TimeInterval interval) {
        timeIntervals.Add(interval);
    }

    public void CalculateBusiestPeriod(){

        if(timeIntervals.Count == 0){
            Console.WriteLine("No time intervals available.");
            return;
        }
        
        Dictionary<DateTime, int> timeline = new Dictionary<DateTime, int>();

        foreach (var interval in timeIntervals)
        {
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

        int maxDrivers = timeline.Values.Max();
        
        List<DateTime> busiestTimes = new List<DateTime>();
        foreach (var entry in timeline){
            if (entry.Value == maxDrivers) busiestTimes.Add(entry.Key);
        }
        busiestTimes.Sort();

        DateTime startTime = busiestTimes.First();
        DateTime endTime = busiestTimes.Last();

        Console.WriteLine($"Busiest period: {startTime:HH:mm}-{endTime:HH:mm} with {maxDrivers} drivers on break.");
    
    }

}