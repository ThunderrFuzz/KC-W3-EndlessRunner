using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{

    public TMP_Text clearedObstacles;
    public TMP_Text time;
    public TMP_Text score;

    float timeSurvived;
    PlayerStats stats;
    Movement mov;
    // Start is called before the first frame update

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        mov = FindObjectOfType<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        //increase obstacles cleared
        clearedObstacles.text = "Obstacles Cleared: " + stats.getClearedObstacle();
        if (!mov.gameOver)
        {
            // increase time elapsed 
            time.text = "Time Survived: " + Mathf.Floor(Time.time);

            timeSurvived += Time.time;
        }
        else 
        {
            //only update score at the end of the game, as boosttime will increase until the end of the game 
            score.text = "Total Score: " + Mathf.Floor((float)stats.getClearedObstacle() + (timeSurvived - stats.getBoostTime() / 10000));
        }
    }
}
