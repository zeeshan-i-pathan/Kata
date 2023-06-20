namespace DrivingGame;
public class BusDriver
{
    public List<int> Routes { get; set; } = new List<int>();
    public long NumberOfRoutes { get => Routes.Count; }
    public HashSet<long> Gossip { get; set; } = new HashSet<long>();
}