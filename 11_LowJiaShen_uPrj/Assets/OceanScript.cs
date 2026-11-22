using UnityEngine;
using UnityEngine.Rendering;

public class OceanScript : MonoBehaviour
{
    [SerializeField] private Volume postProcessingVolume;
    [SerializeField] private Transform Camera;
    [SerializeField] private int depth;
    [SerializeField] private VolumeProfile surfacePostProcessing;
    [SerializeField] private VolumeProfile underwaterPostProcessing;


    private void Update()
    {
        if (Camera.position.y < depth)
        {
            print("under");
            EnableEffects(true);
        }
        else {
            print("over");
            EnableEffects(false);
        }
    }

    private void EnableEffects(bool active)
    {
        if (active)
        {
            RenderSettings.fog = true;
            postProcessingVolume.profile = underwaterPostProcessing;
        }
        else
        {
            RenderSettings.fog = false;

            postProcessingVolume.profile = surfacePostProcessing;
        }
    }
}
