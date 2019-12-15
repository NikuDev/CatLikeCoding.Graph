using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform PointPrefab;

    // a private collection to hold all generated prefabs
    private Transform[] _pointPrefabs;

    // make the inspector use a slider by defining '[Range(start,end)]'
    [Range (10,100)]
    public int AmountCubes;

    void Awake()
    {
        float step = 2f / AmountCubes;
        Vector3 scale = Vector3.one * step;
        Vector3 position;

        position.y = 0f;
        position.z = 0f;
        
        this._pointPrefabs = new Transform[this.AmountCubes];

        for(int i = 0; i < this._pointPrefabs.Length; i++)
        {
            Transform point = Instantiate(this.PointPrefab);
            position.x = (i + 0.5f) * step - 1f;

            point.localPosition = position;
            point.localScale = scale;

            // to make the instantiated prefab a child of the Graph (this),
            // we can use 'transform', which is inherently available in this object
            point.SetParent(this.transform, false);

            // add it to the collection for later manipulation
            this._pointPrefabs[i] = point;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // we'll use Update to manipulate the .y positions of all the points
        // to make the graph animate
        for(int i = 0; i < this._pointPrefabs.Length; i++)
        {
            Transform point = this._pointPrefabs[i];
            Vector3 position = point.localPosition;

            //// linear positioning where y = x
            //// x=-1, y=-1 - x=-0.8, y=-0.8, x=-0.6, y=-0.6 etc.
            //position.y = position.x;

            //// using x^2 to set the .y position
            //position.y = position.x * position.x;

            //// using x^3 to set the .y position
            //position.y = position.x * position.x * position.x;

            // using .Sin will ensure the Graph staying inside the -1 - 1
            // frame and not rise out of the screen, incorporating the Time.time
            // will give it a variable to change over time and animate
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));

            // remember to explicitly set the position to the point taken
            // from the array*
            point.localPosition = position;

            // Couldn't we directly assign to point.localPosition.y?
            // If localPosition were a field, then this would be possible.
            // We could directly set the Y coordinate of the point's position. 
            // However, localPosition is a property. It passes a vector to us, 
            // or accepts one from us. So we'd end up adjusting a local vector 
            // value, which doesn't affect the point's position at all.
            // As we haven't explicitly stored it in a variable first, the 
            // operation is meaningless and will produce a compiler error.


        }
        
    }
}
