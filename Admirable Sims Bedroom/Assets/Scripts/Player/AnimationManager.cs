using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Animations;

public class AnimationManager : MonoBehaviour
{
    public int gender; // 0 female, 1 male
    public int hair; // 0 to 5
    public int clothes; // 0 to 5

    public HairPicker[] hairPickers;
    public GenderPicker[] genderPickers;
    public ClothesPicker[] clothesPickers;

    void Start()
    {
        ChangePlayer();
    }

    public void ChangePlayer()
    {
        for(int i = 0; i < hairPickers.Length; i++)
        {
            UnityEngine.Debug.Log("trocou " + i + " cabelo");
            //hairPickers.gameObject.GetComponent<Animator>() = null;
            //hairPickers[i].Lul();
            hairPickers[i].GetComponent<Animator>().runtimeAnimatorController = hairPickers[i].hairOptions[hair] as RuntimeAnimatorController;
            if(hair > 2)
            {
                hairPickers[i].OffsetEnable();
            }
            else
            {
                hairPickers[i].OffsetDisable();
            }
        }
        for(int i = 0; i < genderPickers.Length; i++)
        {
            UnityEngine.Debug.Log("trocou " + i + " gênero");
            genderPickers[i].GetComponent<Animator>().runtimeAnimatorController = genderPickers[i].genderOptions[gender] as RuntimeAnimatorController;
            if(gender > 2)
            {
                genderPickers[i].OffsetEnable();
            }
            else
            {
                genderPickers[i].OffsetDisable();
            }
        }
        for(int i = 0; i < clothesPickers.Length; i++)
        {
            UnityEngine.Debug.Log("trocou " + i + " roupa");
            clothesPickers[i].GetComponent<Animator>().runtimeAnimatorController = clothesPickers[i].clothesOptions[clothes] as RuntimeAnimatorController;
            if(clothes > 2)
            {
                clothesPickers[i].OffsetEnable();
            }
            else
            {
                clothesPickers[i].OffsetDisable();
            }
        }
    }
}
