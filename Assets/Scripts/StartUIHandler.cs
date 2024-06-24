using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartUIHandler : MonoBehaviour
{
    public Text BestScorePlayer;
    // Start is called before the first frame update
    void Start()
    {
        BestScorePlayer.text = "Best Score: " + NameManager.Instance.PlayerName + " : " + NameManager.Instance.BestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewNameEntered(Text text)
    {
        NameManager.Instance.NewPlayer = text.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
