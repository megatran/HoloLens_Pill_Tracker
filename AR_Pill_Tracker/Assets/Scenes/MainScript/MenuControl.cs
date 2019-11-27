using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    private List<string> indexOptions = new List<string>() {"Memory Pill", "Vitamin B", "Vitamin C", "Test 1", "Test 2" };
    public Dropdown ItemDropdown;
    public TextMesh StatText;
    public int numPillTaken = 0;

    public string currentItemName;

    // Start is called before the first frame update
    void Start()
    {
        ItemDropdown.AddOptions(indexOptions);
    }

    public void updateStat(int pill)
    {
        numPillTaken += pill;
        StatText.text = string.Format("{0}/3 Pill Taken Today", numPillTaken);

        if (numPillTaken > 3)
        {
            StatText.GetComponent<Renderer>().material.color = Color.red;
        } else
        {
            StatText.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void Dropdown_IndexChanged(int index)
    {
        Debug.Log(string.Format("SELECTED OPTION: {0}", index));


        if (index == 0)
        {
            currentItemName = "anchor_Bin01Root";
        }
        else if (index == 1)
        {
            currentItemName = "anchor_Bin02Root";
        }
        else if (index == 2)
        {
            currentItemName = "anchor_Bin03Root";
        }
        else if (index == 3)
        {
            currentItemName = "Cube2";

        }
        else if (index == 4)
        {
            currentItemName = "Sphere2";
        }

        PlayerPrefs.SetString("currentItemToFind", currentItemName);

    }
}
