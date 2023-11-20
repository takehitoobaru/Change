using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの鮫状態
/// </summary>
public class PlayerStateShark : PlayerStateBase
{
    #region serialize
    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private SharkStateController _controller = default;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = PlayerState.Shark;
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
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();
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
        _controller.ChangeState(SharkState.Attack);
    }

    public void SpecialAttack()
    {
        _controller.ChangeState(SharkState.SpecialAttack);
    }
    #endregion
}
