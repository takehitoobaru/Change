using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EagleÇÃë“ã@èÛë‘
/// </summary>
public class EagleStateIdle : EagleStateBase
{
    #region unity methods
    private void Start()
    {
        _state = EagleState.Idle;
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
        if (_eagle.Player.Horizontal != 0 || _eagle.Player.Vertical != 0)
        {
            _eagle.Run();
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
