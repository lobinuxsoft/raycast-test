using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] LayerMask raycastMask;
    [SerializeField] Transform target;

    RaycastHit hit;

    MeshRenderer lastHit;

    // Update is called once per frame
    void Update()
    {
        Physics.Linecast(transform.position, target.position, out hit, raycastMask);

        if(hit.transform != null && hit.transform.TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
        {
            if(lastHit != null)
            {
                lastHit.enabled = lastHit != mesh;

                if (lastHit != mesh) lastHit = mesh;
            }
            else
            {
                lastHit = mesh;
            }
        }
        else
        {
            if (lastHit != null) lastHit.enabled = true;
        }
    }
}
