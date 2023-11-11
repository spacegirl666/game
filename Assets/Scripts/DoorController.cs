using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject _uiClicskEnableDiable;
    public bool _active;
    public bool _open;
    public bool _allConditionsTrue;
    public GameObject target;
    public Camera cam;
    private bool _isVisible;


   private void Start() {

        _active = false;
        _isVisible = false;
        _allConditionsTrue = false;
   }

        private void Update() {

        if(IsVisible(cam, target)) {

            _isVisible = true;
        }

        else {

            _isVisible = false;
        }
    }

   private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            if (_isVisible) {

                _active = true;
            }
            
        }
   }

   private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {

            _uiClicskEnableDiable.SetActive(false);
            _active = false;
            _allConditionsTrue = false;
        }
   }

   private void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Player" && _isVisible == true && _active == true || other.gameObject.tag == "Player" && _isVisible == true && _active == false) {

            _uiClicskEnableDiable.SetActive(true);
            _allConditionsTrue = true;
        }

        else {

            _uiClicskEnableDiable.SetActive(false);
            _allConditionsTrue = false;
        }
   }

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
}
