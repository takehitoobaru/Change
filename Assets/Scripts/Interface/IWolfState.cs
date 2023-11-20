/// <summary>
/// WolfのState用インターフェース
/// </summary>
public interface IWolfState
{
    public WolfState WolfState { get; }

    public void Entry();
    public void UpdateSequence();
    public void FixedUpdateSequence();
    public void Exit();
}

/// <summary>
/// WolfのState
/// </summary>
public enum WolfState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}