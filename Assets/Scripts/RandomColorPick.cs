using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorPick : MonoBehaviour
{
    [SerializeField] private Material[] materials;   

    // Start is called before the first frame update


    public Material ChooseColor(MeshRenderer ballonRenderer)
    {
        return ballonRenderer.material = materials[Mathf.RoundToInt(Random.Range(0f,materials.Length))];
    }
}
