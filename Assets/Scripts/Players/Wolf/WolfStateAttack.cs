using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wolf‚ÌUŒ‚ó‘Ô
/// </summary>
public class WolfStateAttack : WolfStateBase
{
    #region property
    #endregion

    #region serialize
    [Tooltip("UŒ‚‚ÌƒvƒŒƒnƒu")]
    [SerializeField]
    private GameObject _attackPrefab = default;

    [Tooltip("d’¼ŠÔ")]
    [SerializeField]
    private float _cantMoveTime = 1.5f;
    #endregion

    #region private
    #endregion

    #region unity methods
    private void Start()
    {
        _state = WolfState.Attack;
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
        _wolf.Player.GetSearchInfo();
        OnAttack();
    }

    public override void UpdateSequence()
    {
        base.UpdateSequence();
    }

    public override void FixedUpdateSequence()
    {
        base.FixedUpdateSequence();
    }

    public override void Exit()
    {
        base.Exit();
    }
    #endregion

    #region private method
    

    /// <summary>
    /// “G‚Ì‚Ù‚¤‚ğŒü‚­
    /// </summary>
    private void TargetDirRotate()
    {
        _wolf.Player.transform.LookAt(new Vector3(_wolf.Player.TargetPos.x,_wolf.Player.transform.position.y,_wolf.Player.TargetPos.z));
    }

    /// <summary>
    /// UŒ‚
    /// </summary>
    private void OnAttack()
    {
        //ƒŠƒXƒg‚ªnull‚©ƒJƒEƒ“ƒg‚ª0‚Å‚È‚¢‚È‚ç
        if (_wolf.Player.IsAttack)
        {
            TargetDirRotate();

            ObjectPool.Instance.GetGameObject(_attackPrefab, _wolf.Player.TargetPos);
        }
        StartCoroutine(CanNotMoveCoroutine());
    }
    #endregion

    #region coroutine method
    private IEnumerator CanNotMoveCoroutine()
    {
        yield return new WaitForSeconds(_cantMoveTime);
        _wolf.Idle();
    }
    #endregion
}
