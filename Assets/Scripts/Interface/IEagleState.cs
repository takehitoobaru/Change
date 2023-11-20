/// <summary>
/// Eagle��State�p�C���^�[�t�F�[�X
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
/// Eagle��State
/// </summary>
public enum EagleState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}