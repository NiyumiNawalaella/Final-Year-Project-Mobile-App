using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIlogin : MonoBehaviour
{
    [SerializeField] Button login;

    void Start()
    {
        login.onClick.AddListener(LoginPage);
    }

    private void LoginPage()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.LoginScene);
    }
}
