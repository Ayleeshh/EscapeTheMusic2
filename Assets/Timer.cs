using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
[SerializeField] TextMeshProUGUI timerText;
[SerializeField] float remainingTime;
[SerializeField] float gameOverDisplayTime;
[SerializeField] TextMeshProUGUI GameOver;
[SerializeField] TextMeshProUGUI ResetRoom;
[SerializeField] TextMeshProUGUI resetText;
bool buttonPressed;

public void PlayTimer()
{
    buttonPressed = true;
}

    void Update()
    {
        if(buttonPressed == true)
        {

            if(remainingTime>0){
                remainingTime -=Time.deltaTime;
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds=Mathf.FloorToInt(remainingTime % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            } else if (remainingTime<0){

                timerText.text = "00:00";
                timerText.color = Color.red;
                GameOver.text = "GAME OVER, YOU LOSE!";

                gameOverDisplayTime -=Time.deltaTime;
                int seconds=Mathf.FloorToInt(gameOverDisplayTime % 60);

                resetText.text = string.Format("{00}", seconds);
                
                ResetRoom.text = "RESETING ROOM IN";

                
                if(gameOverDisplayTime < 0){
                    SceneManager.LoadScene("VR");
                }

            }
        
        }
       
    }
}
