using System;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    public float scrollSpeed = 0.5f;
    Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
    }
    void Update() {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        rend.material.SetTextureOffset("_MainTex", new Vector2(x, 0));
    }

}
