using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleStateBase : MonoBehaviour,IEagleState
{
    #region property
    public EagleState EagleState => _state;
    #endregion

    #region serialize
    [SerializeField]
    protected PlayerStateEagle _eagle = default;
    #endregion

    #region protected
    protected EagleState _state;
    #endregion

    #region public method
    public virtual void Entry() { }

    public virtual void UpdateSequence() { }

    public virtual void Exit() { }
    #endregion
}
