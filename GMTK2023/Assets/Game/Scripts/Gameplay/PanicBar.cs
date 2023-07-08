using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class PanicBar : MonoBehaviour
{
    [Header("VALUES SETTINGS")]
    [SerializeField] private float Value = 0f;
    [SerializeField] private float MaximumValue = 100f;
    [SerializeField] private float WarningValue = 80f;
    [SerializeField] private float SmoothTime = 15f;

    [Header("VIEW SETTINGS")]
    [SerializeField] private Slider BarSlider;
    [SerializeField] private Image BarBackgroundImage;
    [SerializeField] private Image BarFillImage;
    [SerializeField] private GameObject WarningObject;
    private float ViewValue = 0f;

    //->>> ACTIONS - OnPanicValueChanged | OnPanicWarning | OnPanicWarningCancel <<<-
    public static UnityEvent<float> OnPanicValueChanged = new UnityEvent<float>();
    public static UnityEvent OnPanicWarning = new UnityEvent();
    public static UnityEvent OnPanicWarningCancel = new UnityEvent();

    void Start()
    {
        BarSlider.maxValue = MaximumValue;
    }
    void Update()
    {
      if(Value >= 0f){
        ChangeVisibility(true);
        if(ViewValue != Value)
        {
        ChangeViewValues();
        }
      }else{
        ChangeVisibility(false);
      }

      if(Value >= WarningValue && WarningObject.activeSelf == false){
      WarningObject.SetActive(true);
      OnPanicWarning.Invoke();
      }else if(Value < WarningValue && WarningObject.activeSelf == true){
      WarningObject.SetActive(false);
      OnPanicWarningCancel.Invoke();
      }

      if(Value > MaximumValue){
        Value = MaximumValue;
      }
      if(Value < 0f){
        Value = 0f;
      }
    }

//PRIVATE VOID ---
    private void ChangeViewValues()
    {
       ViewValue = Mathf.Lerp(ViewValue, Value, SmoothTime * 0.5f * Time.deltaTime);
       BarSlider.value = ViewValue;
    }
    private void ChangeVisibility(bool SetVisibility)
    {
      //REWORK!!!
    }

//PUBLIC VOIDS ---
    public void SetValueTo(float TargetValue)
    {
        if(TargetValue <= MaximumValue)
        {
            Value = TargetValue;
            OnPanicValueChanged.Invoke(Value);
        }
        else
        {
          Debug.LogAssertion("Set Value too large");
        }
    }

    public void ChangeValue(float AddValue)
    {
        if(AddValue <= MaximumValue)
        {
            Value += AddValue;
            OnPanicValueChanged.Invoke(Value);
        }
        else
        {
          Debug.LogAssertion("Add Value too large");
        }
    }
    public void ResetValue()
    {
        if(Value > 0f)
        {
            Value = 0f;
            OnPanicValueChanged.Invoke(Value);
        }
    }
    public void GetValue(string GetType) // ViewValue | Value
    {
        if(GetType == "Value")
        {
          print(Value);
        }
        if(GetType == "ViewValue")
        {
          print(ViewValue);
        }
      if(GetType != null)
      {
        Debug.LogWarning("Get Value type is ViewValue or Value");
      }
    }
}
