using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Auth;
using TMPro;

public class AuthController : MonoBehaviour
{
    public InputField emailInput, passwordInput, forgetPassEmail;
    public GameObject Login_Panel, ForgetPassordPanel, WarningPanel;
    public Text warning_Title_Text, warning_Message_Text;

    public void OpenLoginPanel()
    {
        Login_Panel.SetActive(true);
        ForgetPassordPanel.SetActive(false);
    }
    public void OpenForgetPasswordPanel()
    {
        Login_Panel.SetActive(false);
        ForgetPassordPanel.SetActive(true);
    }
    public void LoginUser()
    {
        if (string.IsNullOrEmpty(emailInput.text) && string.IsNullOrEmpty(passwordInput.text))
        {
            showWarningMessage("Error", "Fields are Empty, Please fill all the Input Fields");
            return;
        }
        //Do Login
    }

    public void forgetPass()
    {
        if (string.IsNullOrEmpty(forgetPassEmail.text))
        {
            showWarningMessage("Error", "Fields are Empty, Please fill all the Input Fields");
            return;
        }
    }
    private void showWarningMessage(string title, string message)
    {
        warning_Title_Text.text = "" + title;
        warning_Message_Text.text = "" + message;

        WarningPanel.SetActive(true);


    }

    public void CloseWarningMessage_Panel()
    {
        WarningPanel.SetActive(false);
    }
}

/*{
    public Text emailInput, passwordInput;
    //[SerializeField] Button registershop, registerCustomer;

    public void Login()
    {
        if (emailInput.text.Equals("") && passwordInput.text.Equals(""))
        {
            print("Please enter an email and password to login");
            return;
        }
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailInput.text, passwordInput.text).ContinueWith((task => { 
        
            if(task.IsCanceled)
            {
                return;
            }
            if(task.IsFaulted)
            {
                Firebase.FirebaseException e =
                task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);

                return;
            }
            if(task.IsCompleted)
            {
                print("User Logged In");
                return;
            }
        }));
    }
    //void Start()
    //{
        //registershop.onClick.AddListener(RegisterShopPage);
       // registerCustomer.onClick.AddListener(RegisterCustomer);
    //}
    public void Login_Anonymous() { }

    /*public void RegisterUser()
    {
        if (emailInput.text.Equals("") && passwordInput.text.Equals("") && roleInput.text.Equals(""))
        {
            print("Please enter an email, password and select the role to register");
            return;
        }
       
            FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(emailInput.text, passwordInput.text).ContinueWith((task =>
            {
                if (task.IsCanceled)
                {
                    Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                    GetErrorMessage((AuthError)e.ErrorCode);
                    return;
                }
                if (task.IsFaulted)
                {
                    Firebase.FirebaseException e =
                    task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                    GetErrorMessage((AuthError)e.ErrorCode);

                    return;
                }
                if (task.IsCompleted)
                {
                    print("Registracion COMPLETE");
                    //ScenesManager.Instance.LoadScene(ScenesManager.Scene.WelcomeScene);
                    //registerCustomer.GetComponentRegister
                }
            }));
        
    }
     
   
public void Logout() { }

    public void GetErrorMessage(AuthError errorCode)
    {
        string msg = "";

        msg = errorCode.ToString();

        print(msg);
    }
}*/
