/// <summary>
/// SharkのState用インターフェース
/// </summary>
public interface ISharkState
{
    public SharkState SharkState { get; }

    public void Entry();
    public void UpdateSequence();
    public void FixedUpdateSequence();
    public void Exit();
}

/// <summary>
/// SharkのState
/// </summary>
public enum SharkState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}
