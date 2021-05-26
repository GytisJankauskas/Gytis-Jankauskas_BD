using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public string usrName;
    public Text usernameText;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void OnLevelWasLoaded()//Loads user name
    {
        usernameText = GameObject.Find("username").GetComponent<Text>();
        if (usernameText != null) { usernameText.text = usrName; };
    }
}
