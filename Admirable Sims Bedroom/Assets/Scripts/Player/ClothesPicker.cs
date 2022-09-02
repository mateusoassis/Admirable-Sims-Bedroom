using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ClothesPicker : MonoBehaviour
{
    public Animator animator;

    public RuntimeAnimatorController[] clothesOptions;

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
