using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if IS_DEMO_BUILD
        var demoObject = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g => g.CompareTag("DemoOnly"));
        demoObject.SetActive(true);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
