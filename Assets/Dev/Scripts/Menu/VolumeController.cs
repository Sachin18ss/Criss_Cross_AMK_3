using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    private const string KEY = "Volume";

    void Start()
    {
        float value = PlayerPrefs.GetFloat(KEY, 1f);
        GetComponent<Slider>().value = value;
        AudioListener.volume = value;
    }

    public void OnValueChanged(float value)
    {
        value = value / 100f;
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(KEY, value);
    }
}