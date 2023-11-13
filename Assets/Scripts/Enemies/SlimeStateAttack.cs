using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateAttack : SlimeStateBase
{
    #region property
    #endregion

    #region serialize
    [Tooltip("�U���\���\������")]
    [SerializeField]
    private float _omenTime = 0.5f;

    [Tooltip("�U����̑ҋ@����")]
    [SerializeField]
    private float _coolTime = 1.0f;

    [Tooltip("�U���͈͕\���̃v���n�u")]
    [SerializeField]
    private GameObject _omenPrefab = default;

    [Tooltip("�U���̃v���n�u")]
    [SerializeField]
    private GameObject _attackPrefab = default;
    #endregion

    #region private
    /// <summary>�U�������ǂ���</summary>
    private bool _isAttacking = false;
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Start()
    {
        _state = SlimeState.Attack;
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
        _isAttacking = true;
        StartCoroutine(OmenCoroutine());
    }

    public override void UpdateSequence()
    {
        base.UpdateSequence();
        if (_isAttacking) return;
        _slime.Idle();
    }

    public override void Exit()
    {
        base.Exit();
        _slime.SetWaitTime(_coolTime);
    }

    #endregion

    #region private method
    #endregion

    #region coroutine method
    /// <summary>
    /// �\���p�R���[�`��
    /// </summary>
    /// <returns></returns>
    private IEnumerator OmenCoroutine()
    {
        Vector3 pos = _slime.Target.position;

        //�\���\��
        var omen = ObjectPool.Instance.GetGameObject(_omenPrefab, new Vector3(pos.x, _omenPrefab.transform.position.y, pos.z));
        //�҂�
        yield return new WaitForSeconds(_omenTime);
        //�\����\��
        ObjectPool.Instance.ReleaseGameObject(omen);
        //�U��
        ObjectPool.Instance.GetGameObject(_attackPrefab, new Vector3(pos.x, _attackPrefab.transform.position.y, pos.z));

        _isAttacking = false;
    }
    #endregion
}
