using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsEffect : MonoBehaviour , IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    Button button;
    Vector3 buttonStartingSize;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        buttonStartingSize = button.transform.localScale;
    }
    public void OnClickAnimationEffect()
    {
        button.transform.LeanScale(new Vector3(1.3f, 1.3f), 0.3f).setOnComplete(
            delegate() { button.transform.localScale = buttonStartingSize;} );
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickAnimationEffect();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        button.transform.LeanScale(new Vector3(1.3f, 1.3f), 0.3f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.transform.localScale = buttonStartingSize;
    }
}
