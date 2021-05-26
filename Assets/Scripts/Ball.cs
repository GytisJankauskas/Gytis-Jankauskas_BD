using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Animator animator;
    public GameObject gameManager; //For score addition

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        colorBall();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ballClick() // on click events
    {
        animator.Play("BallClick");
        gameManager.GetComponent<Score>().UpdateScore(1);
    }

    void colorBall()
    {
        switch (Random.Range(0, 2)) 
        {
            case 0:
                GetComponent<Image>().color = new Color(1f, Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
                break;
            case 1:
                GetComponent<Image>().color = new Color(Random.Range(0f, 1f), 1f, Random.Range(0f, 1f), 1f);
                break;
            case 2:
                GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), 1f, 1f);
                break;
        }
    }
}
