////////////////////////////////////////////////////////////
/////   UIButtonInteraction.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

namespace PersonalFramework
{
    [RequireComponent(typeof(Button))]
    public class UIButtonInteraction : WatchedObject
    {
        public string m_message = string.Empty;

        // Start is called before the first frame update
        private void Start()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        ~UIButtonInteraction()
        {
            ClearAllObservers();
        }

        private void OnClick()
        {
            NotifyObservers(m_message);
        }
    }
}