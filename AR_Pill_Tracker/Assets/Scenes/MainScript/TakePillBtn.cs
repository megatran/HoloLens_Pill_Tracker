using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePillBtn : MonoBehaviour, IInputClickHandler
{
    public bool taken = false;
    Color buttonColor;
    public TextMesh buttonText;
    public GameObject buttonVisual;
    public GameObject MenuControl;

    // Start is called before the first frame update
    void Start()
    {
        buttonColor = buttonVisual.GetComponent<Renderer>().material.color;
        if (taken)
        {
            buttonVisual.GetComponent<Renderer>().material.color = Color.grey;
            buttonText.text = "Taken";
;        } else
        {
            buttonVisual.GetComponent<Renderer>().material.color = buttonColor;
            buttonText.text = "Take";
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        taken = !taken;

        if (taken)
        {
            buttonVisual.GetComponent<Renderer>().material.color = Color.grey;
            buttonText.text = "Taken";
            MenuControl.GetComponent<MenuControl>().updateStat(1);
        }
        else
        {
            buttonVisual.GetComponent<Renderer>().material.color = buttonColor;
            buttonText.text = "Take";
            MenuControl.GetComponent<MenuControl>().updateStat(-1);

        }
    }

}
