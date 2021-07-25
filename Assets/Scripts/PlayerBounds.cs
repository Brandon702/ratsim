using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour 
{
    public float minX = 0f, maxX = 0f, minY = 0f;

    void Update() 
    {
        CheckBounds();
    }

    void CheckBounds() 
    {
        Vector2 temp = transform.position;

        if (temp.x > maxX)
            temp.x = maxX;

        if (temp.x < minX)
            temp.x = minX;

        transform.position = temp;
    }
}