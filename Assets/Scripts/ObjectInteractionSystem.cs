using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteractionSystem : MonoBehaviour
{
    [SerializeField] private InfosPlayer InfosPlayer;
    [SerializeField] private GameObject _target;
    [SerializeField] private Camera _cam;
    private float _distance;
    private float _distanceToObj;
    private string _name;
    private bool _isVisible;
    
    private void Start() {
        
        _isVisible = false;
    }

    private void Update()
    {
        
        GetObjectName();
        GetObjectDistance();
        ObjIsVisible();
    }

    private void GetObjectName() {

       _name = _target.name;

       if (_target.tag == "interact" && _distanceToObj <= 2.5f && _isVisible) {

            InfosPlayer.targetObj = _name;
            InfosPlayer.targetObjVisible = true;
       }

       else {
            InfosPlayer.targetObj = "";
            InfosPlayer.targetObjVisible = false;
       }
    }

    private void GetObjectDistance() {
        
        //gets the distance from the targeted object and the camera and outputs it in the float _distance
        _distance = Vector3.Distance(_target.transform.position, _cam.transform.position);
        _distanceToObj = _distance;
    }

#region Camera Visibility
    private bool IsVisible(Camera c, GameObject target) {

        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes) {

            if (plane.GetDistanceToPoint(point) < 0) {
                
                return false;
            }
        }
        return true;
    }

    private void ObjIsVisible() {

        if(IsVisible(_cam, _target)) {

            _isVisible = true;
        }

        else {

            _isVisible = false;
        }
    }
#endregion
}
