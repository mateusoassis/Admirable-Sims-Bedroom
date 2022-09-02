using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyMessageBehaviour : MonoBehaviour
{
    [SerializeField] private float timeToStartVanish;
    [SerializeField] private float timeToVanish;
    [SerializeField] private TextMeshPro timeText;
    public Color initialColor;
    public Color targetColor;

    public float timer;
    public bool vanishing;

    void Awake()
    {
        
    }

    void Start()
    {
        initialColor = timeText.color;
        targetColor = initialColor;
        targetColor.a = 0f;
    }

    void Update()
    {
        
        timer += Time.deltaTime;
        
        if(!vanishing)
        {
            if(timer > timeToStartVanish)
            {
                vanishing = true;
                timer = 0;
            }
        }
        else
        {
            
            Color thisColor = Color.Lerp(initialColor, targetColor, timer/timeToVanish);
            timeText.color = thisColor;
            transform.position += Vector3.up * Time.deltaTime/2;
        }

        if(timeText.color.a == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
