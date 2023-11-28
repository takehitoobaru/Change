using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    #region private
    private Button _endButton;
    #endregion

    #region unity methods
    private void Awake()
    {
        _endButton = GetComponent<Button>();
    }

    private void Start()
    {
        _endButton.onClick.AddListener(OnClickEnd);
    }
    #endregion

    #region private method
    private void OnClickEnd()
    {
        SceneController.Instance.ChangeScene("Result", "Title");
    }
    #endregion
}
