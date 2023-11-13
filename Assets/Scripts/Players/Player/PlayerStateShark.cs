using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateShark : PlayerStateBase
{
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
