using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlimeStateBase : MonoBehaviour,ISlimeState
{
    #region property
    public SlimeState SlimeState => _state;
    #endregion

    #region serialize
    [SerializeField]
    protected Slime _slime = default;
    #endregion

    #region protected
    protected SlimeState _state;
    #endregion

    #region public method
    public virtual void Entry()
    {
        Debug.Log(SlimeState);
    }
    public virtual void UpdateSequence() { }
    public virtual void Exit() { }
    #endregion
}