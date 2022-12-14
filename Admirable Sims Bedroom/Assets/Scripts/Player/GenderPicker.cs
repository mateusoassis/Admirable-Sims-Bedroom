using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderPicker : MonoBehaviour
{
    public Animator animator;

    public RuntimeAnimatorController[] genderOptions;

    public bool offsetYFix;
    public float offsetYAmount;

    void Start()
    {
        /*
        if(offsetYFix)
        {
            OffsetEnable();
        }
        else
        {
            OffsetDisable();
        }
        */
    }

    public void OffsetEnable()
    {
        if(offsetYFix)
        {
            transform.position = transform.parent.position + new Vector3(0f, offsetYAmount, 0f);
        }
    }
    public void OffsetDisable()
    {
        transform.position = transform.parent.position;
    }
}
