using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonMovement : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField]
    float ballonSpeed=0.1f;
    Vector3 currentScale;
    Vector3 nextScale;
    [SerializeField] float ballonGrowthSpeed;
    [SerializeField] float targetScaleMultiplier;
    private MeshRenderer thisBallonRenderer;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScale = transform.localScale;
        //RandomColorPick();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = Vector3.Lerp(transform.localScale, currentScale*50f, Time.deltaTime);
        transform.Translate(Vector3.up * Time.deltaTime * ballonSpeed, Space.Self);
    }
}
