using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIhome : MonoBehaviour
{
    [SerializeField] Button homepage;

    void Start()
    {
        homepage.onClick.AddListener(HomePage);
    }

    private void HomePage()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.HomeScene);
    }
}
