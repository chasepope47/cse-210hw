public class RaceResult
{
    public List<Team> FinishOrder { get; private set; }

    public RaceResult(List<Team> finishOrder)
    {
        FinishOrder = finishOrder;
    }
}
