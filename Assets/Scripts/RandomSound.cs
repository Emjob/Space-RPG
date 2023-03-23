using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource[] AllSources;
    private AudioSource RNGSource;
    private AudioSource MultiSourceB;
    public int WhichFolder;
    public List<AudioClip> ClipsToPlay;
    private AudioClip[] ClipsInFolder;
    public AudioClip[] MultiClipA, MultiClipB;
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
        Debug.Log("Now playing: " + RNGSource.clip.name);
    }
    
    public void RNGSoundClose() //USE THIS IF PLAYING TWO DIFFERENT SOUND EFFECTS CLOSE TO ONE ANOTHER
    {
        CheckFolder();
        MultiSourceB.clip = ClipsToPlay[Random.Range(0, (ClipsToPlay.Count))];
        MultiSourceB.Play();
    }

    public void RNG2Sounds()
    {
        CheckFolder();
        RNGSource.clip = MultiClipA[Random.Range(0, MultiClipA.Length)];
        MultiSourceB.clip = MultiClipB[Random.Range(0, MultiClipB.Length)];
        RNGSource.Play();
        MultiSourceB.PlayDelayed(RNGSource.clip.length);
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
            default:
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
    }


    public void LoopSwapSecond()
    {
        if (MultiSourceB.loop = true)
        {
            MultiSourceB.loop = false;
        }
        else
        {
            MultiSourceB.loop = true;
        }
    }
}
    

