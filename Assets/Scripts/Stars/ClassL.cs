﻿// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassL : MonoBehaviour
{

    private Color ClassLcolor = new Vector4(0.95f, 0.17f, 0.48f, 1f);
    public string Description;
    private Text ThisTooltip;
    private BaseStar TheBaseStar;
    private BaseSpectralClass TheBaseSpectralClass;

    private float HZoneOrbitalDistance;
    private float HZoneOrbitalPeriod;
    
    private string[] PlentifulResources;
    private string[] ScarceResources;
    
    void Awake()
    {
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassLcolor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    // Use this for initialization
    void Start()
    {
        Description = "Also known as L-dwarfs, these very faint dark red “brown dwarf” stars are at the very bottom limit for supporting hydrogen fusion; some do not. L-class giants and supergiants " +
            "exist. Twice as numerous as stars, they’re rich in metal hydrides, used in ZIP cells, and alkali metals, used in genurgic and mechanical enhancements. While L-class stars live long " +
                "enough to evolve biospheres, habitable zone planets must be so close to the star that they are torn apart by tidal forces.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class L";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = 4;
        
        TheBaseSpectralClass.Temperature = Random.Range(1300, 2000) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(0.005f, 0.075f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(0.1f, 0.2f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(0.000001f, 0.00001f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 0f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 0f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 0f;
        
        TheBaseSpectralClass.PlanetaryBodies = 10; // only moons
        TheBaseSpectralClass.BiosphereModifier = -2;
        
        TheBaseSpectralClass.VegetationColor = "Black";
        TheBaseSpectralClass.SkyColor = "Reddish-orange";

        TheBaseSpectralClass.PlentifulResources.Add("Metal Hydrides");
        TheBaseSpectralClass.PlentifulResources.Add("Alkali Metals");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Cool Red-brown Star");
        TheBaseSpectralClass.Aspects.Add("X-Ray Flares");

        // add variables to class TheBaseStar for calculation
        TheBaseStar.SpectralClass = TheBaseSpectralClass.SpectralClassName;
        TheBaseStar.SpectralClassDescription = Description;
        TheBaseStar.TemperatureInCelsius = TheBaseSpectralClass.Temperature;
        TheBaseStar.MassInSols = TheBaseSpectralClass.Mass;
        TheBaseStar.RadiusInSols = TheBaseSpectralClass.Radius;
        TheBaseStar.LuminosityInSols = TheBaseSpectralClass.Luminosity;
        TheBaseStar.HabitableZonePeriod = HZoneOrbitalPeriod;
        TheBaseStar.HabitableZoneDistance = HZoneOrbitalDistance;
        TheBaseStar.VegetationColor = TheBaseSpectralClass.VegetationColor;
        TheBaseStar.SkyColor = TheBaseSpectralClass.SkyColor;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
