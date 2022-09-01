using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Audio;

public class AudioClipManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip clip;
        public AudioSource source;
    }
    public SoundData[] soundArray;

    private AudioSource audio;
    
    void Awake()
    {
        foreach(SoundData sound in soundArray)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
        
    }

    public void Play(string name)
    {
        SoundData sound = Array.Find(soundArray, soundArray => soundArray.name == name);
        sound.source.Play();
    }

    public void PlayOneShot(string name)
    {
        SoundData sound = Array.Find(soundArray, soundArray => soundArray.name == name);
        sound.source.PlayOneShot(sound.clip);
    }

    public void StopSound(string name)
    {
        SoundData sound = Array.Find(soundArray, soundArray => soundArray.name == name);
        sound.source.Stop();
    }
}
