using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        var movement = new Vector3(inputX, inputY);

        movement *= speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
