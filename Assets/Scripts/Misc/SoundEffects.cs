using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource Source;
    private L1TimeEvents _l1TimeEvents;
    
    void Start()
    {
        _l1TimeEvents = FindObjectOfType<L1TimeEvents>();
        _l1TimeEvents.lightout += playsound;
    }

    private void playsound()
    {
        StopCoroutine(PlaySounds());
    }
    IEnumerator PlaySounds()
    {
        int i = 0;
        
        while (true)
        {
            
            Source.clip = sounds[i];
            Source.Play();
            yield return new WaitForSeconds(20);
            i += i % sounds.Length;
        }
    }
}
