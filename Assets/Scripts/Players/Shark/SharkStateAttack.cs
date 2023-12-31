using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Sharkの攻撃状態
/// </summary>
public class SharkStateAttack : SharkStateBase
{
    #region serialize
    [Tooltip("攻撃のプレハブ")]
    [SerializeField]
    private GameObject _attackPrefab = default;

    [Tooltip("硬直時間")]
    [SerializeField]
    private float _cantMoveTime = 1.5f;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = SharkState.Attack;
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
        _shark.Player.GetSearchInfo();
        OnAttack();
    }

    public override void UpdateSequence()
    {
        base.UpdateSequence();
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion

    #region private method
    /// <summary>
    /// 敵のほうを向く
    /// </summary>
    private void TargetDirRotate()
    {
        _shark.Player.transform.LookAt(new Vector3(_shark.Player.TargetPos.x, _shark.Player.transform.position.y, _shark.Player.TargetPos.z));
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    private void OnAttack()
    {
        //リストがnullかカウントが0でないなら
        if (_shark.Player.IsAttack)
        {
            TargetDirRotate();

            ObjectPool.Instance.GetGameObject(_attackPrefab, _shark.Player.TargetPos);
        }
        StartCoroutine(CanNotMoveCoroutine());
    }
    #endregion

    #region coroutine method
    private IEnumerator CanNotMoveCoroutine()
    {
        yield return new WaitForSeconds(_cantMoveTime);
        _shark.Idle();
    }
    #endregion
}
