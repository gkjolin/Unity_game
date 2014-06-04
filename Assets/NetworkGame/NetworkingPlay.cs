using UnityEngine;
using System.Collections;
using SocketIOClient;
using MiniJSON;
using System;

public class NetworkingPlay : MonoBehaviour {
	
	private Client client;
	private ArrayList playersArray;

	private ArrayList frameList;
	private int lastindex;
	private int lastlastindex;
	private int frameIndex = 0;

	public GameObject objCreate;

	void Start () {
		playersArray = new ArrayList();
		frameList = new ArrayList();

		lastlastindex = -1;
		lastindex = -1;

		string socketUrl = "http://127.0.0.1:8000";	//TODO: get it from gui
		Debug.Log("Socket current url: " + socketUrl);
		this.client = new Client(socketUrl);
		this.client.Opened += SocketOpened;
		this.client.Message += SocketMessage;
		this.client.SocketConnectionClosed += SocketConnectionClosed;
		this.client.Error += SocketError;
		
		this.client.Connect();
		Debug.Log("Its connecteds");
	}
	
	private void SocketOpened(object sender, System.EventArgs e) {
		Debug.Log("Whoa socket is opened!");
	}
	
	private void SocketMessage(object sender, SocketIOClient.MessageEventArgs e) {
		if ( e!=null && e.Message != null) {
			IDictionary search = (IDictionary) Json.Deserialize(e.Message.MessageText);
			if (search != null) {
				if (String.Equals(search["name"], "msg")) {
					frameList.Add(new Frame((IList)search["args"]));
					lastindex++;
					lastlastindex = lastindex - 1;
					frameIndex = 0;
				} else if (String.Equals(search["name"], "new player")) {
					IList hashedIds = (IList)search["args"];
					Debug.Log(e.Message.MessageText);
					playersArray.Add(new NPlayer(hashedIds[0].ToString(), objCreate));
				} else if (String.Equals(search["name"], "remove player")) {
					IList hashedId = (IList)search["args"];
					foreach ( NPlayer player in playersArray) {
						if(String.Equals(player.id, hashedId)) {
							playersArray.Remove(player);
							break;
						}
					}
				}
			}
		}
	}
	
	private void SocketConnectionClosed(object sender, System.EventArgs e) {
		Debug.Log("Connection closed!");
	}
	
	private void SocketError(object sender, System.EventArgs e) {
		Debug.Log("Error occured!");
	}
	
	void OnDestroy () {
		client.Close();
		Debug.Log("Network client was destroyed");
	}
	
	// Update is called once per frame
	void Update () {
		//skit first invalid frames
		if (this.lastindex == -1 || this.lastlastindex == -1) return;

		foreach (NPlayer player in playersArray) {
			Frame frame = this.frameList[this.lastindex] as Frame;
			Frame prevFrame = this.frameList[this.lastlastindex] as Frame;
			float interp = this.frameIndex / 15.0f;
			player.update(frame, prevFrame, interp);
		}
		this.frameIndex++;
	}
}
