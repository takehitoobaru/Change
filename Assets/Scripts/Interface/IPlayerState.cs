/// <summary>
/// PlayerのState用インターフェース
/// </summary>
public interface IPlayerState
{
    public PlayerState PlayerState { get; }

    public void Entry();
    public void UpdateSequence();
    public void FixedUpdateSequence();
    public void Exit();
}

/// <summary>
/// PlayerのState
/// </summary>
public enum PlayerState
{
    Wolf,
    Shark,
    Eagle
}
