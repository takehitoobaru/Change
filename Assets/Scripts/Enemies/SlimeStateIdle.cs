using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateIdle : SlimeStateBase
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Start()
    {
        _state = SlimeState.Idle;
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
        _slime.Search();
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion

    #region private method
    #endregion
}
