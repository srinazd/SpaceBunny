
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class CameraPostProcessing : MonoBehaviour
{
    public Volume globalVolume;

    private Vignette vignette;
    private ColorAdjustments colorAdjustments;

    private float normalVignette;
    private float normalSaturation;
    private Color normalColorFilter;

    private Coroutine activeEffect;

    void Awake()
    {
        if (globalVolume == null)
        {
            Debug.LogError("Global Volume is not assigned!");
            return;
        }

        if (!globalVolume.profile.TryGet(out vignette) ||
            !globalVolume.profile.TryGet(out colorAdjustments))
        {
            Debug.LogError("Add Vignette and Color Adjustments to the Volume Profile!");
            return;
        }

        normalVignette = vignette.intensity.value;
        normalSaturation = colorAdjustments.saturation.value;
        normalColorFilter = colorAdjustments.colorFilter.value;

        vignette.intensity.overrideState = true;
        colorAdjustments.saturation.overrideState = true;
        colorAdjustments.colorFilter.overrideState = true;
    }

    public void PlayScoreEffect()
    {
        StartEffect(
            new Color(0.8f, 1f, 0.85f),
            0.3f,
            15f,
            0.2f
        );
    }

    public void PlayHitEffect()
    {
        StartEffect(
            new Color(1f, 0.45f, 0.45f),
            0.55f,
            -25f,
            0.35f
        );
    }

    void StartEffect(Color filter, float vignetteValue,
                     float saturationValue, float duration)
    {
        if (vignette == null || colorAdjustments == null)
            return;

        if (activeEffect != null)
        {
            StopCoroutine(activeEffect);
        }

        activeEffect = StartCoroutine(
            EffectRoutine(filter, vignetteValue, saturationValue, duration)
        );
    }

    IEnumerator EffectRoutine(Color filter, float vignetteValue,
                               float saturationValue, float duration)
    {
        colorAdjustments.colorFilter.value = filter;
        vignette.intensity.value = vignetteValue;
        colorAdjustments.saturation.value = saturationValue;

        yield return new WaitForSecondsRealtime(duration);

        ResetEffects();
        activeEffect = null;
    }

    public void PlayGameOverEffect()
    {
        if (vignette == null || colorAdjustments == null)
            return;

        if (activeEffect != null)
        {
            StopCoroutine(activeEffect);
            activeEffect = null;
        }

        colorAdjustments.colorFilter.value =
            new Color(0.8f, 0.35f, 0.35f);

        vignette.intensity.value = 0.6f;
        colorAdjustments.saturation.value = -40f;
    }

    void ResetEffects()
    {
        vignette.intensity.value = normalVignette;
        colorAdjustments.saturation.value = normalSaturation;
        colorAdjustments.colorFilter.value = normalColorFilter;
    }
}
