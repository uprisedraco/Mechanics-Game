using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreUI : MonoBehaviour
{
    [SerializeField] private Image _ring;
    [SerializeField] private Image _ringBackground;
    [SerializeField] private Image _icon;

    public float _ringFill;
    public float _ringBackgroundFill;
    public float _iconFill;

    private void Update()
    {
        _ring.fillAmount = _ringFill;
        _ringBackground.fillAmount = _ringBackgroundFill;
        _icon.fillAmount = _iconFill;
    }
}
