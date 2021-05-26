using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public GameObject col;
    public Text username;
    public Text HighScoreText;

    float highScore;
    private static System.DateTime today;
    int colNum = 0;
    float maxHeigth;
    // Start is called before the first frame update
    void Start()
    {
        today = System.DateTime.Now;
        maxHeigth = GetComponent<RectTransform>().sizeDelta.y;
        showWeek();
    }

    IEnumerator generateColls(int days)
    {
        colNum = 0;
        yield return new WaitForSeconds(0.5f);

        for (int week = 0; week < days; week++)//generate 7 cols
        {
            Instantiate(col, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        }

        foreach (Image bar in this.GetComponentsInChildren<Image>())//change heigth of every col
        {
            if (colNum != 0)//ignore first cause its panel
            {
                float heigth = SaveSystem.Load(username.text, today.AddDays(-colNum + 1).ToString("yyyy.MM.dd")).score;//load score in day

                if (heigth > highScore)
                {
                    highScore = heigth;//highscoreText
                }

                if (heigth * 15 + 5 > maxHeigth)
                {
                    heigth = (maxHeigth - 5) / 15;//limit max heitgh
                }
                bar.GetComponent<RectTransform>().sizeDelta = new Vector3(0, heigth * 15 + 5, 0);//change heitgh to score
                bar.GetComponent<Image>().color = new Vector4(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 1);
            }


            colNum = colNum + 1;
        }
        HighScoreText.text = highScore.ToString();
    }
    public void showWeek()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        StartCoroutine(generateColls(7));
    }
    public void showMonth()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        StartCoroutine(generateColls(30));
    }
}
