/// <summary>
/// �_���[�W�p�̃C���^�[�t�F�[�X
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
