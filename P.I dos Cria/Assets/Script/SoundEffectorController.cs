using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundsEffects
{
   //adiconar os nomes do efeitos sonoros
   Die, Shoot
}
[RequireComponent(typeof(AudioSource))]
public class SoundEffectorController : MonoBehaviour
{
    static SoundEffectorController instance;
    AudioSource audioSource;
    [SerializeField] AudioClip[] sounds;
    
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        audioSource = GetComponent<AudioSource>();  
    }
    public  static void  PlaySoundEffect(SoundsEffects soundType)
    {
        instance.audioSource.PlayOneShot(instance.sounds[(int)soundType]);
    }
   // SoundEffectorController.PlaySoundEffect();
}
