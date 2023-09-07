using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    private float _scrollSpeed = 1f;
    private Vector2 _startPos;

    //private Vector2 _finPos;


    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;

       // _finPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * _scrollSpeed, 11);
        transform.position = _startPos + Vector2.left * newPos;
    }
}
