using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒXƒ‰ƒCƒ€‚Ì‘Ò‹@ó‘Ô
/// </summary>
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
        StartCoroutine(IdleCoroutine());
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

    #region private method
    #endregion

    #region coroutine method
    /// <summary>
    /// ‘Ò‚¿ŠÔ•ª‘Ò‚Â
    /// </summary>
    /// <returns></returns>
    private IEnumerator IdleCoroutine()
    {
        yield return new WaitForSeconds(_slime.WaitTime);
        _slime.Search();
    }
    #endregion
}
