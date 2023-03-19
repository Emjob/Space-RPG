using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource[] AllSources;
    private AudioSource RNGSource;
    private AudioSource MultiSourceB;
    public int WhichFolder;
    public AudioClip[] ClipsToPlay;
    public AudioClip[] MultiClipA, MultiClipB;
    //public AudioClip prevClip;
    
    void Start()
    {
        AllSources = GetComponents<AudioSource>();
        RNGSource = AllSources[0];
        if (AllSources.Length >= 2)
        {
            MultiSourceB = AllSources[1];
        }

        CheckFolder();
    }

    public void RNGSound()
    {
        RNGSource.clip = ClipsToPlay[Random.Range(0, (ClipsToPlay.Length))];
        RNGSource.Play();
    }

    public void RNG2Sounds()
    {
        RNGSource.clip = MultiClipA[Random.Range(0, MultiClipA.Length)];
        MultiSourceB.clip = MultiClipB[Random.Range(0, MultiClipB.Length)];
        RNGSource.Play();
        MultiSourceB.PlayDelayed(RNGSource.clip.length);
        //prevClip = RNGSource.clip;
    }

    private void CheckFolder()
    {
        switch (WhichFolder) //Set this int manually.
        {
            case 1: //FOOTSTEPS
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/footsteps");
                break;
            case 2: //RUNNING FOOTSTEPS
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/runsteps");
                break;
            case 3: //BEEP
               ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/beep");
                break;
            case 4: //METAL CLANG
               // ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/clang");
                break;
            case 5: //SWING
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/swing");
                break;
            case 6: //GUN
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/gun");
                break;
            case 7: //SHUFFLE
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/shuffle");
                break;
            default:
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sounds/Sound Effects/youshouldnthearthis");
                break;
        }
    }



}
    

