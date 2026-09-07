using UnityEngine;
using UnityEngine.EventSystems;

public class Cypher : Agent
{
    public void Start()
    {
        _Start();
    }
    public void Update()
    {
        Move();
        LookAround();
    }

    [ContextMenu("Test")]
    public void Test()
    {
        velocity += Vector3.up * 10f;
    }
}
