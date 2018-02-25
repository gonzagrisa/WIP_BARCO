using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image JAtras;
	private Image JAdelante;
	private Vector3 inputVector;

	private void Start(){
		JAtras = GetComponent<Image> ();
		JAdelante = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (JAtras.rectTransform,
																	 	ped.position,
			   															ped.pressEventCamera,
			 															out pos))
		{
			pos.x = (pos.x / JAtras.rectTransform.sizeDelta.x);
			pos.y = (pos.y / JAtras.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x * 2 + 1, 0, pos.y * 2 - 1);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			//Moviendo el Joystick
			JAdelante.rectTransform.anchoredPosition = 
				new Vector3 (inputVector.x * (JAtras.rectTransform.sizeDelta.x / 3)
					, inputVector.z * (JAtras.rectTransform.sizeDelta.y / 3));
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		inputVector = Vector3.zero;
		JAdelante.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal(){
		if (inputVector.x != 0) {
			return inputVector.x;
		} else {
			return Input.GetAxis ("Horizontal");
		}
	}
	public float Vertical(){
		if (inputVector.z != 0) {
			return inputVector.z;
		} else {
			return Input.GetAxis ("Vertical");
		}
	}
}
