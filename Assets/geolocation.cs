using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using System;

public class geolocation : MonoBehaviour
{
    public double lat;
    public double lon;
    private DateTime timer;
    //CODE FROM UNITY DOCS: https://docs.unity3d.com/ScriptReference/LocationService.Start.html
    //and some from here: https://stackoverflow.com/questions/71738164/how-to-get-user-location-using-unity
    void Start(){
        lat = 37.73;
        lon = -122.437;
        timer = DateTime.Now;
    }

    void Update(){
        //commented out for laptop testing
        Debug.Log("update doin nothing");
        
        timer = DateTime.Now;
        string time = timer.ToString();
        int strlen = time.Length;
        //my jank way of not getting user location all the time
        if(time[strlen - 4] == '0'){
            Debug.Log("updated time");
            //GetUserLocation();
        }
        
    }

    public void GetUserLocation()
    {
        if (!Input.location.isEnabledByUser) //FIRST IM CHACKING FOR PERMISSION IF "true" IT MEANS USER GAVED PERMISSION FOR USING LOCATION INFORMATION
        {
            Debug.Log("no input location :(");
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            Debug.Log("got input location");
            
        }
        //would normally put this inside the else but here now for testing on laptop
        StartCoroutine(getLocation());
    }

    IEnumerator getLocation()
    {
            // Uncomment if you want to test with Unity Remote
        /*#if UNITY_EDITOR
                yield return new WaitWhile(() => !UnityEditor.EditorApplication.isRemoteConnected);
                yield return new WaitForSecondsRealtime(5f);
        #endif*/
        #if UNITY_EDITOR
                // No permission handling needed in Editor
        #elif UNITY_ANDROID
                if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation)) {
                    Permission.RequestUserPermission(Permission.CoarseLocation);
                }

                // First, check if user has location service enabled
                if (!Input.location.isEnabledByUser) {
                    // TODO Failure
                    Debug.LogFormat("Android and Location not enabled");
                    yield break;
                }

        #elif UNITY_IOS
                if (!Input.location.isEnabledByUser) {
                    // TODO Failure
                    Debug.LogFormat("IOS and Location not enabled");
                    yield break;
                }
        #endif
                // Start service before querying location
                Input.location.Start(500f, 500f);
                        
                // Wait until service initializes
                int maxWait = 15;
                while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
                    yield return new WaitForSecondsRealtime(1);
                    maxWait--;
                }

                // Editor has a bug which doesn't set the service status to Initializing. So extra wait in Editor.
        #if UNITY_EDITOR
                int editorMaxWait = 15;
                while (Input.location.status == LocationServiceStatus.Stopped && editorMaxWait > 0) {
                    yield return new WaitForSecondsRealtime(1);
                    editorMaxWait--;
                }
        #endif

                // Service didn't initialize in 15 seconds
                if (maxWait < 1) {
                    // TODO Failure
                    Debug.LogFormat("Timed out");
                    yield break;
                }


                // If the connection failed this cancels location service use.
                if (Input.location.status == LocationServiceStatus.Failed)
                {
                    Debug.LogError("Unable to determine device location");
                    yield break;
                }
                else
                {   
                    lon = Input.location.lastData.longitude;
                    lat = Input.location.lastData.latitude;
                    // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
                    Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
                }

                // Stops the location service if there is no need to query location updates continuously.
                Input.location.Stop();
    }
        
}

