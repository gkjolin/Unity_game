using UnityEngine;
using System.Collections;

public class PointsUpdateScript : MonoBehaviour
{

    public int MaxLevelPoints = 25;
	private bool _isLoadingNextLevel = false;
    void Start()
    {
        _textMesh = GetComponent<TextMesh>();
        _textMesh.text = "Points: " + _points;
		Fader.get().setState(Fader.Fade.Out);
		_isLoadingNextLevel = false;
	}

    void OnEnable()
    {
        BulletAI.OnAddPoint += AddPoint;
    }


    void OnDisable()
    {
        BulletAI.OnAddPoint -= AddPoint;
    }

    void Update()
    {}

	public void OnGUI(){
		if (_points == MaxLevelPoints) {
			if (!_isLoadingNextLevel){
				_isLoadingNextLevel = true;
				Fader.get().setState(Fader.Fade.In);
				LevelManager.Instance.loadNextLevel();
			}
		}

		Fader.get().Update();
	}

    void AddPoint()
    {
        _textMesh.text = "Points: " + ++_points;
    }

    private TextMesh _textMesh;
    private uint _points = 0;
}
