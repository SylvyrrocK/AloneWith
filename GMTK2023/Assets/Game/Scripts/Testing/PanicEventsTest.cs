using UnityEngine.Events;
using UnityEngine;

public class PanicEventsTest : MonoBehaviour
{
    public PanicBar Bar;
    // Start is called before the first frame update
    void Start()
    {
        PanicBar.OnPanicValueChanged.AddListener(OnPanicValueChanged);
        PanicBar.OnPanicWarning.AddListener(OnPanicWarning);
        PanicBar.OnPanicWarningCancel.AddListener(OnPanicWarningCancel);
    }

    // Update is called once per frame
    void OnPanicValueChanged(float value)
    {
        Debug.Log("Panic value changed to " + value + "Val bar" + Bar.GetValue("Value"));
        
    }
    void OnPanicWarning()
    {
        Debug.Log("Panic warning!");
    }
    void OnPanicWarningCancel()
    {
        Debug.Log("Panic warning cancel!");
    }
}
