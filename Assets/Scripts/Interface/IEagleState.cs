/// <summary>
/// EagleのState用インターフェース
/// </summary>
public interface IEagleState
{
    public EagleState EagleState { get; }

    public void Entry();
    public void UpdateSequence();
    public void FixedUpdateSequence();
    public void Exit();
}

/// <summary>
/// EagleのState
/// </summary>
public enum EagleState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}