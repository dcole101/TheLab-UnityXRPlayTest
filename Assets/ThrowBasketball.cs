using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class BasketballThrow : MonoBehaviour
{
    private Rigidbody rb;
    private List<Vector3> directionHistory = new List<Vector3>();
    public int historyLength = 5; // Number of frames to average over for direction smoothing
    public float maxThrowForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        if (args.interactorObject == null)
            return;

        // Calculate throw direction by averaging recent direction history
        Vector3 throwDirection = CalculateSmoothedDirection();

        // Apply force
        rb.AddForce(throwDirection * maxThrowForce, ForceMode.Impulse);
    }

    Vector3 CalculateSmoothedDirection()
    {
        Vector3 averageDirection = Vector3.zero;

        // Calculate average direction from recent direction history
        int count = Mathf.Min(directionHistory.Count, historyLength);
        for (int i = 0; i < count; i++)
        {
            averageDirection += directionHistory[i];
        }
        if (count > 0)
        {
            averageDirection /= count;
        }

        return averageDirection.normalized;
    }

    void FixedUpdate()
    {
        // Add current direction to history
        if (rb.velocity.magnitude > 0)
        {
            directionHistory.Insert(0, rb.velocity.normalized);
            if (directionHistory.Count > historyLength)
            {
                directionHistory.RemoveAt(directionHistory.Count - 1);
            }
        }
    }
}
