using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MouseControls : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer _renderer;
    public GameObject planeDetailText;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var detailText = planeDetailText.GetComponent<TextMeshPro>();
        detailText.text = gameObject.name + " " + gameObject.tag;
        
        if(planeDetailText.activeSelf == false) { planeDetailText.SetActive(true); }
        else { planeDetailText.SetActive(false); }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _renderer.material.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _renderer.material.color = Color.white;

    }
}
