using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienceController : MonoBehaviour
{
    AudioSource source;

    public AudioClip clockAmbience;

    private static AmbienceController instance;
    public static AmbienceController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AmbienceController>();
                if (instance == null)
                {
                    GameObject element = new GameObject();
                    element.hideFlags = HideFlags.HideAndDontSave;
                    instance = element.AddComponent<AmbienceController>();
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("AmbienceController").Length > 1)
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
    }
    public void playClock(AudioClip prevClip)
    {
        source.clip = clockAmbience;
        source.PlayDelayed(prevClip.length + 0.5f);
    }
    public void stopClock()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
    }
}
