using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using TMPro;
using System;

public class Register_User : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variables
    //    [Header("Register")]
    public InputField emailRegister_InputField;
    public InputField passwordRegister_InputField;
    public InputField confirmRegister_InputField;
    public Dropdown roleRegister_DropDown;
    public Text warningRegister_Text;

    public void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avaliable Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authenication instance object
        auth = FirebaseAuth.DefaultInstance;
    }
    //Function for the register button
    public void RegisterButton()
    {
        //Call the register coroutne passing the email, password, role
        _ = StartCoroutine(Register(emailRegister_InputField.text, passwordRegister_InputField.text, roleRegister_DropDown.captionText));
    }

    private IEnumerator Register(string text1, string text2, Text captionText)
    {
        throw new NotImplementedException();
    }

    private IEnumerator Register(string _email, string _password, string _role)
    {
        if (_email == "")
        {
            //If the email address field is blan show a warning
            warningRegister_Text.text = "Missing Email Address";
        }
        else if (passwordRegister_InputField != confirmRegister_InputField)
        {
            warningRegister_Text.text = "Password Does Not Match";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if(RegisterTask.Exception != null)
            {
                //If there are errors handle then
                Debug.LogWarning(message: $"Faailed to Register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch(errorCode)
                {
                    case AuthError.MissingEmail: message = "Missing Email"; break;
                    case AuthError.MissingPassword: message = "Missing Password"; break;
                    case AuthError.WeakPassword: message = "Weak Password";break;
                    case AuthError.EmailAlreadyInUse: message = "Email Already In Use"; break;
                }
                warningRegister_Text.text = message;
            }
            else
            {
                //User has now been created 
                //Now get the result
                User = RegisterTask.Result;
                if(User!=null)
                {
                    //Create a user profile and set the email address
                    UserProfile profile = new UserProfile { DisplayName = _role };

                    //Call the firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);
                }
            }
        }
    }
}

    /*public Text emailInput, passwordInput, roleInput;
    //[SerializeField] Button registershop, registerCustomer;
  
    public void RegisterUser()
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

    private void GetErrorMessage(AuthError errorCode)
    {
        throw new NotImplementedException();
    }*/



