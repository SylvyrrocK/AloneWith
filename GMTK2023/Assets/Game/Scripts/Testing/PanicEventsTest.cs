using UnityEngine.Events;
using UnityEngine;

public class PanicEventsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PanicBar.OnPanicValueChanged.AddListener(OnPanicWarning);
        PanicBar.OnPanicWarning.AddListener(OnPanicWarning);
        PanicBar.OnPanicWarningCancel.AddListener(OnPanicWarningCancel);
    }

    // Update is called once per frame
    void OnPanicWarning(float value)
    {
        Debug.Log("Panic value changed to " + value);
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
