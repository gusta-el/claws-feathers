using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectorFase1 : MonoBehaviour
{

    public int goal;
    public TMP_Text scoreTmpText;
    public GameObject player;

    private GameObject strawman;
    private string scoreText;
    private int scoreBefore = 0;
    private int score = 0;

    void Update()
    {

        string text = GetTextScore();
        scoreTmpText.SetText(text);

        if(scoreBefore > score)
        {
            player.SendMessage("UpdateEnemiesInField", strawman);
        }


    }

    public void Score(GameObject strawmanObj) {

        strawman = strawmanObj;
        score += 1;
        strawman.GetComponent<Collider2D>().enabled = false;
        Destroy(strawman, 3f);
     
    }

    private string GetTextScore()
    {
        return "" + score + " / " + goal;
    }

}
