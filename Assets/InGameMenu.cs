using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour
{
    public float ButtonLength = 200f;
    public float ButtonHeight = 50f;

 
   
    void Start()
    {
        _isMenuVisible = false;
        _x = Screen.width / 2f - ButtonLength / 2f;
        _y = Screen.height / 2f - ButtonHeight / 2f;
    }


    void Update()
    {
        if(!_isMenuVisible)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                _isMenuVisible = true;
                timeScaleOriginal = Time.timeScale;
                Time.timeScale = 0f;
            }
        }
    }

    void OnGUI()
    {
        if(_isMenuVisible)
        {
            if(GUI.Button(new Rect(_x, _y - 25f, ButtonLength, ButtonHeight), "Resume"))
            {
                _isMenuVisible = false;
                Time.timeScale = timeScaleOriginal;
            }
            if(GUI.Button(new Rect(_x, _y + 25f, ButtonLength, ButtonHeight), "Main Menu"))
            {
                _isMenuVisible = false;
                Time.timeScale = timeScaleOriginal;
                Application.LoadLevel("MainMenu");
            }
        }
    }

    private float _x;
    private float _y;
    private float timeScaleOriginal = 0.0f;
    private bool _isMenuVisible;
}
