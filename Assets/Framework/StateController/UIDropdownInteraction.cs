////////////////////////////////////////////////////////////
/////   UIDropdownInteraction.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PersonalFramework
{
    [RequireComponent(typeof(Selectable))]
    public class UIDropdownInteraction : WatchedObject
    {
        public string m_message = string.Empty;

        // Start is called before the first frame update
        private void Start()
        {
            var selectable = GetComponent<Selectable>();

            if (selectable is Dropdown)
            {
                var dropdown = selectable as Dropdown;
                dropdown.onValueChanged.AddListener(OnNewValue);
            }
            else if (selectable is TMP_Dropdown)
            {
                var dropdown = selectable as TMP_Dropdown;
                dropdown.onValueChanged.AddListener(OnNewValue);
            }
            else
                Debug.LogError($"No way to use selectable object of type {selectable.GetType()} as a dropdown");
        }

        ~UIDropdownInteraction()
        {
            ClearAllObservers();
        }

        private void OnNewValue(int newIndex)
        {
            NotifyObservers(m_message + newIndex);
        }
    }
}