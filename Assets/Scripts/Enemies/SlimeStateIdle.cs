using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スライムの待機状態
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
    /// 待ち時間分待つ
    /// </summary>
    /// <returns></returns>
    private IEnumerator IdleCoroutine()
    {
        yield return new WaitForSeconds(_slime.WaitTime);
        _slime.Search();
    }
    #endregion
}
