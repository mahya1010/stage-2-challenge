using UnityEngine;

public class ControlGravity : MonoBehaviour, IDrag
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
     public void onStratDrag()
    {
        rb.useGravity = false;
    }
    public void onEndDrag()
    {
        rb.useGravity = true;
        
    }

   
}
