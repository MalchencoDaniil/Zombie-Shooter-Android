using TMPro;
using System;
using UnityEngine.UI;

[Serializable]
public struct VolumeControl
{
    public string _parameterName;
    public Slider _slider;
    public TextMeshProUGUI _volumeText;
}