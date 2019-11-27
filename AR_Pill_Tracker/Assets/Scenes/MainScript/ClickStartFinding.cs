using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;
using UnityEngine.AI;

public class ClickStartFinding : MonoBehaviour, IInputClickHandler
{
    public NavMeshAgent Agent;
    public GameObject AgentObject;
    LineRenderer lineRenderer;
    public float RayDistance = 100f;

    void Start()
    {
        Agent.gameObject.SetActive(false);
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Start navigation");
        string itemToFind = PlayerPrefs.GetString("currentItemToFind", "Cube2");

        GameObject objectToFind = GameObject.Find(itemToFind);

        RaycastHit hitInfo;
        Transform cameraTransform = Camera.main.transform;
        Vector3 headPosition = cameraTransform.position;
        Vector3 gazeDirection = cameraTransform.up;

        //  to prevent problems when the Ray start from inside the searched object (which can happen if for example the Player rests on your platform, penetrating it by a tiny amount).
        float rayOffset = 0.5f;

        Ray rayPosition = new Ray(objectToFind.transform.position + (Vector3.up * rayOffset), Vector3.down); // FIX: added an offset

        if (Physics.Raycast(rayPosition, out hitInfo, 30.0f+rayOffset, SpatialMappingManager.Instance.LayerMask))
        {
            Debug.Log("HIT");
            AgentObject.GetComponent<AudioSource>().Play();
            /* Modify the target location so that the object is being perfectly aligned with the ground (if it's flat).*/
            // targetLocation += new Vector3(0, objectToFind.transform.localScale.y / 2, 0);
            if (!Agent.gameObject.activeSelf)
            {
                Agent.gameObject.SetActive(true);
                Agent.transform.position = hitInfo.point;
            }
            else
            {
                Agent.destination = hitInfo.point;

                // path calculation
                var path = new NavMeshPath();
                NavMesh.CalculatePath(Agent.transform.position, Agent.destination, NavMesh.AllAreas, path);
                var positions = path.corners;

                // Draw route
                lineRenderer.widthMultiplier = 0.1F;
                lineRenderer.positionCount = positions.Length;
                for (int i = 0; i < positions.Length; i++)
                {
                    Debug.Log(" point " + i + " = " + positions[i]);
                    lineRenderer.SetPosition(i, positions[i]);
                }
            }
        }
    }

}
