
public interface ISlimeState
{
    /// <summary>��Ԏ擾</summary>
    public SlimeState SlimeState { get; }

    void Entry();
    void UpdateSequence();
    void Exit();
}

/// <summary>
/// Slime��State
/// </summary>
public enum SlimeState
{
    Idle,
    Search,
    Chase,
    Attack,
    SpecialAttack,
}