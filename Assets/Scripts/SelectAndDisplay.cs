﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAndDisplay : MonoBehaviour
{
    MeshRenderer _renderer;
    Color _selectionColor = Color.green;
    Color _default;

    Text _selectedPart;
    [SerializeField]
    private string partName; // if left blank then it will use the transform name.

    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();

        if (_renderer.material.HasProperty("_Color"))
        {
            _default = _renderer.material.color;
        }
        try
        {
            _selectedPart = GameObject.Find("SelectedPartText").GetComponent<Text>();
        }
        catch
        {
            _selectedPart = new GameObject("SelectedPartText").AddComponent<Text>();
            _selectedPart.resizeTextForBestFit = true;
            _selectedPart.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            _selectedPart.transform.parent = GameObject.Find("Canvas").transform;
            _selectedPart.rectTransform.position = new Vector3(Screen.width/2,Screen.height/1.25f,0);
            _selectedPart.horizontalOverflow = HorizontalWrapMode.Overflow;
        }
    }
    void OnEnable()
    {
        EventManager.Listen("ButtonCreation", CreateButtonForParts);
    }
    void OnDisable()
    {
        EventManager.UnsubscribeEvent("ButtonCreation", CreateButtonForParts);
    }
    void OnMouseDown()
    {
        Debug.Log(transform.name);
        Camera.main.transform.LookAt(transform);
        Camera.main.fieldOfView = 30;
        if(!string.IsNullOrEmpty(partName))
        {
            _selectedPart.text = partName;
        }
        else
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

    void CreateButtonForParts()
    {
        var buttonGroup = GameObject.Find("ButtonGroup").transform;


        var Q = new GameObject("CarPart:" + transform.name);
        if (!string.IsNullOrEmpty(partName))
        {
            Q.AddComponent<Text>().text = "Part:" + partName;
        }
        else
        {
            Q.AddComponent<Text>().text = "Part:" + transform.name;
        }
        var text = Q.GetComponent<Text>();
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.resizeTextForBestFit = true;
        Q.AddComponent<Button>().onClick.AddListener(OnMouseDown);
        Q.transform.parent = buttonGroup;
    }

}
