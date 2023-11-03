using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDoorController : MonoBehaviour
{
   [SerializeField] GameObject _animationDoor;
   [SerializeField] GameObject _triggerZone;
   [SerializeField] GameObject _uiClicskEnableDiable;
   private Animator _animatorDoor;
   public Transform other;

   private void Start() {

        _animatorDoor = _animationDoor.GetComponent<Animator>();
   }

   private void OnTriggerEnter(Collider _triggerZone) {

        if (_triggerZone.gameObject.tag == "Player") {

            if (other) {

                float dist = Vector3.Distance(other.position, transform.position);
                print("Distance to other: " + dist);
            }
            _uiClicskEnableDiable.SetActive(true);
            Debug.Log("YES");
        }
   }

   private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {

            _uiClicskEnableDiable.SetActive(false);
        }
   }
}
