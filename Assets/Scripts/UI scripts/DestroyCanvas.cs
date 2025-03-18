using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCanvas : MonoBehaviour
{
    [SerializeField] float DestroyTime;
    // Start is called before the first frame update
    void Start() => Destroy(this.gameObject, DestroyTime);

}
