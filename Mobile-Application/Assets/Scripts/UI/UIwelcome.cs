using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIwelcome : MonoBehaviour
{
    [SerializeField] Button welcomepage;

    void Start()
    {
        welcomepage.onClick.AddListener(WelcomePage);
    }

    private void WelcomePage()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.WelcomeScene);
    }
}
