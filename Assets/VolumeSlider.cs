using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI volumeNumber;
    
    public void SetVolume(float volume)
    {
        volumeNumber.text = volume.ToString();
        
    }
}