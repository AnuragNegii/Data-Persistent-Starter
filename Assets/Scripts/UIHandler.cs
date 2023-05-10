using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    void Start()
    {
        highScoreText.text = "High Score : " + GameManager.Instance.NewHighScorePlayerName + " : " + GameManager.Instance.NewHighScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GetName()
    {
        GameManager.Instance.CurrentPlayerName = nameText.text;
    }
}
