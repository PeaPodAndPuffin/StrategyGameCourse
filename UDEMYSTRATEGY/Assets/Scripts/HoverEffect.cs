using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public float amount;

    private void OnMouseEnter()
    {
        transform.localScale += new Vector3(amount, amount, amount);
    }

    private void OnMouseExit()
    {
        transform.localScale -= new Vector3(amount, amount, amount);
    }
}
