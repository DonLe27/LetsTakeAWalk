using UnityEngine.Audio;
using System;
using UnityEngine;

/*
Audio Manager
=============
The AudioManager object acts as a way to play sounds that are not necessarily tied to a specific object
(e.g. background music, button clicks, actions)

Usage:
-------
To add a sound to play from the AudioManager:
- add a sound file to the Assets/Sounds folder
- go to the AudioManager and add a new sound under Sounds
- drag the audio file into the new entry

To play a sound in a certain script, add the following line:
    FindObjectOfType<AudioManager>().Play("SOUNDNAME");

Adjust volume/pitch/looping of a specific clip using the editor interface on the AudioManager

To play music:
- 

*/


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Awake is called before Start(), so Start() will be able to play sounds
    void Awake()
    {
        //ensure that there is only one AudioManager even if switching scenes adds a new one
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //AudioManager will persist between scenes
        DontDestroyOnLoad(gameObject);

        //for each item added in the sounds array in the editor, create an AudioSource with the designated properties
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    void Start() 
    {
        Play("SpiritedAwayTheme");
    }

    public void Play(string name)
    {
        //grab the sound in the sounds array with the specified name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }
}
