using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameEvent> gameEvents = new List<GameEvent>();

    public void CallEvent(int _index)
    {
        gameEvents[_index].unityEvent.Invoke();
    }
}
