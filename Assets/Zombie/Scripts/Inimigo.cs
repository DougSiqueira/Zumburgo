using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))] //segue
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Inimigo : MonoBehaviour
{

    private GameObject uChan;
    private NavMeshAgent naveMesh;
    private uChanController uChanControl;

    private bool podeAtacar;


    void Start()
    {
        podeAtacar = true;
        uChan = GameObject.FindWithTag("Player"); //achar o player
        uChanControl = uChan.GetComponent<uChanController>();
        naveMesh = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, uChan.transform.position) >= 1.5f && Vector3.Distance(transform.position, uChan.transform.position) <= 10.0f)
        {
            naveMesh.destination = uChan.transform.position;
        }

        if (Vector3.Distance(transform.position, uChan.transform.position) < 1.5f)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        if (podeAtacar == true)
        {
            StartCoroutine("TempoDeAtaque");
            uChanControl.Life -= 1; //vida provisoria
        }
    }
    IEnumerator TempoDeAtaque()
    {  // tempo entre ataques ao jogador
        podeAtacar = false;
        yield return new WaitForSeconds(1);
        podeAtacar = true;

    }


}
