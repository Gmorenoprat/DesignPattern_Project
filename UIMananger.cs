using UnityEngine;
using UnityEngine.UI;

public class UIMananger : MonoBehaviour
{
    public Text scoreText;
    public static UIMananger Instance
    {
        get { return _instance; }
    }
    static UIMananger _instance;

    public void Awake()
    {
        _instance = this;
    }

    public void ActualizarScore(string score)
    {
        scoreText.text = score;
    }

}
