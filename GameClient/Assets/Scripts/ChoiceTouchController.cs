﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChoiceTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
  private GameObject m_LeftObject; 
  private GameObject m_RightObject; 
  public float m_XOffset = 0.3f;
  public float m_YOffset = 0.0f;

	void Start () {
    Object[] prefabs = Resources.LoadAll("Prefabs");
    Vector3 position = new Vector3(-m_XOffset, m_YOffset, 0.0f);	
	  m_LeftObject = Instantiate((GameObject)prefabs[2], position, Quaternion.identity);
    position = new Vector3(m_XOffset, m_YOffset, 0.0f);	
	  m_RightObject = Instantiate((GameObject)prefabs[3], position, Quaternion.identity);
	}

	void Update () {
	}

  public void OnPointerDown(PointerEventData eventData) {
  }

  public void OnPointerUp(PointerEventData eventData) {
    if( eventData.position.x < Screen.width * 0.5 ) {
      Debug.Log("Left side");
      m_LeftObject.AddComponent<Rigidbody>();
    }
    else {
      Debug.Log("Right side");
      m_RightObject.AddComponent<Rigidbody>();
    }
  }
}
