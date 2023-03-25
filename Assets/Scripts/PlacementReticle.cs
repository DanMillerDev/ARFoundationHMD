using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacementReticle : MonoBehaviour
{
    [SerializeField]
    Transform m_ReticleTransform;
    
    Vector2 m_CenterScreen;
    static RaycastHit s_HitInfo;

    void Start()
    {
        m_CenterScreen = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(m_CenterScreen), out s_HitInfo))
        {
            if (s_HitInfo.transform.TryGetComponent(out ARPlane plane))
            {
                m_ReticleTransform.transform.position = s_HitInfo.point;
                m_ReticleTransform.transform.rotation = Quaternion.FromToRotation(m_ReticleTransform.up, s_HitInfo.normal);
            }
        }
    }
}
