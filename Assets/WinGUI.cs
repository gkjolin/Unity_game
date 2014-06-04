using UnityEngine;
using System.Collections;

public class WinGUI : MonoBehaviour
{

    public float ButtonLength = 200f;
    public float ButtonHeight = 50f;
    public float MainMenuButtonPosY = 450f;

    public virtual void Start()
    {
        labX = Screen.width / 2f - ButtonLength / 2f;
        labY = Screen.height / 2f - ButtonHeight / 2f;
    }

   
    public virtual void Update()
    {

    }

    public virtual void OnGUI()
    {
        GUI.Label(new Rect(labX, labY, ButtonLength, ButtonHeight), "You won the game!!!!");

        if(GUI.Button(new Rect(labX, MainMenuButtonPosY, ButtonLength, ButtonHeight),"Main Menu"))
        {
            Application.LoadLevel("MainMenu");
        }
    }

    protected float labX;
    protected float labY;
}
