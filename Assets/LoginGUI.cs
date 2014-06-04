using UnityEngine;
using System.Collections;

public class LoginGUI : MonoBehaviour
{
    public float MainMenuButtonPosY = 450f;
    public float IPLabelPosY = 20f;
    public float IPTextFieldPosY = 40f;
    public float PortLablePosY = 70f;
    public float PortTextFieldPosY = 90f;
    public float ConnectButtonPosY = 120f;
    public float ButtonLength = 200f;
    public float ButtonHeight = 50f;

    void Start()
    {
        _x = Screen.width / 2f - ButtonLength / 2f;

        //set default ipv4
        _ip = "127.0.0.1";
        _portStr = "8000";
    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.Label(new Rect(_x, IPLabelPosY, ButtonLength, ButtonHeight / 2f), "Enter IP");
        _ip = GUI.TextField(new Rect(_x, IPTextFieldPosY, ButtonLength, ButtonHeight / 2f), _ip);
        GUI.Label(new Rect(_x, PortLablePosY, ButtonLength, ButtonHeight / 2f), "Enter port");
        _portStr = GUI.TextField(new Rect(_x, PortTextFieldPosY, ButtonLength, ButtonHeight / 2f), _portStr);

        Debug.Log("IP = " + _ip  + "\nPort = " + _portStr);

        if(GUI.Button(new Rect(_x, MainMenuButtonPosY, ButtonLength, ButtonHeight), "Main Menu"))
        {
            Application.LoadLevel("MainMenu");
        }

        if (GUI.Button(new Rect(_x, ConnectButtonPosY, ButtonLength, ButtonHeight), "Connect"))
        {
			Application.LoadLevel("NetGame");
        }
    }

    private string _ip;
    private string _portStr;
    private float _x;
}
