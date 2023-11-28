using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// Playerの鮫状態
/// </summary>
public class PlayerStateShark : PlayerStateBase
{
    #region serialize
    [Tooltip("攻撃のクールタイム")]
    [SerializeField]
    private float _attackCoolTime = 3.0f;

    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private SharkStateController _controller = default;

    [Tooltip("アタックボタン")]
    [SerializeField]
    private Button _attackButton = default;
    #endregion

    #region private
    private ButtonController _buttonCtrl;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = PlayerState.Shark;

        _buttonCtrl = _attackButton.gameObject.GetComponent<ButtonController>();

        _attackButton.OnClickAsObservable()
             .TakeUntilDestroy(_attackButton)
             .ThrottleFirst(TimeSpan.FromSeconds(_attackCoolTime))
             .Subscribe(_ => Attack());
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
        gameObject.SetActive(true);
        _controller.Init(SharkState.Idle);
    }

    public override void UpdateSequence()
    {
        base.UpdateSequence();
        _controller.UpdateSequence();
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();
        _controller.FixedUpdateSequence();
    }

    public override void Exit()
    {
        base.Exit();
        gameObject.SetActive(false);
    }

    public void Idle()
    {
        _controller.ChangeState(SharkState.Idle);
    }

    public void Run()
    {
        _controller.ChangeState(SharkState.Run);
    }

    public void Attack()
    {
        _buttonCtrl.FillImage(_attackCoolTime);
        _controller.ChangeState(SharkState.Attack);
    }

    public void SpecialAttack()
    {
        _controller.ChangeState(SharkState.SpecialAttack);
    }
    #endregion
}
