using UnityEngine;
using System.Collections;

public class GameOverGUI : WinGUI
{
   
   
    public override void Start()
    {
        base.Start();
    }

    
    public override void Update()
    {

    }

    public override void OnGUI()
    {
        GUI.Label(new Rect(labX, labY, ButtonLength, ButtonHeight), "GameOver");

        if (GUI.Button(new Rect(labX, MainMenuButtonPosY, ButtonLength, ButtonHeight), "Main Menu"))
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
