using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanel : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private UnityEngine.UI.Image image;
    [SerializeField] private UnityEngine.UI.Slider redSlider, greenSlider, blueSlider;
    [SerializeField] private CreateTrail _ref;
    [SerializeField] private UnityEngine.UI.Button clearBtn;

    void Start()
    {
        color = new Color(0,0,0,1);
        clearBtn.onClick.AddListener(() => { _ref.ClearAll(); });
    }

    // Update is called once per frame
    void Update()
    {   
        // Setup Color
        color .r = redSlider.value;
        color .g = greenSlider.value;
        color .b = blueSlider.value;

        image.color = color;
    }


    public Color GetColor()
    {
        return color;
    }

}
