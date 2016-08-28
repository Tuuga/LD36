using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class TriggeriScripti : MonoBehaviour
{

    public AudioMixerSnapshot mix1;
    public AudioMixerSnapshot mix2;
    public AudioMixerSnapshot mix3;
    public float transitiontime;

    // Use this for initialization

    void OnTriggerEnter(Collider c) 
    {
    if (c.tag == "Player")
        {
            mix1.TransitionTo(transitiontime);
            print("triggasi");
        }      
   
        }

    }

