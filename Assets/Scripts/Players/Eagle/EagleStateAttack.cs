using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Eagle�̍U�����
/// </summary>
public class EagleStateAttack : EagleStateBase
{
    #region serialize
    [Tooltip("�U���̃v���n�u")]
    [SerializeField]
    private GameObject _attackPrefab = default;

    [Tooltip("�d������")]
    [SerializeField]
    private float _cantMoveTime = 1.5f;
    #endregion

    #region unity methods
    private void Start()
    {
        _state = EagleState.Attack;
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
        _eagle.Player.GetSearchInfo();
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
    /// �G�̂ق�������
    /// </summary>
    private void TargetDirRotate()
    {
        _eagle.Player.transform.LookAt(new Vector3(_eagle.Player.TargetPos.x, _eagle.Player.transform.position.y, _eagle.Player.TargetPos.z));
    }

    /// <summary>
    /// �U��
    /// </summary>
    private void OnAttack()
    {
        //���X�g��null���J�E���g��0�łȂ��Ȃ�
        if (_eagle.Player.IsAttack)
        {
            TargetDirRotate();

            ObjectPool.Instance.GetGameObject(_attackPrefab, _eagle.Player.TargetPos);
        }
        StartCoroutine(CanNotMoveCoroutine());
    }
    #endregion

    #region coroutine method
    private IEnumerator CanNotMoveCoroutine()
    {
        yield return new WaitForSeconds(_cantMoveTime);
        _eagle.Idle();
    }
    #endregion
}
