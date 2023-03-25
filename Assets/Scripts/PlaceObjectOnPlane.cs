using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField]
    GameObject m_PlacementPrefab;

    [SerializeField]
    InputActionReference m_PressInputReference;

    Vector2 m_CenterScreen;
    static RaycastHit s_HitInfo;

    void Start()
    {
        m_PressInputReference.action.Enable();
        m_CenterScreen = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        var actionPressed = m_PressInputReference.action.WasPressedThisFrame();

        if (actionPressed)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(m_CenterScreen), out s_HitInfo))
            {
                // hit a plane
                if (s_HitInfo.transform.TryGetComponent(out ARPlane plane))
                {
                    Instantiate(m_PlacementPrefab, s_HitInfo.point, Quaternion.identity);
                }
            }
        }
    }
}
