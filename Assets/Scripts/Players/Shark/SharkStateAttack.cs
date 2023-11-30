using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Shark‚ÌUŒ‚ó‘Ô
/// </summary>
public class SharkStateAttack : SharkStateBase
{
    #region serialize
    [Tooltip("UŒ‚‚ÌƒvƒŒƒnƒu")]
    [SerializeField]
    private GameObject _attackPrefab = default;

    [Tooltip("d’¼ŠÔ")]
    [SerializeField]
    private float _cantMoveTime = 1.5f;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = SharkState.Attack;
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
        _shark.Player.GetSearchInfo();
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
        _shark.Player.transform.LookAt(new Vector3(_shark.Player.TargetPos.x, _shark.Player.transform.position.y, _shark.Player.TargetPos.z));
    }

    /// <summary>
    /// UŒ‚
    /// </summary>
    private void OnAttack()
    {
        //ƒŠƒXƒg‚ªnull‚©ƒJƒEƒ“ƒg‚ª0‚Å‚È‚¢‚È‚ç
        if (_shark.Player.IsAttack)
        {
            TargetDirRotate();

            ObjectPool.Instance.GetGameObject(_attackPrefab, _shark.Player.TargetPos);
        }
        StartCoroutine(CanNotMoveCoroutine());
    }
    #endregion

    #region coroutine method
    private IEnumerator CanNotMoveCoroutine()
    {
        yield return new WaitForSeconds(_cantMoveTime);
        _shark.Idle();
    }
    #endregion
}
