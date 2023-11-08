using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //UŒ‚‚Å‚«‚é‹——£‚É‚¢‚é‚È‚ç
        if (_slime.IsAttack)
        {
            _slime.Attack();
            return;
        }
        //ƒvƒŒƒCƒ„[‚ğ’ÇÕ
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
