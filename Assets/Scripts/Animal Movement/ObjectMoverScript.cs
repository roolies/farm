using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverScript : MonoBehaviour
{
    public float Range;
    public float Speed;
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * Speed) * Range + initPos.y, 0);
    }
}
