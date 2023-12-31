using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wolfの移動状態
/// </summary>
public class WolfStateRun : WolfStateBase
{
    #region serialize
    [Tooltip("移動速度")]
    [SerializeField]
    private float _speed = 3.0f;

    [Tooltip("回転速度")]
    [SerializeField]
    private float _rotateSpeed = 0.1f;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = WolfState.Run;
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

        if (_wolf.Player.Horizontal == 0 && _wolf.Player.Vertical == 0)
        {
            _wolf.Idle();
        }

        _wolf.Player.PlayerRotate(_rotateSpeed);
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();

        if (_wolf.Player.Horizontal == 0 && _wolf.Player.Vertical == 0) return;
        _wolf.Player.PlayerMove(_speed);
    }

    public override void Exit()
    {
        _wolf.AnimChange(false);
        base.Exit();
    }
    #endregion
}
