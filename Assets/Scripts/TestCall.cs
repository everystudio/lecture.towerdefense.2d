using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCall : MonoBehaviour
{
    [SerializeField] private LineMover lineMover;
    void Start()
    {
        lineMover.OnEndReached += (sender, e) => Debug.Log("Test Call Reached end");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
