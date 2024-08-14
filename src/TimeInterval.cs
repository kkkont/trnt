public class TimeInterval {

    public DateTime start {get;}
    public DateTime end {get;}
    public TimeInterval(string startTime, string endTime){

        start = DateTime.ParseExact(startTime, "HH:mm", null);
        end = DateTime.ParseExact(endTime, "HH:mm", null);

        if (start > end)
        {
            throw new ArgumentException("Start time must be before or equal to end time.");
        }
    }
}