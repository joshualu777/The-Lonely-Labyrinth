using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    AudioSource source;

    public AudioClip UIMusic;
    public AudioClip gameMusic;

    private static BGMController instance;
    public static BGMController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BGMController>();
                if (instance == null)
                {
                    GameObject element = new GameObject();
                    element.hideFlags = HideFlags.HideAndDontSave;
                    instance = element.AddComponent<BGMController>();
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("BGMController").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.loop = true;
        playUI(AudioController.Instance.UISFX);
    }
    public void playUI(AudioClip prevClip)
    {
        source.clip = UIMusic;
        source.PlayDelayed(prevClip.length + 0.5f);
        if (SceneManager.GetActiveScene().name == "Game")
        {
            AmbienceController.Instance.stopClock();
        }
    }
    public void playGame(AudioClip prevClip)
    {
        source.clip = gameMusic;
        source.PlayDelayed(prevClip.length + 0.5f);
        AmbienceController.Instance.playClock(prevClip);
    }
}
