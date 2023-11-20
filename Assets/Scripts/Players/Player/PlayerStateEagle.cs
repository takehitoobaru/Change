using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̘h���
/// </summary>
public class PlayerStateEagle : PlayerStateBase
{
    #region serialize
    [Tooltip("�X�e�[�g�R���g���[���[")]
    [SerializeField]
    private EagleStateController _controller = default;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = PlayerState.Eagle;
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
        _controller.ChangeState(EagleState.Idle);
    }

    public void Run()
    {
        _controller.ChangeState(EagleState.Run);
    }

    public void Attack()
    {
        _controller.ChangeState(EagleState.Attack);
    }

    public void SpecialAttack()
    {
        _controller.ChangeState(EagleState.SpecialAttack);
    }

    #endregion
}
