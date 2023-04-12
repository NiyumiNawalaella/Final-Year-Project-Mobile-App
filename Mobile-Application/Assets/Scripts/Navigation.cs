using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    [SerializeField] GameObject[] panels;

    public void NavigationBarClick(GameObject activePanel)
    {
        for(int i=0; i<panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        activePanel.SetActive(true);
    }
    // public GameObject Home_Panel;
    // public GameObject Promotion_Panel;
    // public GameObject Search_Panel;
    // public GameObject Account_Panel;


    // public GameObject[] panels;

    // public void home()
    // {

    //     Home_Panel.SetActive(true);
    //     Promotion_Panel.SetActive(false);
    //     Search_Panel.SetActive(false);
    //     Account_Panel.SetActive(false);
    // }
    // public void promotion()
    // {
    //     Home_Panel.SetActive(false);
    //     Promotion_Panel.SetActive(true);
    //     Search_Panel.SetActive(false);
    //     Account_Panel.SetActive(false);
    // }
    // public void search()
    // {
    //     Home_Panel.SetActive(false);
    //     Promotion_Panel.SetActive(false);
    //     Search_Panel.SetActive(true);
    //     Account_Panel.SetActive(false);
    // }
    // public void account()
    // {
    //     Home_Panel.SetActive(false);
    //     Promotion_Panel.SetActive(false);
    //     Search_Panel.SetActive(false);
    //     Account_Panel.SetActive(true);
    // }
}
