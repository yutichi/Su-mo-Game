using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltTexture : MonoBehaviour
{
    [SerializeField]
    private float _conveyorSpeed = 0.1f;

    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * _conveyorSpeed;
        mesh.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
