using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum SoundType
{
    CLICK,
    SOLVED,
}
public class SoundCollection
{
    private AudioClip[] clips;
    private int lastClipIndex;

    public SoundCollection(string[] clipNames)
    {
        this.clips = new AudioClip[clipNames.Length];
        for (int i = 0; i < clipNames.Length; i++)
        {
            clips[i] = Resources.Load(clipNames[i]) as AudioClip;
            if (clips[i] == null)
            {
                Debug.Log($"can't find audio clip {clipNames[i]}");
            }
        }
        lastClipIndex = -1;
    }

    public AudioClip GetRandomClip()
    {
        if(clips.Length == 0)
        {
            Debug.Log("No clips to give");
            return null;
        }
        else if(clips.Length == 1)
        {
            return clips[0];
        }
        else
        {
            int index = lastClipIndex;
            while (index == lastClipIndex)
            {
                Random.Range(0, clips.Length);
            }
            lastClipIndex = index;
            return clips[index];
        }
            
    }
}

public class SoundManager : MonoBehaviour
{
    public float mainVolume = 1.0f;
    private Dictionary<SoundType, SoundCollection> sounds;
    private AudioSource audioSrc;

    public static SoundManager instance {  get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        audioSrc = GetComponent<AudioSource>();
        sounds = new()
        {
            {SoundType.CLICK, new(new string[] {"clicks/click_1,clicks/click_2,clicks/click_3,clicks/click_4,"}) },
            {SoundType.SOLVED, new(new string[] {"solved"}) },
        };
    }

    public void Play(SoundType type, AudioSource audioSrc = null)
    {
        if (sounds.ContainsKey(type))
        {
            if (audioSrc == null) 
            {
                audioSrc = this.audioSrc;
            }
            audioSrc.volume = Random.Range(.75f, 1.0f) * mainVolume;
            audioSrc.clip = sounds[type].GetRandomClip();
            audioSrc.Play();

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
