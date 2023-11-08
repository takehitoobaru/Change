
public interface ISlimeState
{
    /// <summary>ó‘Ôæ“¾</summary>
    public SlimeState SlimeState { get; }

    void Entry();
    void UpdateSequence();
    void Exit();
}

/// <summary>
/// Slime‚ÌState
/// </summary>
public enum SlimeState
{
    Idle,
    Search,
    Chase,
    Attack,
    SpecialAttack,
}