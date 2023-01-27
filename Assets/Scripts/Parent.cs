using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    string nomDuTruc;
    float timer = 0f;
    float delai = 3f;
    int i = 0;
    public GameObject Objet1;
    GameObject Temp;
    Vector2 vecteur;
    Quaternion Rota;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tapis")
        {
            nomDuTruc = collision.name;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delai)
        {
            vecteur = new Vector2(Random.Range(-11, -13), Random.Range(0.8f, -0.8f));
            Temp = Instantiate(Objet1, vecteur, Rota);
            Temp.transform.parent = GameObject.Find(nomDuTruc).GetComponent<Transform>();
            timer = 0f;
            i++;
            //print(i);
            if (i == 5 && delai != 1)
            {
                delai = delai - 1;
                i = 0;
            }
        }
    }
}