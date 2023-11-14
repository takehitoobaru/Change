using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStateBase : MonoBehaviour,IWolfState
{
    #region property
    public WolfState WolfState => _state;
    #endregion

    #region serialize
    [SerializeField]
    protected PlayerStateWolf _wolf = default;
    #endregion

    #region protected
    protected WolfState _state;
    #endregion

    #region public method
    public virtual void Entry() { }

    public virtual void UpdateSequence() { }

    public virtual void Exit() { }
    #endregion
}
