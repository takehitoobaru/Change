using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X���C���̃X�e�[�g�R���g���[���[
/// </summary>
public class SlimeStateController : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    /// <summary>�������p</summary>
    private bool _init = false;
    /// <summary>���݂̏��</summary>
    private ISlimeState _currentState;
    /// <summary>���O�̏��</summary>
    private ISlimeState _previousState;
    /// <summary>�ҋ@��ԃR���|�[�l���g</summary>
    private SlimeStateIdle _idle;
    /// <summary>�T����ԃR���|�[�l���g</summary>
    private SlimeStateSearch _search;
    /// <summary>�ǐՏ�ԃR���|�[�l���g</summary>
    private SlimeStateChase _chase;
    /// <summary>�U����ԃR���|�[�l���g</summary>
    private SlimeStateAttack _attack;
    /// <summary>����U����ԃR���|�[�l���g</summary>
    private SlimeStateSpecialAttack _specialAttack;
    /// <summary>�e�[�u��</summary>
    Dictionary<SlimeState, ISlimeState> _stateTable;
    #endregion

    private void Awake()
    {
        _idle = GetComponent<SlimeStateIdle>();
        _search = GetComponent<SlimeStateSearch>();
        _chase = GetComponent<SlimeStateChase>();
        _attack = GetComponent<SlimeStateAttack>();
        _specialAttack = GetComponent<SlimeStateSpecialAttack>();
    }

    #region public method
    /// <summary>
    /// ������
    /// </summary>
    /// <param name="initState">�ŏ��̏��</param>
    public void Init(SlimeState initState)
    {
        if (_stateTable != null) return;

        Dictionary<SlimeState, ISlimeState> table = new()
        {
            { SlimeState.Idle, _idle },
            { SlimeState.Search, _search },
            { SlimeState.Chase, _chase },
            { SlimeState.Attack, _attack },
            { SlimeState.SpecialAttack, _specialAttack },
        };
        _stateTable = table;
        ChangeState(initState);
        _init = true;
    }

    /// <summary>
    /// ��ԕύX
    /// </summary>
    /// <param name="next">���̏��</param>
    public void ChangeState(SlimeState next)
    {
        if (_stateTable == null) return;
        if (_init)
        {
            if (_currentState == null || _currentState.SlimeState == next) return;
        }

        var nextState = _stateTable[next];
        _previousState = _currentState;
        _previousState?.Exit();
        _currentState = nextState;
        _currentState.Entry();
    }

    /// <summary>
    /// ���݂̏�Ԃ�Update�����s
    /// </summary>
    public void UpdateSequence() => _currentState?.UpdateSequence();
    #endregion
}
