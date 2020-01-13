using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();

    private void Start()
    {
        AddChildren();
    }
    private void Initialize()
    {
        AddChildren();
    }
    void AddChildren()
    {
        for (int i  = 0; i < transform.childCount; i++)
        {
            points.Add(transform.GetChild(i));
        }
    }
}
