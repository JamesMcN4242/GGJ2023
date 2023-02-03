////////////////////////////////////////////////////////////
/////   Observer.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace PersonalFramework
{
    public class Observer
    {
        private const int k_startingMessageCapacity = 3;
        private readonly List<object> m_messageObjects = new(k_startingMessageCapacity);

        public virtual void ObserveMessage(object message)
        {
            m_messageObjects.Add(message);
        }

        public object[] ConsumeMessages()
        {
            var msgs = m_messageObjects.ToArray();
            m_messageObjects.Clear();
            return msgs;
        }
    }
}