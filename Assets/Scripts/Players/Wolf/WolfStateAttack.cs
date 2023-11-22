using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// Wolfの攻撃状態
/// </summary>
public class WolfStateAttack : WolfStateBase
{
    #region property
    #endregion

    #region serialize
    [Tooltip("アタックボタン")]
    [SerializeField]
    private Button _attackButton = default;

    [SerializeField]
    private GameObject _attackPrefab = default;

    [SerializeField]
    private float _coolTime = 3.0f;
    #endregion

    #region private
    private Vector3 _targetPos;
    private List<Transform> _enemyTransforms = new List<Transform>();
    private ButtonController _buttonCtrl;
    #endregion

    #region unity methods
    private void Start()
    {
        _buttonCtrl = _attackButton.gameObject.GetComponent<ButtonController>();

        _attackButton.OnClickAsObservable()
                     .TakeUntilDestroy(_attackButton)
                     .ThrottleFirst(TimeSpan.FromSeconds(_coolTime))
                     .Subscribe(_ => OnAttack());
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
    private void SetTarget()
    {
        Transform near = _enemyTransforms.First();
        float distance = float.MaxValue;

        foreach(Transform enemyTransform in _enemyTransforms)
        {
            float dist = Vector3.Distance(transform.position, enemyTransform.position);
            if(dist < distance)
            {
                near = enemyTransform;
                distance = dist;
            }
        }

        _targetPos = near.position;
    }

    private void OnAttack()
    {
        if (_enemyTransforms?.Count > 0)
        {

            SetTarget();

            ObjectPool.Instance.GetGameObject(_attackPrefab, _targetPos);

            _buttonCtrl.FillImage(_coolTime);

            _wolf.Idle();
        }
    }
    #endregion
}
