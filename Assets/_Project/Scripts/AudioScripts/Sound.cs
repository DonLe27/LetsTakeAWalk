using UnityEngine.Audio;
using UnityEngine;

//display in Unity Editor
[System.Serializable]
public class Sound
{
    public string name;

    //Sound clip to be played
    public AudioClip clip;

    //create slider for volume
    [Range(0f, 1f)]
    public float volume;

    //create slider for pitch
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    //AudioSource won't show in editor
    [HideInInspector]
    //the AudioSource that will be created by AudioManager and will contain this sound
    public AudioSource source;

}