using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 pointA = new Vector3(-0.5f, 0.1f, 0);
    public Vector3 pointB = new Vector3(0.5f, 0.1f, 0);
    public float speed = 1f;
    
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        transform.localPosition = Vector3.Lerp(pointA, pointB, t);
    }
}