using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    private InputField email;  // EMAIL FIELD
    private InputField password; // PASSWORD
    public Animation anim;
    public GameObject root;
    private void Start()
    {
      //  email = GameObject.Find("Email").GetComponent<InputField>();
    //    password = GameObject.Find("Password").GetComponent<InputField>();
    }

    public void OnClickLogin() // ON LOGIN BTN CLICKED
    {
        //  string passwordtxt = password.text; // GET PASSWORD
        //  string emailtxt = email.text; // GET EMAIL
        anim.Play("Loading");
        // ON SUCCESFULL LOGIN
        StartCoroutine(loadScene());
        
    }  
    void OnClickedSignup() // ON SIGN UP BTN CLICKED
    {
        // redirect to website sign up 
    }

    IEnumerator loadScene()
    {

        AsyncOperation scene = SceneManager.LoadSceneAsync("Home");
        scene.allowSceneActivation = false;

        while (!scene.isDone)
        {
            
            if(scene.progress == 0.9f)
            {
               
                yield return new WaitForSeconds(3f);
                scene.allowSceneActivation = true;
            }

        }
    }
}
