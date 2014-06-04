using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour
{
	private static int currentLevel = 0;
	private String currentLevelName = "lvl1";
	private Dictionary<int, string> avalaibleLevels = new Dictionary<int, String>();

	static LevelManager instance;
	public static LevelManager Instance
	{	
		get		
		{
			if (instance)
				return instance;
			else 
				return instance = (new GameObject("MyClassContainer")).AddComponent<LevelManager>();	
		}
	}
	
	public void loadNextLevel()
	{
		Invoke("LoadWithFadeInAndOut", 2);
    }

	void LoadWithFadeInAndOut() {
		currentLevel++;
		bool isNextLevel = avalaibleLevels.TryGetValue(currentLevel, out currentLevelName);
		if(!isNextLevel)
		{
			currentLevelName = "WinGame";
			currentLevel = 0;
		}
		Application.LoadLevel(currentLevelName);
	}

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    private LevelManager()
    {
        avalaibleLevels.Add(0, "lvl1");
        //avalaibleLevels.Add(1, "lvl2");
        avalaibleLevels.Add(1, "lvl3");
        avalaibleLevels.Add(2, "lvl4");
        avalaibleLevels.Add(3, "bosslevel");

        avalaibleLevels.TryGetValue(currentLevel, out currentLevelName);
    }    
}
