using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkStateBase : MonoBehaviour,ISharkState
{
    #region property
    public SharkState SharkState => _state;
    #endregion

    #region serialize
    [SerializeField]
    protected PlayerStateShark _shark = default;
    #endregion

    #region protected
    protected SharkState _state;
    #endregion

    #region public method
    public virtual void Entry() { }

    public virtual void UpdateSequence() { }

    public virtual void Exit() { }
    #endregion
}
