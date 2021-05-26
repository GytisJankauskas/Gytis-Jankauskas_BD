using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System;

public class FacebookLogin : MonoBehaviour
{
    public Image ProfileImage;

    private void Awake()
    {
        ProfileImage = GetComponent<Image>();
        if (!FB.IsInitialized)//start facebook
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Facebook Can't start");
            },
            isGameShow =>
            {
                if (!isGameShow)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
    }

    #region GetUserNameAndImage
    void UpdateUserNameAndImage()
    {
        FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayPhoto);
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayName);
    }
    void DisplayPhoto(IGraphResult result)
    {
        if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log(result);
            ProfileImage.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
        else if (result.Error == null)
        {
            Debug.Log("heeeeee " + result.Error);
        }
    }
    void DisplayName(IGraphResult result)
    {
        if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log(result.ToString());
        }
        else if (result.Error == null)
        {
            Debug.Log("heeeeee " + result.Error);
        }
    }
    #endregion

    public void facebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
        UpdateUserNameAndImage();
        facebookShare();
    }
    public void facebookLogout()
    {
        FB.LogOut();
    }

    public void facebookShare()
    {
        FB.ShareLink(
            new System.Uri("http://google.com"), 
            "Relax App", 
            "Getting Relax point to cure stress", 
            new System.Uri("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"));
    }
}
