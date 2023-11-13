using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateEagle : PlayerStateBase
{
    #region serialize
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
    }

    public override void UpdateSequence()
    {
        base.UpdateSequence();
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion
}