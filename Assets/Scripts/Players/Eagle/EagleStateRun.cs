using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Eagleの移動状態
/// </summary>
public class EagleStateRun : EagleStateBase
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
        _state = EagleState.Run;
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

        if (_eagle.Player.Horizontal == 0 && _eagle.Player.Vertical == 0)
        {
            _eagle.Idle();
        }

        _eagle.Player.PlayerRotate(_rotateSpeed);
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();

        if (_eagle.Player.Horizontal == 0 && _eagle.Player.Vertical == 0) return;
        _eagle.Player.PlayerMove(_speed);
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion
}
