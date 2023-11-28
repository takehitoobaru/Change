using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    #region private
    private TextMeshProUGUI _scoreText;
    #endregion

    #region unity methods
    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _scoreText.text = "Score:" + GameManager.Instance.Score.ToString();
    }
    #endregion
}
