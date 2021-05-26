using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breathe : MonoBehaviour
{
    bool isBreathing = false;
    RectTransform transform;
    Image img;
    int stage = 0;//0-1=growing, 1-2=brething, 2-3 exhale

    public GameObject gameManager;
    public float growthSpeed;
    public float colorSpeed;
    public float shrinkSpeed;
    public Text txt; //breath anotation

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        transform = GetComponent<RectTransform>();
        transform.transform.localScale = new Vector3 (0.3f, 0.3f,0.3f);
    }

    void Update()//while pressed button circle grows and change color
    {
        transform.transform.Rotate(0,0,8f*Time.deltaTime);


        if (isBreathing == true)
        {
            if (stage == 0)
            {
                txt.text = "Breathe";
                transform.transform.localScale = transform.transform.localScale + new Vector3(growthSpeed * Time.deltaTime, growthSpeed * Time.deltaTime, growthSpeed * Time.deltaTime); // growing
                if (transform.transform.localScale.x >= 1f)//next stage
                {
                    Vibration.Vibrate(120);
                    stage = 1;
                    gameManager.GetComponent<Score>().UpdateScore(3);
                }
            }
            else if (stage == 1)// change color
            {
                float blue = img.color.b + colorSpeed / 255 * Time.deltaTime;
                img.color = new Color(0.647f, 1, blue, 1);

                txt.text = "Hold";
                txt.color = new Color(0.647f, 1, blue, 1);

                if (img.color.b >= 0.98f)//next stage
                {
                    Vibration.Vibrate(120);
                    stage = 2;
                    gameManager.GetComponent<Score>().UpdateScore(3);
                }
            }
            
        }
        else if (stage == 2)
        {
                

                transform.transform.localScale = transform.transform.localScale - new Vector3(shrinkSpeed * Time.deltaTime, shrinkSpeed * Time.deltaTime, shrinkSpeed * Time.deltaTime); // shrinking
                float blue = img.color.b - colorSpeed * 0.875f / 255 * Time.deltaTime; // change color back
                img.color = new Color(0.647f, 1, blue, 1);

                txt.text = "Exhale";
                txt.color = new Color(0.647f, 1, blue, 1);

                if (transform.transform.localScale.x <= 0.3f)//next stage
            {
                    stage = 0;
                    Vibration.Vibrate(120);
                    gameManager.GetComponent<Score>().UpdateScore(5);
                    transform.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    img.color = new Color(0.647f, 1, 0.647f, 1);
                }
        }
        
    }

    public void BreatheDown()//button pressed
    {
        isBreathing = true;
    }
    public void BreatheUp()// button unpressed
    {
        isBreathing = false;
    }
}
