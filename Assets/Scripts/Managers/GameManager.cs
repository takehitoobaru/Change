using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region property
    public int Score => _score;
    public int HighScore => _highScore;
    #endregion

    #region private
    private int _score = 0;
    private int _highScore = 0;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SceneController.Instance.SceneLoad("Title");
    }
    #endregion

    #region public method
    /// <summary>
    /// スコアを格納
    /// </summary>
    /// <param name="score">スコア</param>
    public void SetScore(int score)
    {
        _score += score;
    }

    /// <summary>
    /// ハイスコアを設定
    /// </summary>
    /// <param name="score">ゲーム終了時のスコア</param>
    public void SetHighScore(int score)
    {
        if(score > _highScore)
        {
            _highScore = score;
        }

        _score = 0;
    }
    #endregion

    #region private method
    #endregion
}
