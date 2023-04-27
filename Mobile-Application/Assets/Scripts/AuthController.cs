using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class AuthController : MonoBehaviour
{
    public Text emailInput, passwordInput, roleInput;
    [SerializeField] Button registershop, registerCustomer;

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

    public void RegisterUser()
    {
        if (emailInput.text.Equals("") && passwordInput.text.Equals("") && roleInput.text.Equals(""))
        {
            print("Please enter an email, password and select the role to register");
            return;
        }
        if (roleInput.text.Equals("Customer"))
        {
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
                   //registerCustomer.GetComponentRegister
                }
            }));
        }
        
        if (roleInput.text.Equals("Shop Owner"))
        {
           

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
                    //print("Registracion COMPLETE");

                }
            }));
        }
    }
     
   
public void Logout() { }

    public void GetErrorMessage(AuthError errorCode)
    {
        string msg = "";

        msg = errorCode.ToString();

        print(msg);
    }
}
