﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneControl : MonoBehaviour
{
    public objectSelect objSelect;
    editStateController stateController;
    public float scaleSize = .5f;

    private void Start()
    {
        stateController = GetComponent<editStateController>();
        objSelect.trackedController2.TriggerClicked += triggerClicked;
    }

    private void OnDestroy()
    {
        objSelect.trackedController2.TriggerClicked -= triggerClicked;
    }

    void triggerClicked(object sender, ClickedEventArgs e)
    {
        if (objSelect.trackedController2.gripped)
        {
            var clone = Instantiate(this.gameObject) as GameObject;
            clone.transform.rotation = transform.rotation;
            clone.transform.position = transform.position;

            for (int i = 0; i < clone.GetComponent<editStateController>().components.Count; i++)
            {
                Destroy(clone.GetComponent<editStateController>().components[i]);
            }

            Destroy(clone.GetComponent<editStateController>());
            Destroy(clone.GetComponent<cakeslice.Outline>());

            clone.GetComponent<Collider>().enabled = true;
        }
    }
}