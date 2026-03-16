using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneProjectile : MonoBehaviour
{   
    [SerializeField] private float _lifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

}
