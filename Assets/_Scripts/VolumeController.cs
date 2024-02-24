using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource audio1 = null;
    [SerializeField] private AudioSource audio2 = null;
    void Update()
    {
        if (audio1 != null)
            audio1.volume = PlayerPrefs.GetFloat("volume");
        if (audio2 != null)
            audio2.volume = PlayerPrefs.GetFloat("volume");
    }
}
