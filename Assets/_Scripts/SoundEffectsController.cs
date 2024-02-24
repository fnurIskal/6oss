using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    [SerializeField] private AudioSource audio1;
    [SerializeField] private AudioSource audio2;
    [SerializeField] private AudioSource audio3;
    [SerializeField] private AudioSource audio4;
    [SerializeField] private AudioSource audio5;
    [SerializeField] private AudioSource audio6;
    [SerializeField] private AudioSource audio7;
    [SerializeField] private AudioSource audio8;
    [SerializeField] private AudioSource audio9;
    [SerializeField] private AudioSource audio10;
    [SerializeField] private AudioSource audio11;
    [SerializeField] private AudioSource audio12;
    [SerializeField] private AudioSource audio13;
    [SerializeField] private AudioSource audio14;
    [SerializeField] private AudioSource audio15;
    [SerializeField] private AudioSource audio16;
    void Start()
    {
        audio1.volume = PlayerPrefs.GetFloat("volume");
        audio2.volume = PlayerPrefs.GetFloat("volume");
        audio3.volume = PlayerPrefs.GetFloat("volume");
        audio4.volume = PlayerPrefs.GetFloat("volume");
        audio5.volume = PlayerPrefs.GetFloat("volume");
        audio6.volume = PlayerPrefs.GetFloat("volume");
        audio7.volume = PlayerPrefs.GetFloat("volume");
        audio8.volume = PlayerPrefs.GetFloat("volume");
        audio9.volume = PlayerPrefs.GetFloat("volume");
        audio10.volume = PlayerPrefs.GetFloat("volume");
        audio11.volume = PlayerPrefs.GetFloat("volume");
        audio12.volume = PlayerPrefs.GetFloat("volume");
        audio13.volume = PlayerPrefs.GetFloat("volume");
        audio14.volume = PlayerPrefs.GetFloat("volume");
        audio15.volume = PlayerPrefs.GetFloat("volume");
        audio16.volume = PlayerPrefs.GetFloat("volume");
    }
    void Update()
    {
        audio1.volume = PlayerPrefs.GetFloat("volume");
        audio2.volume = PlayerPrefs.GetFloat("volume");
        audio3.volume = PlayerPrefs.GetFloat("volume");
        audio4.volume = PlayerPrefs.GetFloat("volume");
        audio5.volume = PlayerPrefs.GetFloat("volume");
        audio6.volume = PlayerPrefs.GetFloat("volume");
        audio7.volume = PlayerPrefs.GetFloat("volume");
        audio8.volume = PlayerPrefs.GetFloat("volume");
        audio9.volume = PlayerPrefs.GetFloat("volume");
        audio10.volume = PlayerPrefs.GetFloat("volume");
        audio11.volume = PlayerPrefs.GetFloat("volume");
        audio12.volume = PlayerPrefs.GetFloat("volume");
        audio13.volume = PlayerPrefs.GetFloat("volume");
        audio14.volume = PlayerPrefs.GetFloat("volume");
        audio15.volume = PlayerPrefs.GetFloat("volume");
        audio16.volume = PlayerPrefs.GetFloat("volume");
    }
}
