/// <summary>
/// SlimeのState用インターフェース
/// </summary>
public interface ISlimeState
{
    /// <summary>状態取得</summary>
    public SlimeState SlimeState { get; }

    void Entry();
    void UpdateSequence();
    void Exit();
}

/// <summary>
/// SlimeのState
/// </summary>
public enum SlimeState
{
    Idle,
    Search,
    Chase,
    Attack,
    SpecialAttack,
}