using UnityEngine;

public class SimpleDrag3D : MonoBehaviour
{
    private Camera cam;
    private bool isDragging = false;
    private Vector3 offset;
    private float objectZ;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;

        objectZ = cam.WorldToScreenPoint(transform.position).z;
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = objectZ;

        offset = transform.position - cam.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = objectZ;

            Vector3 newPosition = cam.ScreenToWorldPoint(mousePoint) + offset;
            transform.position = newPosition;
        }
    }
}
