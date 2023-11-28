using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    #region private
    private TextMeshProUGUI _highScoretext;
    #endregion

    #region unity methods
    private void Awake()
    {
        _highScoretext = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _highScoretext.text = "HighScore:" + GameManager.Instance.HighScore.ToString();
    }
    #endregion

    #region public method
    #endregion

    #region private method
    #endregion
}
