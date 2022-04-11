using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public Slider Volume;
    public GameObject VolumePercentage;
   public void VolumeChanger()
    {
         VolumePercentage.GetComponent<TMPro.TextMeshProUGUI>().text= (Mathf.RoundToInt(Volume.value*100)).ToString() + "%";
    }
}
