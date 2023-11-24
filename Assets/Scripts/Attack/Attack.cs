using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃
/// </summary>
public class Attack : MonoBehaviour
{
    [Tooltip("攻撃力")]
    [SerializeField]
    private int _attackAmount = 10;

    [Tooltip("属性")]
    [SerializeField]
    private Element _attackElement = Element.Fire;

    [Tooltip("キャラクタータイプ")]
    [SerializeField]
    private AttackType _charaType = AttackType.Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && _charaType == AttackType.Player)
        {
            other.gameObject.GetComponent<IDamagable>().Damage(_attackAmount, _attackElement);
        }

        if (other.CompareTag("Player") && _charaType == AttackType.Enemy)
        {
            other.gameObject.GetComponent<IDamagable>().Damage(_attackAmount, _attackElement);
        }
    }

    private void OnParticleSystemStopped()
    {
        ObjectPool.Instance.ReleaseGameObject(gameObject);
    }
}

public enum AttackType
{
    Player,
    Enemy
}
