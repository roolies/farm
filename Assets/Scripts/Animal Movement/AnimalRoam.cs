using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRoam : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;

    public Transform bottomLeft;

    public Transform topRight;

    Vector2 wayPoint;

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(bottomLeft.position.x, topRight.position.x), Random.Range(bottomLeft.position.y, topRight.position.y));
    }
}
