using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
        int x = 0, y = 0;
        if (Input.GetKey(KeyCode.UpArrow)) y = 1;
        if (Input.GetKey(KeyCode.DownArrow)) y = -1;
        if (Input.GetKey(KeyCode.RightArrow)) x = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) x = -1;
        pos.x = Mathf.Clamp01(pos.x + (x * speed));
        pos.y = Mathf.Clamp01(pos.y + (y * speed));
        var convertPos = Camera.main.ViewportToWorldPoint(pos);
        convertPos.z = 0;

        transform.position = convertPos;
    }
}
