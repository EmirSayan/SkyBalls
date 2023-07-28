using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaniyelikSkor : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public TextMeshProUGUI scoreTxet;
    public TextMeshProUGUI lastScore;
    public TextMeshProUGUI lastScore2;
    public float scoreMiktari;



    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

