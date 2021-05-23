
using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*

AudioManager
=============
Usage: Play and transition between background music

How to Use:
If you want to add an area where a different song from the default song (specified in Awake()) is played, do the following:
- add your song to the Sounds folder
- go to the AudioManager editor and add a sound to its sounds array, dragging in your song and specifying volume/pitch/name
- add a box collider in the intended area, and add the AudioSwap script from the AudioScripts folder to it
- in the box collider editor, specify the name of the song you want to switch to

When the player enters this area:
- the current song will fade out in 2 seconds
- 3 seconds later the new song will fade in in 2 seconds
When the player leaves the area:
- the song will fade out in 2 seconds
- 3 seconds later the default song will fade in in 2 seconds

*/



public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public string defaultSound;
    private string currentSound;

    public static AudioManager instance;
    private DayCycleController dayCycleController = null;

    public bool inSpecialArea = false;
    private string curSong = "arpeggios";

    private string arpSong = "arpeggios";
    private string restSong = "rests";
    [SerializeField] private float morningStart = 0;
    [SerializeField] private float morningEnd = 12;

    void Awake()
    {
        //check if an AudioManager is in the current scene, if so then destroy the current one
        if (instance == null)
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
            s.source.loop = s.loop;
        }
        //song that will play first
        defaultSound = arpSong;
    }
    void Start()
    {
        currentSound = defaultSound;
        Play(defaultSound);
    }

    public void StartGame()
    {
        dayCycleController = GameObject.Find("DayManager").GetComponent<DayCycleController>();
    }

    void PlayTimeBasedSong()
    {
        if (dayCycleController == null) return;
        if (!inSpecialArea)
        {

            float currentTime = dayCycleController.GetTimeOfDay();
            if (currentTime >= morningStart && currentTime <= morningEnd && curSong != arpSong) // Using currentSong didn't work because of fading?
            {
                curSong = arpSong;
                SwapTrack(arpSong);
            }
            else if ((currentTime >= morningEnd || currentTime <= morningStart) && curSong != restSong)
            {
                curSong = restSong;
                SwapTrack(restSong);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        PlayTimeBasedSong();
    }
    //play song given name
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        currentSound = name;
        Debug.Log("Sound: " + name + " playing");
        s.source.Play();
    }

    //switch the current song to something else; fade out the old one
    public void SwapTrack(string newSound)
    {
        if (currentSound != newSound)
        {
            // Debug.Log("swapping tracks");
            StopAllCoroutines();
            StartCoroutine(FadeToTrack(newSound));
        }
    }


    //play default song
    public void ReturnToDefault()
    {
        PlayTimeBasedSong();
    }

    private IEnumerator FadeToTrack(string newSong)
    {
        float timeToFade = 2f;
        float timeElapsed = 0;

        Sound oldSong = Array.Find(sounds, sound => sound.name == currentSound);
        float oldVol = oldSong.source.volume;

        if (oldSong == null)
        {
            Debug.LogWarning("Sound: " + currentSound + " not found!");
            yield return null;
        }
        // Debug.Log("Sound: " + currentSound + " fading");



        //fade old song out
        while (timeElapsed < timeToFade)
        {
            oldSong.source.volume = Mathf.Lerp(oldVol, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        oldSong.source.Stop();
        oldSong.source.volume = oldVol;
        //reset oldSong's volume for the next time it plays
        oldSong.source.volume = .1f;

        //wait for 1 seconds before playing the next song
        yield return new WaitForSeconds(2);
        Play(newSong);

        //fade in the new song in the same way
        Sound song = Array.Find(sounds, sound => sound.name == newSong);
        float newVol = song.source.volume;
        timeElapsed = 0;
        while (timeElapsed < timeToFade)
        {
            song.source.volume = Mathf.Lerp(0, newVol, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }


}

