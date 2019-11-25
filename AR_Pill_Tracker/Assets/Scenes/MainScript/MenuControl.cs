using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    private List<string> indexOptions = new List<string>() { "0", "1" };
    public Dropdown ItemDropdown;

    public string currentItemName;

    // Start is called before the first frame update
    void Start()
    {
        ItemDropdown.AddOptions(indexOptions);
    }

    public void Dropdown_IndexChanged(int index)
    {
        Debug.Log(string.Format("SELECTED OPTION: {0}", index));

        if (index == 0)
        {
            currentItemName = "Cube2";
        } else if (index == 1)
        {
            currentItemName = "Sphere2";
        }

        PlayerPrefs.SetString("currentItemToFind", currentItemName);

    }
}
