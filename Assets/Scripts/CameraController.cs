using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public WebCamTexture webCamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            webCamTexture = new WebCamTexture(devices[0].name, Screen.height, Screen.width);
            webCamTexture.requestedFPS = 30; 
            GetComponent<Renderer>().material.mainTexture = webCamTexture;
            webCamTexture.Play();
        }
    }

    void OnDisable()
    {
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90); 
    }
}