using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightModChange : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Button _changeModBtn;
    Color bl;
    Color wh;
    void Start()
    {
        ColorUtility.TryParseHtmlString("#453E45", out bl);
        ColorUtility.TryParseHtmlString("#F5F5F5", out wh);
        _changeModBtn.onClick.AddListener(ChangeMod);
    }
    void ChangeMod()
    {
        
        if (_cam.backgroundColor == wh)
        {
            _cam.backgroundColor = bl;
        }
        else
        {
            _cam.backgroundColor = wh;
        }
    }
}
