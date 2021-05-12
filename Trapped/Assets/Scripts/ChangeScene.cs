using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public AudioSource audio;
    public AudioClip death;

    void Start()
    {
        audio.Play();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
