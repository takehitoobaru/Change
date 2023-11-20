/// <summary>
/// Player��State�p�C���^�[�t�F�[�X
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
/// Player��State
/// </summary>
public enum PlayerState
{
    Wolf,
    Shark,
    Eagle
}
