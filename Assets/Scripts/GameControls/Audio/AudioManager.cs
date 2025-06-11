using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private AudioMixer _audioMixer;

    [Header("Volume Controls")]
    public List<VolumeControl> volumeControls = new List<VolumeControl>();

    private void Start()
    {
        InitializeVolumeControls();
    }

    private void InitializeVolumeControls()
    {
        foreach (VolumeControl control in volumeControls)
        {
            if (control._slider != null && control._volumeText != null)
            {
                float initialVolume;
                bool result = _audioMixer.GetFloat(control._parameterName, out initialVolume);

                if (result)
                {
                    control._slider.value = initialVolume;
                    UpdateVolumeText(control, initialVolume);
                }

                control._slider.onValueChanged.AddListener(value => OnSliderValueChanged(control, value));
            }
        }
    }

    public void OnSliderValueChanged(VolumeControl control, float value)
    {
        _audioMixer.SetFloat(control._parameterName, value);
        UpdateVolumeText(control, value);
    }

    private void UpdateVolumeText(VolumeControl control, float volumeInDecibels)
    {
        float volumePercentage = Mathf.Clamp01((volumeInDecibels + Mathf.Abs(control._slider.minValue)) / Mathf.Abs(control._slider.minValue)) * 100f;
        control._volumeText.text = Mathf.RoundToInt(volumePercentage).ToString();
    }
}