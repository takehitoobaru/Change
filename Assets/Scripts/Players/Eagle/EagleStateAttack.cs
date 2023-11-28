using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Eagleの攻撃状態
/// </summary>
public class EagleStateAttack : EagleStateBase
{
    #region serialize
    [Tooltip("攻撃のプレハブ")]
    [SerializeField]
    private GameObject _attackPrefab = default;

    [Tooltip("硬直時間")]
    [SerializeField]
    private float _cantMoveTime = 1.5f;
    #endregion

    #region private
    /// <summary>ターゲットのポジション</summary>
    private Vector3 _targetPos;
    /// <summary>範囲内の敵のリスト</summary>
    private List<Transform> _enemyTransforms = new List<Transform>();
    #endregion

    #region unity methods
    private void Start()
    {
        _state = EagleState.Attack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemyTransforms.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemyTransforms.Remove(other.transform);
        }
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
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
    /// 一番近い敵のポジションを取得
    /// </summary>
    private void SetTarget()
    {
        Transform near = _enemyTransforms.First();
        float distance = float.MaxValue;

        foreach (Transform enemyTransform in _enemyTransforms)
        {
            float dist = Vector3.Distance(transform.position, enemyTransform.position);
            if (dist < distance)
            {
                near = enemyTransform;
                distance = dist;
            }
        }

        _targetPos = near.position;
    }

    /// <summary>
    /// 敵のほうを向く
    /// </summary>
    private void TargetDirRotate()
    {
        _eagle.Player.transform.LookAt(new Vector3(_targetPos.x, _eagle.Player.transform.position.y, _targetPos.z));
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    private void OnAttack()
    {
        //リストがnullかカウントが0でないなら
        if (_enemyTransforms?.Count > 0)
        {
            SetTarget();
            TargetDirRotate();

            ObjectPool.Instance.GetGameObject(_attackPrefab, _targetPos);
        }
        StartCoroutine(CanNotMoveCoroutine());
    }
    #endregion

    #region coroutine method
    private IEnumerator CanNotMoveCoroutine()
    {
        yield return new WaitForSeconds(_cantMoveTime);
        _eagle.Idle();
    }
    #endregion
}
