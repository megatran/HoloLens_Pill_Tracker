using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePillBtn : MonoBehaviour, IInputClickHandler
{
    public bool saved = false;
    Color buttonColor;
    public TextMesh buttonText;
    public GameObject buttonVisual;

    public GameObject bottleBinObject;

    // Start is called before the first frame update
    void Start()
    {
        buttonColor = buttonVisual.GetComponent<Renderer>().material.color;
        if (saved)
        {
            buttonVisual.GetComponent<Renderer>().material.color = Color.grey;
            buttonText.text = "Saved \nSet New?";
            bottleBinObject.GetComponent<ControlBinSceneRoot>().anchorBin();
            
        }
        else
        {
            buttonVisual.GetComponent<Renderer>().material.color = buttonColor;
            buttonText.text = "Save \nLocation";
           bottleBinObject.GetComponent<ControlBinSceneRoot>().unanchorBin();

        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        saved= !saved;

        if (saved)
        {
            buttonVisual.GetComponent<Renderer>().material.color = Color.grey;
            buttonText.text = "Saved \nSet New?";
            bottleBinObject.GetComponent<ControlBinSceneRoot>().anchorBin();
        }
        else
        {
            buttonVisual.GetComponent<Renderer>().material.color = buttonColor;
            buttonText.text = "Save \nLocation";
            bottleBinObject.GetComponent<ControlBinSceneRoot>().unanchorBin();

        }
    }
}
