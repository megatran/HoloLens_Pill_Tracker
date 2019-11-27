using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrackMarker : MonoBehaviour, IInputClickHandler
{
    public bool isTracking = true;
    public TextMesh buttonText;
    public GameObject ARUWPControllerObject;

    public GameObject Bin01;
    public GameObject Bin02;
    public GameObject Bin03;

    void Start()
    {
        buttonText.text = isTracking ? "Stop Tracking Marker" : "Start Tracking Marker";
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {

        if (isTracking)
        {
            PlayerPrefs.SetString("AR_exp_stop_aruwp_lib", "true");
#if !UNITY_EDITOR && UNITY_METRO
                        ARUWPControllerObject.GetComponent<ARUWPController>().Pause();

#endif
            ARUWPControllerObject.SetActive(false);
            isTracking = false;

            Bin01.GetComponent<ControlBinSceneRoot>().anchorBin();
            Bin02.GetComponent<ControlBinSceneRoot>().anchorBin();
            Bin03.GetComponent<ControlBinSceneRoot>().anchorBin();
            buttonText.text = "Start Tracking Marker";

        }
        else
        {
            PlayerPrefs.SetString("AR_exp_stop_aruwp_lib", "false");
            ARUWPControllerObject.SetActive(true);
#if !UNITY_EDITOR && UNITY_METRO
                        ARUWPControllerObject.GetComponent<ARUWPController>().Resume();

#endif
            isTracking = true;

            Bin01.GetComponent<ControlBinSceneRoot>().unanchorBin();
            Bin02.GetComponent<ControlBinSceneRoot>().unanchorBin();
            Bin03.GetComponent<ControlBinSceneRoot>().unanchorBin();
            buttonText.text = "Stop Tracking Marker";



        }



    }

}
