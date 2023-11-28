using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shark‚ÌˆÚ“®ó‘Ô
/// </summary>
public class SharkStateRun : SharkStateBase
{
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
        _state = SharkState.Run;
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

        if (_shark.Player.Horizontal == 0 && _shark.Player.Vertical == 0)
        {
            _shark.Idle();
        }

        _shark.Player.PlayerRotate(_rotateSpeed);
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();

        if (_shark.Player.Horizontal == 0 && _shark.Player.Vertical == 0) return;
        _shark.Player.PlayerMove(_speed);
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion
}
