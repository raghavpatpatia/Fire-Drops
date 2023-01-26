using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public Text CounterTextHighlight;
    public int Count = 0;
    BoxCollider boxCollider;
    public GameObject Fire;
    private void Start()
    {
        Count = 0;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        CounterTextHighlight.text = "Count : " + Count;
        if (Count != 0)
        {
            if (Count % 10 == 0)
            {
                boxCollider.size += new Vector3(0.5f, 0.5f, 0.5f);
                Fire.gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
        Destroy(other.gameObject);
    }
}
