public class HealthState
{
    public int Lives { get; private set; } = 10;
    
    public void UpdateHealth(int livesLost)
    {
        Lives -= livesLost;
    }
}