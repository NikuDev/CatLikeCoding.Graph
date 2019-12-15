using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform PointPrefab;

    // make the inspector use a slider by defining '[Range(start,end)]'
    [Range (10,100)]
    public int AmountCubes;

    void Awake()
    {
        float step = 2f / AmountCubes;
        Vector3 scale = Vector3.one * step;
        Vector3 position;

        position.z = 0f;

        for(int i = 0; i < this.AmountCubes; i++)
        {
            Transform point = Instantiate(this.PointPrefab);
            position.x = (i + 0.5f) * step - 1f;

            //// linear positioning where y = x
            //// x=-1, y=-1 - x=-0.8, y=-0.8, x=-0.6, y=-0.6 etc.
            //position.y = position.x;
            
            // using x^2 to set the .y position
            position.y = position.x * position.x;

            point.localPosition = position;
            point.localScale = scale;

            // to make the instantiated prefab a child of the Graph (this),
            // we can use 'transform', which is inherently available in this object
            point.SetParent(this.transform, false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
