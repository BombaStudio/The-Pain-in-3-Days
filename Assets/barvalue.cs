using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class barvalue : MonoBehaviour
{
    public TextMeshProUGUI Bar;
    public int Value = 100;
    // Start is called before the first frame update
    void Start()
    {
        Bar = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.text = Value.ToString();
    }
}
