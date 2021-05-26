using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    public Text username;
    public Animator transition;
    public UserName usrnameGO;

    private bool changeColorOnce = false;

    public void Login() //Gets username and create new save file with username+date.data
    {        
        SaveSystem.Save(SaveSystem.Load(username.text).score, username.text);
        usrnameGO.usrName = username.text;
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex) //Switch scene after animation
    {
        ChangeTransitionColor();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(levelIndex);
    }
    void ChangeTransitionColor()
    {
        if (changeColorOnce == false)
        {
            changeColorOnce = true;
            Image img = transition.GetComponent<Image>();
            img.color = new Color(Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), 1f);
        }
    }
}
