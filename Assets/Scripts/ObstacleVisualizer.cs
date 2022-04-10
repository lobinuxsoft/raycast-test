using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ObstacleVisualizer : MonoBehaviour
{
    private const float speedColorTransition = 2f;
    private MeshRenderer meshRenderer;
    private bool visible = true;
    
    public void SetVisibility(bool value)
    {
        visible = value;
    }
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void LateUpdate()
    {
        float alpha = Mathf.Clamp(visible
            ? meshRenderer.material.color.a + Time.deltaTime * speedColorTransition
            : meshRenderer.material.color.a - Time.deltaTime * speedColorTransition, .25f, 1f);
        
        meshRenderer.material.color = new Color(1, 1, 1, alpha);
    }
}
