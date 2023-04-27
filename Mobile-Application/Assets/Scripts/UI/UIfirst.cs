using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfirst : MonoBehaviour
{
    [SerializeField] Button firstpage;

    void Start()
    {
        firstpage.onClick.AddListener(FirstPage);
    }

    private void FirstPage()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.FirstScene);
    }
}
