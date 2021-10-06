using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    private AudioSource menuAudio;
    bool audioState = true;

    // Start is called before the first frame update
    void Start()
    {
        menuAudio = GetComponent<AudioSource>();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuAudioSource()
    {
        if (audioState)
        {
            menuAudio.Stop();
            audioState = false;
        }
        else
        {
            menuAudio.Play();
            audioState = true;
        } 
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
