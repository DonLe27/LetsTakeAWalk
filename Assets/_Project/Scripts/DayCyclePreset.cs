using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="Lighting Preset", menuName="Scriptables/Lighting Preset", order=1)]
public class DayCyclePreset : ScriptableObject
{
    public Gradient AmbientColor;       // Ambient Lighting Color
    public Gradient DirectionalColor;   // Directional Lighting (Sun) Color
    public Gradient FogColor;           // Atmospheric Fog Color
    public AnimationCurve FogDensity;   // Atmospheric Fog Density
    public AnimationCurve StarAlpha;    // Star Transparency
}
