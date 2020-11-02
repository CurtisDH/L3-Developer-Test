using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAndDisplay : MonoBehaviour
{
    MeshRenderer _renderer;
    Color _selectionColor = Color.green;
    Color _default;

    Text _selectedPart;

    void Awake()
    {
        _default = GetComponent<MeshRenderer>().material.color;


        _renderer = GetComponent<MeshRenderer>();
        try
        {
            _selectedPart = GameObject.Find("SelectedPartText").GetComponent<Text>();
        }
        catch
        {
            _selectedPart = new GameObject("SelectedPartText").AddComponent<Text>();
        }
    }
    void OnMouseDown()
    {
        Debug.Log(transform.name);
        Camera.main.transform.LookAt(transform);
        Camera.main.fieldOfView = 30;
        _selectedPart.text = transform.name;
    }
    void OnMouseEnter()
    {
        _renderer.material.color = _selectionColor;
    }
    void OnMouseExit()
    {
        _renderer.material.color = _default;
    }


}
