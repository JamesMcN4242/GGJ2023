public class HealthState
{
    public int Lives { get; private set; } = 3;
    
    public void UpdateHealth(int livesLost)
    {
        Lives -= livesLost;
    }
}