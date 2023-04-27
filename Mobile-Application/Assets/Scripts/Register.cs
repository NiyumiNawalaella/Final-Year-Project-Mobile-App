using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    [SerializeField] Button  registerCustomer;

    void Start()
    {
    //registershop.onClick.AddListener(RegisterShopPage);
    registerCustomer.onClick.AddListener(RegisterCustomer);
    }

    //private void RegisterShopPage()
    //{
      //  ScenesManager.Instance.LoadScene(ScenesManager.Scene.RegisterShopScene);
    //}
   private void RegisterCustomer()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.WelcomeScene);
    }
}
