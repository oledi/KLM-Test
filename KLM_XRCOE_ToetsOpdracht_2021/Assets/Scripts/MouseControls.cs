using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControls : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer _renderer;
    public GameObject planeDetailText;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print(gameObject.name + gameObject.tag);
        var detailText = planeDetailText.GetComponent<TextMesh>();
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
