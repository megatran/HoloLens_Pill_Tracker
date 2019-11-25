using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour, IInputClickHandler
{
    public NavMeshAgent Agent;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
        Agent.gameObject.SetActive(false);
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
       // if (GazeManager.Instance.IsGazingAtObject)
       if (FocusManager.Instance.TryGetFocusDetails(eventData) != null)
        {
            Debug.Log("CLICKED");

            var hitInfo = GazeManager.Instance.HitInfo;
            if (!Agent.gameObject.activeSelf)
            {
                Agent.gameObject.SetActive(true);
                Agent.transform.position = hitInfo.point;
            } else
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
