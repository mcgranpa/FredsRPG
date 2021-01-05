using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core

{
    public class ActionScheduler : MonoBehaviour
    {
        //MonoBehaviour currentAction = null;
        IAction currentAction = null;

        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
                print("Cancelling " + currentAction);
            }
            currentAction = action;
        }
    }
}