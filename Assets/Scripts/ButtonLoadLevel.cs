using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Persisting
{
    
    public class ButtonLoadLevel : MonoBehaviour
    {
        public void OnButtonLoadLevel(string levelName)
        {
            LevelManagerPersist.instance.LoadLevel(levelName);
        }
    }

}
