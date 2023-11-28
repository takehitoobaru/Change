using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WolfÇÃë“ã@èÛë‘
/// </summary>
public class WolfStateIdle : WolfStateBase
{
    #region unity methods
    private void Start()
    {
        _state = WolfState.Idle;
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
        if(_wolf.Player.Horizontal != 0 || _wolf.Player.Vertical != 0)
        {
            _wolf.Run();
        }
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion
}
