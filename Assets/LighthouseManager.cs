using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class LighthouseManager : MonoBehaviour
{
    [SerializeField] private DayCycleController dayCycleController;
    [SerializeField] private Bloom bloom;
    [SerializeField] private float morningStart = 0;
    [SerializeField] private float dayEnd = 20;
    private Volume v;

    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out bloom);
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = dayCycleController.GetTimeOfDay();
        Debug.Log(currentTime);
        if (currentTime >= morningStart && currentTime <= dayEnd)
        {
            bloom.active = false;
        }
        else
        {
            bloom.active = true;
        }
    }
}
