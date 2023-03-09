using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class speedLimitUI : MonoBehaviour
{

    TextMeshProUGUI textMesh;
    public GameObject player;
    public shipController shipController;

    // Start is called before the first frame update
    void Start()
    {

        shipController = player.GetComponent<shipController>();
        textMesh = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

        textMesh.SetText("Speed <br>Limit = " + shipController.maxSpeed);

    }

}
