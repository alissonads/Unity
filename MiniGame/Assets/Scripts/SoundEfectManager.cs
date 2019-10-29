using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfectManager : MonoBehaviour, 
                                 IListenerOfActionOfCollision, 
                                 IListenerOfAttackAction
{
    public AudioClip []audioClips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioClip(int index)
    {
        audioSource.PlayOneShot(audioClips[index], 1.0f);
    }

    public void CollisionAction(params object[] events)
    {
        var obj1 = events[0] as BulletScript;
        var obj2 = events[1] as GameObject;

        if (obj1.Direction == BulletDirection.DOWN)
        {
            if (obj2.tag == "Player")
                PlayAudioClip(0);
        }
        else
        {
            if (obj2.tag == "Enemy")
                PlayAudioClip(0);
        }
    }

    public void AttackAction(params object[] events)
    {
        PlayAudioClip(1);
    }
}
