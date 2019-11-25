using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;

public class CubeTestMove : MonoBehaviour
{
    public float distoGround = 3;
    public TextMesh InfoText;

    void Start()
    {
        // Adding anchor initially
        WorldAnchorManager.Instance.AttachAnchor(gameObject, gameObject.name);

        gameObject.GetComponent<HandDraggable>().StartedDragging += () =>
        {
            // Removing anchor temporary when dragging started
            WorldAnchorManager.Instance.RemoveAnchor(gameObject);
        };
        gameObject.GetComponent<HandDraggable>().StoppedDragging += () =>
        {
            // Adding back with the same name when dragging ended
            WorldAnchorManager.Instance.AttachAnchor(gameObject, gameObject.name);
        };
    }

    private void FixedUpdate()
    {
        RaycastHit hitInfo;
        Transform cameraTransform = Camera.main.transform;
        Vector3 headPosition = cameraTransform.position;
        Vector3 gazeDirection = cameraTransform.forward;

        InfoText.text = Physics.Raycast(this.transform.position, Vector3.down ,out hitInfo, 30.0f, SpatialMappingManager.Instance.LayerMask) ? string.Format("True: {0}", hitInfo.point) : string.Format("False: {0}", hitInfo.point);
        //this.transform.position = hitInfo.point;
    }

}
