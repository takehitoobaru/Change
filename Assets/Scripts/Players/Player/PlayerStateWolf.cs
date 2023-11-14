using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateWolf : PlayerStateBase
{
    #region serialize
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
    }

    public override void UpdateSequence()
    {
        base.UpdateSequence();
        _controller.UpdateSequence();
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion

    #region private method
    #endregion
}
