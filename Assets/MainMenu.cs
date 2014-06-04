using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    
    public float SingleButtonPosY = 10f;
    public float MultiButtonPosY = 80f;
    public float ExitButtonPosY = 80f;
    public float ButtonLength = 200f;
    public float ButtonHeight = 50f;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        float cX = Screen.width / 2f - ButtonLength / 2f;
        if(GUI.Button(new Rect(cX, SingleButtonPosY, ButtonLength, ButtonHeight), "Single Player"))
        {
            Application.LoadLevel("lvl1");
        }

		if(GUI.Button(new Rect(cX, Screen.height - ExitButtonPosY, ButtonLength, ButtonHeight), "Exit"))
        {
            Application.Quit();
        }
    }
}
