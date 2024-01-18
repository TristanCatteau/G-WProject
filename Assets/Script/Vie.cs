using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vie : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text NbLife;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NbLife.text = Move_Joueur.instance.CurrentHealth.ToString ("0");

    }
}
