using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioClip music;
    public AudioSource source;

    void Start()
    {
        source.clip = music;
    }

    // Update is called once per frame
    void Update()
    {
        source.Play();
    }
}
