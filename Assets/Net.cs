using UnityEngine;
using System.Collections;
using System.Text;
using System.Net.Sockets;

public class Net : MonoBehaviour
{

    public string Ip
    {
        get
        {
            return _ip;
        }
        set
        {
            _ip = value;
        }
    }

    public int Port
    {
        get
        {
            return _port;
        }
        set
        {
            _port = value;
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }

    void Connect()
    {
        socket.Connect(_ip, _port);
    }

    private UdpClient socket = new UdpClient();

    private string _ip = "127.0.0.1";
    private int _port = 8000;
}
