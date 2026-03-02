using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class VolumeController : MonoBehaviour
{
    private const string KEY = "Volume";
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();

        // Load normalized value (0–1)
        float normalized = PlayerPrefs.GetFloat(KEY, 1f);

        // Set slider (0–100)
        _slider.value = normalized * 100f;

        // Apply volume (0–1)
        AudioListener.volume = normalized;
    }


    public void OnValueChanged(float sliderValue)
    {
        // Convert slider (0–100) → normalized (0–1)
        float normalized = sliderValue / 100f;

        AudioListener.volume = normalized;
        PlayerPrefs.SetFloat(KEY, normalized);
    }
}