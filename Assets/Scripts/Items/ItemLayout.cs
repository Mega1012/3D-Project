using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Itens.ItemManager;
using TMPro;
using UnityEngine.UI;

namespace Itens
{


    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup _currSetup;

        public Image uiIcon;
        public TextMeshProUGUI uiValue;

        public void Load(ItemSetup setup)
        {
            _currSetup = setup;
            UpdateUi();
        }

        private void UpdateUi()
        {
            uiIcon.sprite = _currSetup.Icon;
        }

        private void Update()
        {
            uiValue.text = _currSetup.soInt.value.ToString();
        }
    }
}