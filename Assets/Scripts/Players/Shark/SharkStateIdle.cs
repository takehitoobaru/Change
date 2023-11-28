using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SharkÇÃë“ã@èÛë‘
/// </summary>
public class SharkStateIdle : SharkStateBase
{
    #region unity methods
    private void Start()
    {
        _state = SharkState.Idle;
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
        if (_shark.Player.Horizontal != 0 || _shark.Player.Vertical != 0)
        {
            _shark.Run();
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
