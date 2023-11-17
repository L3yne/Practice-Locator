using UnityEngine;
using UnityEngine.UI;

public class GPSController : MonoBehaviour
{
    public Text coordText;

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
            coordText.text = "Latitude: " + latitude + "\nLongitude: " + longitude;
            Debug.Log("Location: " + latitude + ", " + longitude);
        }
        else
        {
            coordText.text = "Connecting to services, stay tuned";
            Debug.Log("Location service status: " + Input.location.status.ToString());
        }
    }

    private void OnDestroy()
    {
        Input.location.Stop();
    }

public float GetLatitude()
{
    if (Input.location.status == LocationServiceStatus.Running)
    {
        return Input.location.lastData.latitude;
    }
    else
    {
        return 0f;
    }
}

    public float GetLongitude()
{
    if (Input.location.status == LocationServiceStatus.Running)
    {
        return Input.location.lastData.longitude;
    }
    else
    {
        return 0f;
    }
}
}