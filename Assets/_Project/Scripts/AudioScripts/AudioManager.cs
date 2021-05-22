
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public string defaultSound;
    private string currentSound;

    public static AudioManager instance;

    void Awake() {

        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        defaultSound = "arpeggios";
    }
    void Start()
    {
        SwapTrack(defaultSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void SwapTrack(string newClip)
    {
        if(currentSound != newClip)
        {
            currentSound = newClip;
            Play(newClip);
        }
    }

    public void ReturnToDefault()
    {
        SwapTrack(defaultSound);
    }


}

