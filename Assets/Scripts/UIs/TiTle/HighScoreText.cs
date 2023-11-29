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
        SoundManager.Instance.PlayBGM(SoundManager.Instance.TitleBGM);
        _highScoretext.text = "HighScore:" + GameManager.Instance.HighScore;
    }
    #endregion
}
