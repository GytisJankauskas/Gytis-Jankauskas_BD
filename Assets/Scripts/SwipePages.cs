using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwipePages : MonoBehaviour
{
    public Animator transition;

    private Vector2 startPos;
    private Vector2 direction;

    private bool changeColorOnce = false;
    private float swipeLen = 120; //Min swipe length acording to screen resolution

    float calculateDirection()// calculate direction and return: 0=UP, 1=Right, 2=Down, 3=Left, -1=Too short swipe Length
    {
        if (direction.y < swipeLen || direction.y > -swipeLen)
        {
            if (direction.x > swipeLen) { return 1;}
            if (direction.x < -swipeLen){ return 3;}
            if (direction.y > swipeLen) { return 0;}
            if (direction.y < -swipeLen){ return 2;}
        }
        return -1;
    }


    void calculateSwipe()
    {
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    if (startPos.x < swipeLen) // if swipe long enough Play animation
                    {
                        if (calculateDirection() == 1) 
                        { 
                            Debug.Log("swipe right");
                            PlayAnimation (1);
                        }
                    }
                    else if (Screen.width - startPos.x < swipeLen)
                    {
                        if (calculateDirection() == 3) 
                        { 
                            Debug.Log("swipe left");
                            PlayAnimation(3);
                        }                                              
                    }
                    else if (startPos.y < swipeLen)
                    {
                        if (calculateDirection() == 0) 
                        { 
                            Debug.Log("swipe up");
                            PlayAnimation(0);
                        }
                        
                    }
                    else if (Screen.width - startPos.y < swipeLen)
                    {
                        if (calculateDirection() == 2) 
                        {
                            PlayAnimation(2);
                            Debug.Log("swipe down"); 
                        }
                    }
                    break;
            }
        }
    }

    void PlayAnimation(int direction)
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex; //get current scene ID to switch right or left
        
        switch (direction) //Scene "name"=ID   Login = 0, Scene2 = 1, Scene1 = 2, Scene3 = 3, statistic = 4
        {
            case 0:
                if (buildIndex == 1 || buildIndex == 2 || buildIndex == 3)
                {
                    transition.Play("transitionToDown");
                    StartCoroutine(LoadLevel(4));
                }
                break;
            case 1:
                if (buildIndex == 1)
                {
                    transition.Play("transitionToLeft");
                    StartCoroutine(LoadLevel(2));
                }
                else if (buildIndex == 3)
                {
                    transition.Play("transitionToLeft");
                    StartCoroutine(LoadLevel(1));
                }
                break;
            case 2:
                if (buildIndex == 4)
                {
                    transition.Play("transitionToUp");
                    StartCoroutine(LoadLevel(1));
                }
                break;
            case 3:
                if (buildIndex == 1)
                {
                    transition.Play("transitionToRight");
                    StartCoroutine(LoadLevel(3));
                }
                else if (buildIndex == 2)
                {
                    transition.Play("transitionToRight");
                    StartCoroutine(LoadLevel(1));
                }
                break;
            default:
                break;
        }
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

    IEnumerator LoadLevel (int levelIndex) //Switch scene after animation
    {
        ChangeTransitionColor();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(levelIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        swipeLen = Screen.width/12;

        //change background color
        GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        calculateSwipe();
    }
}
