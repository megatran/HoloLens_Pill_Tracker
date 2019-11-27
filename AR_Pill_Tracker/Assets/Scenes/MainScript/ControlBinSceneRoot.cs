using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlBinSceneRoot : MonoBehaviour
{
    private bool ARUWP_Lib_Stop_Tracking = false;
    WorldAnchorManager worldAnchorManagerRef;
    public string binAnchorName;
    public TextMesh InfoText;

    // Start is called before the first frame update
    void Start()
    {
        binAnchorName = string.Format("anchor_{0}", gameObject.name);

        worldAnchorManagerRef = WorldAnchorManager.Instance;
        if (PlayerPrefs.GetString("AR_exp_stop_aruwp_lib", "false").Equals("true"))
        {
            if (worldAnchorManagerRef != null)
            {
                worldAnchorManagerRef.AttachAnchor(gameObject, binAnchorName);

            } else
            {
                Destroy(this);
            }
        }
    }


    public void anchorBin()
    {

            if (PlayerPrefs.GetString("AR_exp_stop_aruwp_lib", "false").Equals("true"))
            {
                // WorldAnchorManager.Instance.RemoveAnchor(gameObject);
                WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
                WorldAnchorManager.Instance.AttachAnchor(gameObject, binAnchorName);

            }
        
    }

    public void unanchorBin()
    {
        // WorldAnchorManager.Instance.RemoveAnchor(gameObject);
        WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
    }

    private void FixedUpdate()
    {
        RaycastHit hitInfo;
        Transform cameraTransform = Camera.main.transform;
        Vector3 headPosition = cameraTransform.position;
        Vector3 gazeDirection = cameraTransform.forward;

        //  to prevent problems when the Ray start from inside the searched object (which can happen if for example the Player rests on your platform, penetrating it by a tiny amount).
        float rayOffset = 0.5f;

        Ray rayPosition = new Ray(gameObject.transform.position + (Vector3.up * rayOffset), Vector3.down); // FIX: added an offset

        InfoText.text = Physics.Raycast(rayPosition, out hitInfo, 30.0f + rayOffset, SpatialMappingManager.Instance.LayerMask) ? string.Format("{0} | True: {1}", gameObject.transform.name, hitInfo.point) : string.Format("{0} | False: {1}", gameObject.transform.name, hitInfo.point);
        //this.transform.position = hitInfo.point;
    }


}
