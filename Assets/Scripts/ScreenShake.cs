using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CalculateDistance distanceCalculator;
    public Transform player;
    public Transform monster;
    public float maxShakeAmplitude = 12f;
    public float maxShakeFrequency = 12f;
    public float verticalThreshold = -20f;

    private CinemachineBasicMultiChannelPerlin noiseModule;
    private Camera mainCamera;

    void Start()
    {
        if (virtualCamera != null)
        {
            noiseModule = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        if (distanceCalculator == null)
        {
            Debug.LogError("Distance Calculator is not assigned!");
        }

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
        }

        if (noiseModule != null)
        {
            noiseModule.m_AmplitudeGain = 0f;
            noiseModule.m_FrequencyGain = 0f;
        }
    }

    void Update()
    {
        if (noiseModule == null || distanceCalculator == null || mainCamera == null || player == null || monster == null) return;

        float distance = distanceCalculator.GetDistance();
        float verticalDistance = monster.position.y - player.position.y;

        if (distance <= 10 && verticalDistance >= verticalThreshold)
        {
            ApplyShake(distance);
        }
        else
        {
            StopShake();
        }
    }

    private void ApplyShake(float distance)
    {
        float normalizedDistance = Mathf.Clamp01(distance / 10);
        float shakeIntensity = Mathf.Exp(-normalizedDistance * 10);
        shakeIntensity = Mathf.Clamp(shakeIntensity, 0f, 1f);

        noiseModule.m_AmplitudeGain = shakeIntensity * maxShakeAmplitude;
        noiseModule.m_FrequencyGain = shakeIntensity * maxShakeFrequency;
    }

    private void StopShake()
    {
        noiseModule.m_AmplitudeGain = 0f;
        noiseModule.m_FrequencyGain = 0f;
    }
}