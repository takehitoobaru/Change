using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    #region property
    public int Score => _score;
    #endregion

    #region serialize
    #endregion

    #region private
    private int _score = 0;
    private int _enemyNum = 5;
    private float _limitTime = 120f;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {

    }

    private void Update()
    {
        _limitTime -= Time.deltaTime;
        
        if(_limitTime <= 0 || _enemyNum <= 0)
        {
            SceneController.Instance.ChangeScene("InGame", "Result");
        }
    }
    #endregion

    #region public method
    /// <summary>
    /// ƒXƒRƒA‰ÁZ
    /// </summary>
    /// <param name="amount">‰ÁZ—Ê</param>
    public void AddScore(int amount)
    {
        _score += amount;
    }

    /// <summary>
    /// “|‚·‚×‚«“G‚Ì”‚ªŒ¸­‚·‚é
    /// </summary>
    public void DownEnemyNum()
    {
        _enemyNum--;
    }
    #endregion

    #region private method
    #endregion
}
