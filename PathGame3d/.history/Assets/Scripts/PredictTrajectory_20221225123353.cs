using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform releasePos;
    [SerializeField][Range(10,100)] private int LinePoints = 25;
    [SerializeField][Range(0.01f,0.25f)] private float TimeBetweenPoints = 0.1f;
    
    public GameObject boxPrefab; //instead of box we should have the object prefab being thrown(the one first in the list of ammo) (look at enum, and rick's way of doing hooking up ammo)
    
    private bool drawLine = true; // will be default to false and then turned on/off according to if we are aiming (moving with ammo)
    private LayerMask boxCollisionMask; //rename this with throwableObjectCollisionMask

    private void Awake() 
    {
        int boxLayer = boxPrefab.gameObject.layer;//rename with throwableObjectLayer & replace boxprefab with the object we need to shoot
        for (int i = 0; i < 32; i++)
        {
            if (!Physics.GetIgnoreLayerCollision(boxLayer, i))
            {
                boxCollisionMask |= 1 << i;
            }
        }
    }

    private void Update() {
        DrawProjection();
    }

    private void DrawProjection()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt (LinePoints / TimeBetweenPoints) + 1;
        Vector3 startPosition = releasePos.position;
        Vector3 startVelocity = 10 * transform.forward / boxPrefab.GetComponent<Rigidbody>().mass;//hook up the variable instead of 10 (variable will probably differ according to weapon); 
        int i = 0;
        lineRenderer.SetPosition(i, startPosition);
        for(float time = 0; time < LinePoints; time += TimeBetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

            lineRenderer.SetPosition(i, point);
        }
    }
}
