using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] LayerMask raycastMask;
    [SerializeField] Transform target;

    [SerializeField] ObstacleVisualizer[] oldHits;

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, .25f, transform.forward,
            Vector3.Distance(transform.position, target.position) * .9f, raycastMask);
        
        //hits = Physics.RaycastAll(transform.position, transform.forward, Vector3.Distance(transform.position, target.position), raycastMask);

        if (hits.Length > 0)
        {
            ResetOldHits();
            
            oldHits = new ObstacleVisualizer[hits.Length];
            
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                oldHits[i] = hit.transform.GetComponent<ObstacleVisualizer>();

                if (oldHits[i]) oldHits[i].SetVisibility(false);
            }
        }
        else
        {
            ResetOldHits();
        }
    }

    private void ResetOldHits()
    {
        if (oldHits != null && oldHits.Length > 0)
        {
            foreach (var obsVi in oldHits)
            {
                obsVi.SetVisibility(true);
            }

            oldHits = null;
        }
    }
}
