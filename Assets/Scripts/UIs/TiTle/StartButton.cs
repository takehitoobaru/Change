using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    #region private
    private Button _startButton;
    #endregion

    #region unity methods
    private void Awake()
    {
        _startButton = GetComponent<Button>();
        _startButton.onClick.AddListener(OnClickStart);
    }
    #endregion

    #region private method
    private void OnClickStart()
    {
        SceneController.Instance.ChangeScene("Title", "InGame");
    }
    #endregion
}
