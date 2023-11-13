public interface IPlayerState
{
    public PlayerState PlayerState { get; }

    public void Entry();
    public void UpdateSequence();
    public void Exit();
}

public enum PlayerState
{
    Wolf,
    Shark,
    Eagle
}
