using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhichHussyHicksLived : MonoBehaviour
{
    [SerializeField] HussyHickObject JulzObj;
    [SerializeField] HussyHickObject LeesaObj;
    [SerializeField] HussyHickObject AliObj;
    [SerializeField] HussyHickObject TraceObj;

    [SerializeField] GameObject regularTimeline;
    [SerializeField] GameObject julzAndLeesaOnly;
    [SerializeField] GameObject noHussyhicksSaved;
    [SerializeField] bool julzAndLeesa;

    [SerializeField] GameObject Julz;
    [SerializeField] GameObject Leesa;
    [SerializeField] GameObject Ali;
    [SerializeField] GameObject Trace;

    [SerializeField] GameObject Drums;
    [SerializeField] GameObject Bass;
    [SerializeField] GameObject Strat;
    [SerializeField] GameObject Tambourine;

    [SerializeField] List<HussyHickObject> savedHicks = new List<HussyHickObject>();
    void Start()
    {
        savedHicks = GameManagerDog.instance.CheckWhichHussyHicksSaved();
        RemoveHussys();
    }

    void RemoveHussys()
    {
        if (savedHicks.Count == 0)
        {
            noHussyhicksSaved.SetActive(true);
        }
        else
        {
            if (!savedHicks.Contains(JulzObj))
            {
                Destroy(Julz);
                Destroy(Strat);
            }

            if (!savedHicks.Contains(LeesaObj))
            {
                Destroy(Leesa);
                Destroy(Tambourine);
            }

            if (!savedHicks.Contains(AliObj))
            {
                Destroy(Ali);
                Destroy(Drums);
            }

            if (!savedHicks.Contains(TraceObj))
            {
                Destroy(Trace);
                Destroy(Bass);
            }


            if (savedHicks.Contains(JulzObj) && savedHicks.Contains(LeesaObj) && !savedHicks.Contains(AliObj) && !savedHicks.Contains(TraceObj))
            {
                julzAndLeesaOnly.SetActive(true);
                julzAndLeesa = true;
            }
            else
            {
                regularTimeline.SetActive(true);
                julzAndLeesa = false;
            }
        }

    }

    public bool CheckIfJulzAndLeesa()
    {
        return julzAndLeesa;
    }
}
