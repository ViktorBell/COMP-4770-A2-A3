using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    private void Start()
    {
        currentCameraIndex = 0;
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("CamSwitch1"))
        {
            SwitchToCamera(0);
        }
        else if (Input.GetKeyDown("CamSwitch2"))
        {
            SwitchToCamera(1);
        }
        else if (Input.GetKeyDown("CamSwitch3"))
        {
            SwitchToCamera(2);
        }
    }

    private void SwitchToCamera(int index)
    {
        if (index < cameras.Length)
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);
            cameras[index].gameObject.SetActive(true);
            currentCameraIndex = index;
        }
    }
}