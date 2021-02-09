using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeGenerate : MonoBehaviour
{
    [SerializeField]
    GameObject corda;

    int numCorda = 0;

    GameObject[] cordas;

    [SerializeField]
    Vector3 distancia;
    

    void Start()
    {
        cordas = new GameObject[1];

        cordas[0] = corda.gameObject;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GerarCorda();
        }
    }

    void GerarCorda()
    {
        Debug.ClearDeveloperConsole();

        var cordaAtual = Instantiate(corda, new Vector3(transform.position.x + distancia.x, transform.position.y + distancia.y, 0f), Quaternion.identity);

        cordaAtual.transform.SetParent(transform);

        System.Array.Resize(ref cordas, cordas.Length + 1);

        cordas[cordas.Length - 1] = cordaAtual.gameObject;

        var joint = cordas[numCorda].gameObject.AddComponent<HingeJoint2D>();

        ArrumarJoint(joint);

        joint.connectedBody = cordaAtual.GetComponent<Rigidbody2D>();

        numCorda += 1;

        cordaAtual.name = "corda" + numCorda;

        for (int i = 0; i < cordas.Length; i++)
        {
            Debug.Log("["+ i + "] nome: " + cordas[i].gameObject.name);
        }

    }

    void ArrumarJoint(HingeJoint2D joint2D)
    {
        joint2D.autoConfigureConnectedAnchor = false;

        joint2D.connectedAnchor = new Vector2(1f, 0f);
    }
}
