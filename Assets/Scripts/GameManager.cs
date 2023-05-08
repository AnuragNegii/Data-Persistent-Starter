using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CurrentPlayerName;
    public  int score;

    void Awake()
    {
        CurrentPlayerName = GameObject.Find("Canvas").GetComponent<UIHandler>().PlayerName;

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
