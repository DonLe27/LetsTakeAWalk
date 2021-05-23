
using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public string defaultSound;
    private string currentSound;

    public static AudioManager instance;

    void Awake() {
        //check if an AudioManager is in the current scene, if so then destroy the current one
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
            s.source.loop = s.loop;
        }
        //song that will play first
        defaultSound = "arpeggios";
    }
    void Start()
    {
        currentSound = defaultSound;
        Play(defaultSound);
        SwapTrack("rests");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //play song given name
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
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
        if(currentSound != newSound)
        {
            StopAllCoroutines();
            StartCoroutine(FadeToTrack(newSound));
        }
    }

    //play default song
    public void ReturnToDefault()
    {
        SwapTrack(defaultSound);
    }

    private IEnumerator FadeToTrack(string newSong) 
    {
        Sound oldSong = Array.Find(sounds, sound => sound.name == currentSound);
        if(oldSong == null)
        {
            Debug.LogWarning("Sound: " + currentSound + " not found!");
            yield return null;
        }
        Debug.Log("Sound: " + currentSound + " fading");

        float timeToFade = 2f;
        float timeElapsed = 0;
        
        //fade old song out
        while(timeElapsed < timeToFade)
        {
            oldSong.source.volume = Mathf.Lerp(.1f, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        oldSong.source.Stop();
        //reset oldSong's volume for the next time it plays
        oldSong.source.volume = .1f;

        //wait for 3 seconds before playing the next song
        yield return new WaitForSeconds(3);
        Play(newSong);

        Sound song = Array.Find(sounds, sound => sound.name == newSong);
        timeElapsed = 0;
        while(timeElapsed < timeToFade)
        {
            song.source.volume = Mathf.Lerp(0, .1f, timeElapsed/timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }



    }


}

