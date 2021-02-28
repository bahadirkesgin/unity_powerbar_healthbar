using UnityEngine;
using UnityEngine.UI;

public class Powerbar : MonoBehaviour 
{
    public float fullWidth = 256;
    public float speed = 3f;
    public float thePower = 2; 
    public bool increasing = true;
    public bool decreasing = true;
    public float barSpeed = 5f; 
    public float currentBarLevel = 0f; 
    public Slider slider;
    enum gameState { Moving, Pause, Dead, Finish }
    gameState currentState = gameState.Pause;
    void Update() 
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) 
            { 
                refPosition = touch.position; 
                currentState = gameState.Moving;
                if (currentBarLevel > 110 & currentBarLevel < 156)
                {
                    transform.Translate(0, 0, speed * thePower);
                }
                else if (currentBarLevel > 70 & currentBarLevel < 196)
                {
                    transform.Translate(0, 0, speed);
                }
                else
                {
                    transform.Translate(0, 0, (speed * (thePower * 0.75)));
                }
                increasing = false;
                decrasing = false;
                currentBarLevel = 0;
            }
        }
        if (currentState = gameState.Pause)
        {
            increasing = true;
        }
        if (currentBarLevel >= fullWidth -10)
        {
            increasing = false;
            decreasing = true;
        }
        if  (increasing)
        {    
            currentBarLevel += barSpeed * Time.smoothDeltaTime;
            BarProgress(currentBarLevel);
        }
        
        else if (decrasing)
        {
            currentBarLevel -= barSpeed * Time.smoothDeltaTime;
            BarProgress(currentBarLevel);
        }        
        
        void BarProgress(float a)
        {
            slider.value = a;
        }
    }
}
