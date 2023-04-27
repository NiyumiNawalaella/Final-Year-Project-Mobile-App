using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    public enum Scene
    {
       // AccountCustomerScene,
        //AccountShopOwnerScene,
        //AddPromotionScene,
        //ChangePasswordAccountScene,
        //EditPageAccountScene,
        //EditPageShopScene,
        FirstScene,
        LoginScene,
        RegisterScene,
        RegisterShopScene,
        WelcomeScene,
        HomeScene
        //PermissionScene,
        //PromotionScene,
        
        //SearchingScene,
        //SearchScene,
       
    }
    public void LoadScene(Scene scene )
    {
        SceneManager.LoadScene(scene.ToString());
    }
    
}
