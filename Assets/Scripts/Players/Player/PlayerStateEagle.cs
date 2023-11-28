using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// Playerの鷲状態
/// </summary>
public class PlayerStateEagle : PlayerStateBase
{
    #region serialize
    [Tooltip("攻撃のクールタイム")]
    [SerializeField]
    private float _attackCoolTime = 3.0f;

    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private EagleStateController _controller = default;

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
        _state = PlayerState.Eagle;

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
        _controller.Init(EagleState.Idle);
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
        _controller.ChangeState(EagleState.Idle);
    }

    public void Run()
    {
        _controller.ChangeState(EagleState.Run);
    }

    public void Attack()
    {
        _buttonCtrl.FillImage(_attackCoolTime);
        _controller.ChangeState(EagleState.Attack);
    }

    public void SpecialAttack()
    {
        _controller.ChangeState(EagleState.SpecialAttack);
    }
    #endregion
}
