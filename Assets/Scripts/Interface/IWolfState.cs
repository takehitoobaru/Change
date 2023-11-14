public interface IWolfState
{
    public WolfState WolfState { get; }

    public void Entry();
    public void UpdateSequence();
    public void Exit();
}

public enum WolfState
{
    Idle,
    Run,
    Attack,
    SpecialAttack,
}