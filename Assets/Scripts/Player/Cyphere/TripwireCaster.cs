using System;
using System.Collections.Generic;
using UnityEngine;

public class TripwireCaster : SpellCaster
{
    
    [SerializeField] private float raydistance = 20f;
    [SerializeField] private LayerMask rayLayerMask;

    public Transform firstContactPoint;
    public Transform secondContactPoint;
    public LineRenderer lineRenderer;
    public GameObject tripWirePrefab;
    public List<Tripwire> tripsCasted;

    void Start()
    {
        secondContactPoint.gameObject.SetActive(false);
        firstContactPoint.gameObject.SetActive(false);
    }

    public override void TryCast(out bool spellIsCasted)
    {
        if (canCast)
        {
            var trip = Instantiate(tripWirePrefab).GetComponent<Tripwire>();
            trip.SetupTripwire(firstContactPoint.position, secondContactPoint.position);

            firstContactPoint.gameObject.SetActive(false);
            secondContactPoint.gameObject.SetActive(false);

            spellIsCasted  = true;
            Debug.Log("Spell casted");

        }else
        {
            spellIsCasted  = false;
        }
    }
    
    public override void Destory()
    {
        base.Destory();
    }

    public override void OnCast()
    {
        
    }

    public override void OnSelect()
    {
        
        var camera = Camera.main;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit firstContactInfo, raydistance, rayLayerMask))
        {
            Debug.DrawRay(camera.transform.position, camera.transform.forward * raydistance, Color.red, .1f);
            firstContactPoint.gameObject.SetActive(true);
            firstContactPoint.position = firstContactInfo.point;


            if(Physics.Raycast(firstContactInfo.point, firstContactInfo.normal, out RaycastHit secondContatInfo, raydistance, rayLayerMask))
            {
                Debug.DrawRay(firstContactInfo.point, firstContactInfo.normal * raydistance, Color.green, .1f);
                secondContactPoint.gameObject.SetActive(true);
                secondContactPoint.position = secondContatInfo.point;
                canCast = true;
            }
            else
            {
                secondContactPoint.gameObject.SetActive(false);
                canCast = false;
            }
        }
        else
        {
            secondContactPoint.gameObject.SetActive(false);
            firstContactPoint.gameObject.SetActive(false);
            canCast = false;
        }
    }

    public override void Equip()
    {
        base.Equip();
    }   
    
    public override void Unequip()
    {
        base.Unequip();
    }


    #region  HELPER
    #endregion
}
