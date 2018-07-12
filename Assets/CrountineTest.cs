using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrountineTest : MonoBehaviour
{
    MyStartCroutine myStartCroutine;
    static bool isExcuteMyCroutine;
    static bool isExcuteUnityCroutine;

    // Update is called once per frame
    void Update()
    {
        currentFram++;

        if (isExcuteMyCroutine)
            ExcuteCroutine();
    }

    static float currentFram = 0;

    void LateUpdate()
    {
        if (isExcuteMyCroutine|| isExcuteUnityCroutine) 
            Debug.LogError("LateUpdate");
    }

    
    public class MyStartCroutine
    {
        public IEnumerator<float> GetEnumerator()
        {
            if (currentFram > 1)
            {
                isExcuteMyCroutine = false;
                yield break;
            }
           yield  return currentFram;
        }
    }

    void ExcuteCroutine()
    {
        foreach (var item in myStartCroutine)
        {
           // Debug.LogError("当前帧数" + item);
        }
    }


    private void OnGUI()
    {
        if (GUILayout.Button("ExcuteMyCroutine"))
        {
            myStartCroutine = new MyStartCroutine();
            isExcuteMyCroutine = true;
            currentFram = 0;
        }

        if (GUILayout.Button("ExcuteUnityCroutine"))
        {
            StartCoroutine(UnityCroutine());
        }
    }


    IEnumerator UnityCroutine()
    {
        isExcuteUnityCroutine = true;
        currentFram = 0;
        yield return null;
        isExcuteUnityCroutine = false;
    }
}
