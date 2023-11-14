public interface IEagleState
{
    public EagleState EagleState { get; }

    public void Entry();
    public void UpdateSequence();
    public void Exit();
}

public enum EagleState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}