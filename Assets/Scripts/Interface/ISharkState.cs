public interface ISharkState
{
    public SharkState SharkState { get; }

    public void Entry();
    public void UpdateSequence();
    public void Exit();
}

public enum SharkState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}
