using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSlidersManager : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] public Slider block1Generator;
    [SerializeField] public Slider block1Owen;
    [SerializeField] public Slider block2Generator;
    [SerializeField] public Slider block2Owen;
    [SerializeField] public Slider block3Generator;
    [SerializeField] public Slider block3Owen;
    [SerializeField] public Slider block4Generator;
    [SerializeField] public Slider block4Owen;

    // 1
    public float OnBlock1GeneratorSlider()
    {
        return block1Generator.value;     
    }

    public float OnBlock1OwenSlider()
    {
        return block1Owen.value;
    }

    // 2
    public float OnBlock2GeneratorSlider()
    {
        return block2Generator.value;
    }

    public float OnBlock2OwenSlider()
    {
        return block2Owen.value;
    }

    // 3
    public float OnBlock3GeneratorSlider()
    {
        return block3Generator.value;
    }

    public float OnBlock3OwenSlider()
    {
        return block3Owen.value;
    }

    // 4 
    public float OnBlock4GeneratorSlider()
    {
        return block4Generator.value;
    }

    public float OnBlock4OwenSlider()
    {
        return block4Owen.value;
    }

}
