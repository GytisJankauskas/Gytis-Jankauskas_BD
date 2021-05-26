using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spinner : MonoBehaviour
{
    float speed;
    public float slowdownSpeed;
    public float speedToAdd;
    public Score gm;

    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        GetComponentInChildren<Image>().color = new Vector4(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,speed*Time.deltaTime));
        if (speed > 0.01)
        {
            speed = speed * slowdownSpeed;//non linear decrasing speed
        }
        else if (speed < 0.01)
        {
            speed = 0;//stoping spinning
        }
    }
    public void clickSpeed()
    {
        speed = speed + speedToAdd;
        gm.UpdateScore(1);
    }
}
