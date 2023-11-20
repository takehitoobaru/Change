using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒXƒ‰ƒCƒ€‚Ì’Tõó‘Ô
/// </summary>
public class SlimeStateSearch : SlimeStateBase
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
    private void Awake()
    {

    }

    private void Start()
    {
        _state = SlimeState.Search;
    }

    private void Update()
    {

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
        if (_slime.IsChase)
        {
            _slime.Chase();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    #endregion

    #region private method
    #endregion
}
