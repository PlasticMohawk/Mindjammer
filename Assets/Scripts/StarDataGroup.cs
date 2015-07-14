﻿// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu("")]
public class StarDataGroup : MonoBehaviour
{
    public SgtStarfield Starfield;
    
    public Texture Texture;
    
    [System.NonSerialized]
    public Material Material;
    
    [System.NonSerialized]
    public Vector3 TempPosition;
    
    [System.NonSerialized]
    public List<SgtStarfieldStar> Stars = new List<SgtStarfieldStar>(); // This is only used when generating the group
    
    public List<SgtStarfieldModel> Models = new List<SgtStarfieldModel>();
    
    public void ManualUpdate()
    {
        for (var i = Models.Count - 1; i >= 0; i--)
        {
            var model = Models[i];
            
            if (model != null)
            {
                model.ManualUpdate();
            }
        }
    }
    
    public static StarDataGroup Create(SgtStarfield starfield)
    {
        var group = SgtComponentPool<StarDataGroup>.Pop("Group", starfield.transform);
        
        group.Starfield = starfield;
        
        return group;
    }
    
    public static void Pool(StarDataGroup group)
    {
        if (group != null)
        {
            group.Starfield = null;
            group.Texture   = null;
            group.Material  = null;
            
            for (var i = group.Models.Count - 1; i >= 0; i--)
            {
                SgtStarfieldModel.Pool(group.Models[i]);
            }
            
            group.Models.Clear();
            
            SgtComponentPool<StarDataGroup>.Add(group);
        }
    }
    
    public static void MarkForDestruction(StarDataGroup group)
    {
        if (group != null)
        {
            group.Starfield = null;
            
            group.gameObject.SetActive(true);
        }
    }
    
    protected virtual void OnDestroy()
    {
        for (var i = Models.Count - 1; i >= 0; i--)
        {
            SgtStarfieldModel.MarkForDestruction(Models[i]);
        }
        
        Models.Clear();
    }
    
    protected virtual void Update()
    {
        if (Starfield == null)
        {
            Pool(this);
        }
    }
}