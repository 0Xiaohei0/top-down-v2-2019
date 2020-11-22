using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortRenderOrder : MonoBehaviour
{
  [ SerializeField] float sortingOrderBase=1000f;
    [SerializeField] int offSet = 0;
    [SerializeField] bool runOnlyOnce = false;
    private Renderer myRenderer;
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }
    
    void LateUpdate()
    {
        myRenderer.sortingOrder = (int)((sortingOrderBase - transform.position.y)*10 - offSet);
       // Debug.Log((int)((sortingOrderBase - transform.position.y) * 10 - offSet));
        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
