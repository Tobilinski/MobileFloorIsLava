using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(EnterLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(EnterLevel);
        quitButton.onClick.RemoveListener(QuitGame);
    }

    private void EnterLevel()
    {
        SceneManager.LoadScene("Game");
    }
    private void QuitGame()
    {
       Application.Quit();
    }
}
