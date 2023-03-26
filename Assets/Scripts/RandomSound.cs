using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource[] AllSources;
    private AudioSource RNGSource;
    private AudioSource MultiSourceB;
    public int WhichFolder;
    public List<AudioClip> ClipsToPlay, MultiClipB;
    //public AudioClip prevClip;
    
    void Start()
    {
        AllSources = GetComponents<AudioSource>();
        RNGSource = AllSources[0];
        ClipsToPlay = new List<AudioClip>();
        if (AllSources.Length >= 2)
        {
            MultiSourceB = AllSources[1];
        }

        CheckFolder();
    }

    public void RNGSound()
    {
        CheckFolder();
        RNGSource.clip = ClipsToPlay[Random.Range(0, (ClipsToPlay.Count))];
        RNGSource.Play();
        Debug.Log(gameObject.name + " is now playing: " + RNGSource.clip.name);
    }
    
    public void RNGSoundClose() //USE THIS IF PLAYING TWO DIFFERENT SOUND EFFECTS CLOSE TO ONE ANOTHER
    {
        CheckFolder();
        MultiSourceB.clip = ClipsToPlay[Random.Range(0, (ClipsToPlay.Count))];
        MultiSourceB.Play();
        Debug.Log(gameObject.name + " is now playing, closely behind: " + MultiSourceB.clip.name);
    }

    public void RNGInOrder()
    {
        CheckFolder();
        RNGSource.clip = ClipsToPlay[Random.Range(0, ClipsToPlay.Count)];
        MultiSourceB.clip = MultiClipB[Random.Range(0, MultiClipB.Count)];
        RNGSource.Play();
        Debug.Log("Now playing: " + RNGSource.clip.name);
        MultiSourceB.PlayDelayed(RNGSource.clip.length);
        Debug.Log("and also: " + MultiSourceB.clip.name);
        //prevClip = RNGSource.clip;
    }

    private void CheckFolder()
    {
        ClipsToPlay = new List<AudioClip>();
        switch (WhichFolder) //Set this int manually.
        {
            case 1: //FOOTSTEPS
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/footsteps"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 2: //RUNNING FOOTSTEPS
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/runsteps"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 3: //BEEP
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/beep"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 4: //METAL CLANG
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/clang"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 5: //SWING
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/swings"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 6: //GUN
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/gun"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 7: //SHUFFLE
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/shuffle"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 8: //POWER
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/power"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 9: //DAMAGE
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/damage"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 10: //WHIRR
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/whirr"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 11: //HEAL
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/heal"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 12: //CLANG1
                ClipsToPlay.Add(Resources.Load<AudioClip>("Sounds/Sound Effects/clang/metalclang-01"));
                break;
            case 13: //CLANG2
                ClipsToPlay.Add(Resources.Load<AudioClip>("Sounds/Sound Effects/clang/metalclang-02"));
                break;
            case 14: //MAGIC LOOP
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/magic/b"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 15: //MAGIC SOLO
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/magic/c"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 16: //MAGIC END
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/magic/d"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            default://WEIRD SOUND YOU SHOULDN'T BE ABLE TO HEAR
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/youshouldnthearthis"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
        }
    }

    public void Silence()
    {
        RNGSource.Stop();
        MultiSourceB.Stop();
    }


    public void LoopSwapSecond()
    {
        MultiSourceB.loop = MultiSourceB.loop != true;
    }

  /*  public void FadeOut()
    {
        while (RNGSource.volume > 0)
        {
            RNGSource.volume -= 0.001f; 
        }
        
    }*/
}
    

