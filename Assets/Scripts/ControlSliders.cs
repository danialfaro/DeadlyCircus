using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ControlSliders : MonoBehaviour
{
    public Slider sliderMusica;
    public Slider sliderSonido;
    public AudioMixer miAudioMixer;

    private void Start()
    {
        ActualizarSlidersDesdeMixer();
    }

    private void ActualizarSlidersDesdeMixer()
    {
        float valorMusica, valorSonido;

        miAudioMixer.GetFloat("VolumenMusica", out valorMusica);
        miAudioMixer.GetFloat("VolumenSonido", out valorSonido);

        sliderMusica.value = Remapear(valorMusica, -80f, 20f, 0f, 1f);
        sliderSonido.value = Remapear(valorSonido, -80f, 20f, 0f, 1f);
    }

    public void ActualizarMixerDesdeSliders()
    {
        float valorNormMusica = sliderMusica.value;
        float valorNormSonido = sliderSonido.value;

        float valorRealMusica = Remapear(valorNormMusica, 0f, 1f, -80f, 20f);
        float valorRealSonido = Remapear(valorNormSonido, 0f, 1f, -80f, 20f);

        miAudioMixer.SetFloat("VolumenMusica", valorRealMusica);
        miAudioMixer.SetFloat("VolumenSonido", valorRealSonido);
    }

    private float Remapear(float valor, float rangoMinEntrada, float rangoMaxEntrada, float rangoMinSalida, float rangoMaxSalida)
    {
        return Mathf.Lerp(rangoMinSalida, rangoMaxSalida, Mathf.InverseLerp(rangoMinEntrada, rangoMaxEntrada, valor));
    }
}