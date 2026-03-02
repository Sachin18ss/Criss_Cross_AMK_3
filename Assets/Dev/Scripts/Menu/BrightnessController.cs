using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    [SerializeField] private Image brightnessOverlay;
    private const string KEY = "Brightness";
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();

        float normalized = PlayerPrefs.GetFloat(KEY, 0.5f);

        _slider.value = normalized * 100f;
        ApplyBrightness(normalized);
    }

    public void OnValueChanged(float sliderValue)
    {
        float normalized = Mathf.Clamp(sliderValue / 100f, 0.2f, 1f);
        ApplyBrightness(normalized);
        PlayerPrefs.SetFloat(KEY, normalized);
    }

    void ApplyBrightness(float value)
    {
        
        Color c = brightnessOverlay.color;
        c.a = 1f - value;
        brightnessOverlay.color = c;
    }
}