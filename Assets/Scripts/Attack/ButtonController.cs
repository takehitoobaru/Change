using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    private Button _button;
    private Image _image;
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
    #endregion

    #region public method
    public void FillImage(float coolTime)
    {
        _image.fillAmount = 0;
        _image.DOFillAmount(1, coolTime);
    }
    #endregion

    #region private method
    #endregion
}
