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

    private bool FadeInOut = false;
    private float TimeScale = 1;
    private float ViewValue = 0f;
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

      if(Value >= WarningValue){
      WarningObject.SetActive(true);
      }else{
      WarningObject.SetActive(false);
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
        }
    }

    public void ChangeValue(float AddValue)
    {
        if(AddValue <= MaximumValue)
        {
            Value += AddValue;
        }
    }
    public void ResetValue()
    {
        if(Value > 0f)
        {
            Value = 0f;
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
