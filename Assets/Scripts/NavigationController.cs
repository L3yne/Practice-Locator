using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class NavigationController : MonoBehaviour
{
    public Button navigationButton;
    public InputField latitudeInputField;
    public InputField longitudeInputField;
    public int zoomLevel;
    public GPSController gpsController;

    void Start()
    {
        navigationButton.onClick.AddListener(OpenNavigation);
    }

    void OpenNavigation()
    {
        double latitude;
        double longitude;

        if (double.TryParse(latitudeInputField.text, NumberStyles.Float, CultureInfo.InvariantCulture, out latitude) 
            && double.TryParse(longitudeInputField.text, NumberStyles.Float, CultureInfo.InvariantCulture, out longitude))
        {
            string url = "https://www.google.com/maps/place/"   + latitude.ToString().Replace(",", ".") + "," 
                                                                + longitude.ToString().Replace(",", ".") + "/@" 
                                                                + latitude.ToString().Replace(",", ".") + "," 
                                                                + longitude.ToString().Replace(",", ".") + "," 
                                                                + zoomLevel + "z";
            Application.OpenURL(url);
        }
    }
}