using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagementInteraction : MonoBehaviour
{
    [SerializeField] private InfosPlayer InfosPlayer;
    [SerializeField] GameObject _UIElementImg;
    [SerializeField] GameObject _UIElementText;
    [SerializeField] TMP_Text _UIElementTextTxt;
    
    void Start()
    {
        
        _UIElementImg.SetActive(false);
        _UIElementText.SetActive(false);
    }

    
    void Update()
    {
        if(InfosPlayer.targetObjVisible == true) {

            _UIElementTextTxt.text = InfosPlayer.targetObj;
            _UIElementImg.SetActive(true);
            _UIElementText.SetActive(true);
        }

        else {

            _UIElementTextTxt.text = "";
            _UIElementImg.SetActive(false);
            _UIElementText.SetActive(false);
        }
    }
}
