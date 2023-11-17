using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class ArrowController : MonoBehaviour
{
    public InputField latitudeInput;
    public InputField longitudeInput;
    public Transform arrowTransform;
    public float scaleFactor = 100000f; // This scales the GPS coordinates to Unity's scale

    private void Start()
    {
        Input.location.Start();
        InvokeRepeating("UpdateLocation", 0f, 1f);
    }

    private void UpdateLocation()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;

            // Transform device GPS coordinates to Unity XYZ coordinates
            Vector3 devicePosition = new Vector3(longitude * scaleFactor, 0f, latitude * scaleFactor);
            arrowTransform.LookAt(devicePosition);
        }
    }

    public void UpdateDestination()
    {
        float latitude = float.Parse(latitudeInput.text);
        float longitude = float.Parse(longitudeInput.text);

        // Transform user-typed coordinates to Unity XYZ coordinates
        Vector3 destinationPosition = new Vector3(longitude * scaleFactor, 0f, latitude * scaleFactor);
        arrowTransform.LookAt(destinationPosition);

        Debug.Log("Destination: " + latitude + ", " + longitude);
    }

    private void OnDestroy()
    {
        Input.location.Stop();
    }
}
