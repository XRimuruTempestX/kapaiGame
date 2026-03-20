using UnityEngine;
using UnityEngine.Rendering.Universal;
using XUIFramework;

public class AddUICamera : MonoBehaviour
{
    
    public Camera _camera;
    
    private bool isAddUICamera = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAddUICamera)
        {
            if (!_camera.GetUniversalAdditionalCameraData().cameraStack.Contains(UIManager.Instance.uiCamera))
            {
                _camera.GetUniversalAdditionalCameraData().cameraStack.Add(UIManager.Instance.uiCamera);
                isAddUICamera = true;
            }
        }
    }
}
