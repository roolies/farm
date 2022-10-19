using UnityEngine;
using System.Collections;
 
public class Indicator : MonoBehaviour
{
    public Vector3 pointB;
   
    IEnumerator Start()
    {
        transform.position = new Vector3(-8.0f, 1.5f, 0f);

        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 1.0f));
        }
    }
   
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f/time;
        while (i < 1.0f)
        {

            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

    private void OnEnable()
    {

    }
}
