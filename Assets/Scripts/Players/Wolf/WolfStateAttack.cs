using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// Wolf�̍U�����
/// </summary>
public class WolfStateAttack : WolfStateBase
{
    #region property
    #endregion

    #region serialize
    [Tooltip("�U���̃v���n�u")]
    [SerializeField]
    private GameObject _attackPrefab = default;

    [Tooltip("�d������")]
    [SerializeField]
    private float _cantMoveTime = 1.5f;
    #endregion

    #region private
    /// <summary>�^�[�Q�b�g�̃|�W�V����</summary>
    private Vector3 _targetPos;
    /// <summary>�͈͓��̓G�̃��X�g</summary>
    private List<Transform> _enemyTransforms = new List<Transform>();
    #endregion

    #region unity methods
    private void Start()
    {
        _state = WolfState.Attack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemyTransforms.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemyTransforms.Remove(other.transform);
        }
    }
    #endregion

    #region public method
    public override void Entry()
    {
        base.Entry();
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
    /// ��ԋ߂��G�̃|�W�V�������擾
    /// </summary>
    private void SetTarget()
    {
        Transform near = _enemyTransforms.First();
        float distance = float.MaxValue;

        foreach(Transform enemyTransform in _enemyTransforms)
        {
            float dist = Vector3.Distance(transform.position, enemyTransform.position);
            if(dist < distance)
            {
                near = enemyTransform;
                distance = dist;
            }
        }

        _targetPos = near.position;
    }

    /// <summary>
    /// �G�̂ق�������
    /// </summary>
    private void TargetDirRotate()
    {
        _wolf.Player.transform.LookAt(new Vector3(_targetPos.x,_wolf.Player.transform.position.y,_targetPos.z));
    }

    /// <summary>
    /// �U��
    /// </summary>
    private void OnAttack()
    {
        //���X�g��null���J�E���g��0�łȂ��Ȃ�
        if (_enemyTransforms?.Count > 0)
        {
            SetTarget();
            TargetDirRotate();

            ObjectPool.Instance.GetGameObject(_attackPrefab, _targetPos);

            StartCoroutine(CanNotMoveCoroutine());
        }
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
