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
    public AudioSource menuAudio;

    // Start is called before the first frame update
    void Start()
    {
        menuAudio = GetComponent<AudioSource>();
        if (MainManager.Instance.menuAudioIsDisabled)
            menuAudio.enabled = false;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuAudioState()
    {
        menuAudio.enabled = !menuAudio.enabled;
        MainManager.Instance.menuAudioIsDisabled = !menuAudio.enabled;
    }

    public void GameAudioState()
    {
        MainManager.Instance.gameAudioIsDisabled = !MainManager.Instance.gameAudioIsDisabled;
    }

    public void Exit()
    {
        MainManager.Instance.SaveSoundState();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    
}
