using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour
{
    private bool isGamePaused = false;
    public Sprite playSprite;
    public Sprite pauseSprite;
    public Button button;
    
    GameObject TopBorder;
    GameObject BottomBorder;
    GameObject RightBorder;
    GameObject LeftBorder;
    public void Pause(){
        gameObject.GetComponent<Image>().sprite = playSprite;
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Play()
    {
        gameObject.GetComponent<Image>().sprite = pauseSprite;
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void onButtonClick()
    {
        if (isGamePaused)
        {
            Play();
        }
        else if (!isGamePaused)
        {
            Pause();
        }
    }

}
