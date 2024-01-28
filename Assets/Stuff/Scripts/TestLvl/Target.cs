using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager manager;

    public Color highlightCol;
    public Color selectCol;

    void Start()
    {
        if (manager == null)
        {
            manager = GameObject.FindAnyObjectByType<GameManager>();
        }
    }

    void Update()
    {
        
    }
}
