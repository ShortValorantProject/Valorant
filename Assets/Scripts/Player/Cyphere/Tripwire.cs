using UnityEngine;

public class Tripwire : MonoBehaviour
{
    public LayerMask tripwireLayerMask;
    public Transform firstContactPoint;
    public Transform secondContactPoint;

    public LineRenderer lineRenderer;

    public void Update()
    {
        var distanceBetweenTrips = Vector3.Distance(secondContactPoint.position, firstContactPoint.position);
        var direction = (secondContactPoint.position - firstContactPoint.position).normalized;

        Physics.Raycast(firstContactPoint.position, direction, out RaycastHit info, distanceBetweenTrips, tripwireLayerMask);
        Debug.DrawRay(firstContactPoint.position, direction * distanceBetweenTrips, Color.red, .1f);


        if(info.collider)
            Destroy(info.collider.gameObject);
    }

    public void SetupTripwire(Vector3 firstPos, Vector3 secondPos)
    {
        firstContactPoint.position = firstPos;
        secondContactPoint.position = secondPos;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, firstContactPoint.position);
        lineRenderer.SetPosition(1, secondContactPoint.position);
    }
}
