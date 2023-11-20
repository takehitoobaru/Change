using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの狼状態
/// </summary>
public class PlayerStateWolf : PlayerStateBase
{
    #region serialize
    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private WolfStateController _controller = default;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = PlayerState.Wolf;
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
        gameObject.SetActive(true);
        _controller.Init(WolfState.Idle);
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
        _controller.ChangeState(WolfState.Idle);
    }

    public void Run()
    {
        _controller.ChangeState(WolfState.Run);
    }

    public void Attack()
    {
        _controller.ChangeState(WolfState.Attack);
    }

    public void SpecialAttack()
    {
        _controller.ChangeState(WolfState.SpecialAttack);
    }
    #endregion

    #region private method
    #endregion
}
