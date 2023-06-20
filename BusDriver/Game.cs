namespace DrivingGame;

public partial class Game
{
    // All drivers have driven 0 minutes at the start of the day
    public long TimeDriven { get; set; } = 0;
    // Bus Drivers who are part of this game
    public List<BusDriver> BusDrivers { get; set; } = new List<BusDriver>();
    // They all need to drive for 8 hours
    public long MinutesToDrive { get; set; } = 8 * 60;
}

public partial class Game {
    // Get the Stops driven before all the Gossip Circulates
    public (long TimeDriver, long StopsVisited) DriveAround()
    {
        for (TimeDriven = 0; TimeDriven < MinutesToDrive; TimeDriven++)
        {
            for (int driverIdx = 0; driverIdx < BusDrivers.Count; driverIdx++)
            {
                BusDriver busDriver = BusDrivers[driverIdx];
                var currentStop = busDriver.Routes[(int)(TimeDriven % busDriver.NumberOfRoutes)];
                // Other drivers who part of this game
                List<BusDriver> otherDrivers = BusDrivers.Where(d=> d!=busDriver).ToList();
                foreach (var driver in otherDrivers)
                {
                    var theirStop = driver.Routes[(int)(TimeDriven % driver.NumberOfRoutes)];
                    if (theirStop==currentStop) // At the same stop so they will Gossip
                    {
                        foreach (var gossip in driver.Gossip)
                        {
                            busDriver.Gossip.Add(gossip);
                        }
                    }
                }
            }
            var count = BusDrivers.Select(b => b.Gossip.Count).Sum();
            if (Math.Pow(BusDrivers.Count, 2) == count)
            {
                // All the Gossip has circulated when total of Gossip is Number of BusDrivers * Number of BusDrivers
                break;
            }
        }

        return (TimeDriven, TimeDriven+1);
    }
}