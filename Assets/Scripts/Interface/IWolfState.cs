/// <summary>
/// Wolf��State�p�C���^�[�t�F�[�X
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
/// Wolf��State
/// </summary>
public enum WolfState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}