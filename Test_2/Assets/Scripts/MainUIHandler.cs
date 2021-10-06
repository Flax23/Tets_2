using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public AudioSource gameAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
        if (MainManager.Instance.gameAudioIsDisabled)
            gameAudio.enabled = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
