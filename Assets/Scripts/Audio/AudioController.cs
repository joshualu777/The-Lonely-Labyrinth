using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource source;

    public float volumeController;
    public AudioClip UISFX;
    public AudioClip startSFX;
    public AudioClip endSFX;
    public AudioClip placeLightSFX;
    public AudioClip pickUpLightSFX;

    private static AudioController instance;
    public static AudioController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioController>();
                if (instance == null)
                {
                    GameObject element = new GameObject();
                    element.hideFlags = HideFlags.HideAndDontSave;
                    instance = element.AddComponent<AudioController>();
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("AudioController").Length > 1)
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
    }
    public void playUI()
    {
        source.PlayOneShot(UISFX, volumeController);
    }
    public void playStart()
    {
        source.PlayOneShot(startSFX, volumeController);
    }
    public void playEnd()
    {
        source.PlayOneShot(endSFX, volumeController);
    }
    public void playPlace()
    {
        source.PlayOneShot(placeLightSFX, 5.0f * volumeController);
    }
    public void playPickUp()
    {
        source.PlayOneShot(pickUpLightSFX, volumeController);
    }
}
