using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wolf‚ÌˆÚ“®ó‘Ô
/// </summary>
public class WolfStateRun : WolfStateBase
{
    #region property
    #endregion

    #region serialize
    [Tooltip("ˆÚ“®‘¬“x")]
    [SerializeField]
    private float _speed = 3.0f;

    [Tooltip("‰ñ“]‘¬“x")]
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
        base.Exit();
    }
    #endregion

    #region private method
    #endregion
}
