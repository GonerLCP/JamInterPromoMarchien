using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvTapis : MonoBehaviour
{
    public float Vitesse = 0.1f;
    Vector2 Mouvement;
    // Start is called before the first frame update
    void Start()
    {
        Mouvement = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = Mouvement*Vitesse;
    }
}
