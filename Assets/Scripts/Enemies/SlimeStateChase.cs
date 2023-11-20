using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スライムの追跡状態
/// </summary>
public class SlimeStateChase : SlimeStateBase
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
        _state = SlimeState.Chase;
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
        //攻撃できる距離にいるなら
        if (_slime.IsAttack)
        {
            _slime.Attack();
            return;
        }
        //プレイヤーを追跡
        _slime.Agent.destination = _slime.Target.position;
    }

    public override void Exit()
    {
        base.Exit();
        _slime.Agent.destination = _slime.transform.position;
    }
    #endregion

    #region private method
    #endregion
}
