public class ScoreSystem
{
    public int Score { get; private set; } = 0;

    public void UpdateScore(int newCorrect)
    {
        // TODO: Multipliers?
        Score += newCorrect * 15;
    }
}