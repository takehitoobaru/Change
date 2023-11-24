/// <summary>
/// ダメージ用のインターフェース
/// </summary>
public interface IDamagable
{
    void Damage(int amount,Element element);
}

public enum Element
{
    Fire,
    Water,
    Wind
}
