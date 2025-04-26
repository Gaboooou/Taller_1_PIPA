using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource controlSonido;
    [SerializeField] private AudioClip[] sound;

    
    private void Awake()
    {
        controlSonido = GetComponent<AudioSource>();
    }

    public void PlaySound(int sonido){

        controlSonido.PlayOneShot(sound[sonido]);
    }


}
