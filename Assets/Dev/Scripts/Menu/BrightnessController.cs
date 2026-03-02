using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    [SerializeField] private Image brightnessOverlay;
    private const string KEY = "Brightness";

    void Start()
    {
        float value = PlayerPrefs.GetFloat(KEY, 1f);
        GetComponent<Slider>().value = value;
        ApplyBrightness(value);
    }

    public void OnValueChanged(float value)
    {
        ApplyBrightness(value);
        PlayerPrefs.SetFloat(KEY, value);
    }

    void ApplyBrightness(float value)
    {
        Color c = brightnessOverlay.color;
        value = value / 100f;
        c.a = 1f - value;
        brightnessOverlay.color = c;
    }
}