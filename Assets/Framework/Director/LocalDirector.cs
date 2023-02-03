////////////////////////////////////////////////////////////
/////   LocalDirector.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

namespace PersonalFramework
{
    public class LocalDirector : MonoBehaviour
    {
        protected StateController m_stateController = new();

        // Update is called once per frame
        private void Update()
        {
            m_stateController.UpdateStack();
        }

        private void FixedUpdate()
        {
            m_stateController.FixedUpdateStack();
        }
    }
}