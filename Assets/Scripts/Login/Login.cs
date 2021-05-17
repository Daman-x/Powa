using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    private InputField email;  // EMAIL FIELD
    private InputField password; // PASSWORD

    private void Start()
    {
        email = GameObject.Find("Email").GetComponent<InputField>();
        password = GameObject.Find("Password").GetComponent<InputField>();
    }

    void OnClickLogin() // ON LOGIN BTN CLICKED
    {
        string passwordtxt = password.text; // GET PASSWORD
        string emailtxt = email.text; // GET EMAIL


        // ON SUCCESFULL LOGIN
        //StartCoroutine(loadScene());
    }
    void OnclickedGuestLogin() //ON GUEST BTN CLICKED
    {

    }
    void OnClickedSignup() // ON SIGN UP BTN CLICKED
    {
        // redirect to website sign up 
    }

  /*  IEnumerator loadScene()
    {

        AsyncOperation scene = SceneManager.LoadSceneAsync("Home");
        scene.allowSceneActivation = false;

        while (!scene.isDone)
        {
            scene.allowSceneActivation = true;
        }
    }*/
}
