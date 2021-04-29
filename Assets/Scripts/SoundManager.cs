using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    private bool isMute = false;
    public float VolumeSfx = 1f;
    public float VolumeMusic = 1f;

    public SoundType[] Sound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    { 
        PlayMusic(Sounds.Music);
    }

    public void Mute(bool status)
    {
        isMute = status;
    }
    public void SetVolumeMusic(float volume)
    {
        VolumeMusic = volume;
        soundMusic.volume = VolumeMusic;
    }
    public void SetVolumeSfx(float volume)
    {
        VolumeSfx = volume;
        soundEffect.volume = VolumeSfx;
    }

    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound type " + sound);
        }
    }

    public void Play(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type " + sound);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sound, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    ButtonClickBack,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    KeyCollect,
}

