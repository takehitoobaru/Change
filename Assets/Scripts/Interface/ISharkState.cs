/// <summary>
/// Shark��State�p�C���^�[�t�F�[�X
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
/// Shark��State
/// </summary>
public enum SharkState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}
