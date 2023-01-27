using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisRoulant : MonoBehaviour
{
    public GameObject Tapis;
    public Transform SpawnTapis;
    int i = 0;
    public SpawnTapis Spone;
    Vector2 vecteur;
    Quaternion Rota;
    GameObject tapis;

    // Start is called before the first frame update
    void Start()
    {
        vecteur = new Vector2(-20.2f, 0);
        tapis = Instantiate(Tapis, new Vector2(-1f,0f), Rota);
        tapis.name = "Patient0";
        Instantiate(Tapis, vecteur, Rota);
    }

    // Update is called once per frame
    void Update()
    {
        if (Spone.AtteintLaFin == true)
        {
            vecteur = new Vector2(-20.2f, 0);
            tapis = Instantiate(Tapis, vecteur, Rota);
            tapis.name = "Clone" + i;
            i++;
            Spone.AtteintLaFin = false;
        }
    }
}