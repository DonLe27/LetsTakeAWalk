using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Mirror;

public class DayCycleController : NetworkBehaviour
{
    /* old version
    // Note: values need to be changed in both the sun and moon objects individually
    public float rotationSpeed; // speedy speedy zoom zoom
    public Vector3 rotationPoint; // center point for directional lights to point toward
    public Vector3 rotationAxis;  // axis by which the sun/moon rotate

    void Update()
    {
        transform.RotateAround(rotationPoint, rotationAxis, rotationSpeed * Time.deltaTime);
        transform.LookAt(rotationPoint);
    }
    */

    // Public Variables
    public float PeriodOfDay; // Period of a full 360 rotation of the sun (in seconds)
    public float RotationAngle; // Angle from which the sun rises
                                // 0 -> sun rises from the +z
                                // 90 -> sun rises from the -x
                                // 180 -> sun rises from the -z
                                // 270 -> sun rises from the +x
    public float MaxFogDensity; // Maximum fog density
    public float Speedup = 1;

    // References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private ParticleSystem StarSystem;
    [SerializeField] private DayCyclePreset Preset;
    [SerializeField] private bool FreezeTime = false;
    [SerializeField] private AudioManager audioManager;

    // Variables
    [SyncVar]
    [SerializeField, Range(0, 24)] private float TimeOfDay;  // Time of Day 0 to 24

    public override void OnStartServer()
    {
        StartFirstDay();
        audioManager.StartGame(); // Sync up audio with time
    }

    void Update()
    {
        if (Preset == null || PeriodOfDay == 0)
        {
            return;
        }

        if (Application.isPlaying)
        {
            if (!FreezeTime)
                TimeOfDay += (Time.deltaTime * 24f / PeriodOfDay) * Speedup;
            if (isServer && TimeOfDay > 24f)
                StartNewDay();
            UpdateLighting(TimeOfDay / 24f);
        }


    }

    public void StartNewDay()
    {
        // Debug.Log("good morning");
        TimeOfDay = 0f;
        FindObjectOfType<SpiritSpawner>().SpawnSpirits();
    }

    private void StartFirstDay()
    {
        TimeOfDay = 7f; // Start at 7am
        FindObjectOfType<SpiritSpawner>().SpawnSpirits();
    }

    private void UpdateLighting(float time)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(time);

        RenderSettings.fogColor = Preset.FogColor.Evaluate(time);
        RenderSettings.fogDensity = Preset.FogDensity.Evaluate(time) * MaxFogDensity;

        DirectionalLight.color = Preset.DirectionalColor.Evaluate(time);
        DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3(-(time * 360f + 90), 0f, 0f) + new Vector3(0, -RotationAngle, 0));

        StarSystem.startColor = new Color(StarSystem.startColor.r, StarSystem.startColor.g, StarSystem.startColor.b, Preset.StarAlpha.Evaluate(time));
    }

    public float GetTimeOfDay() { return TimeOfDay; }
    public float GetCurrentHour() { return (int)TimeOfDay; }
    public float GetCurrentMinute() { return TimeOfDay % 1 * 60; }
    public void SetCurrentTime(int hour, int minute) { TimeOfDay = hour + (minute / 60); }
    public void SetSpeedup(float s) { Speedup = s; }
}
