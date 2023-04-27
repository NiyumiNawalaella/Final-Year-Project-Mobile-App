using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIregister : MonoBehaviour
{
    [SerializeField] Button register;

    void Start()
    {
        register.onClick.AddListener(RegisterPage);
    }

    private void RegisterPage()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.RegisterScene);
    }
}
