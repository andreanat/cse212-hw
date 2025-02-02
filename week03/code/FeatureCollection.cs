using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
//step 1: create a class to represent the earthquake data
public class FeatureCollection
{
    //list of earthquake features
    [JsonPropertyName("features")]
    public List<EarthquakeFeature> Features { get; set; }
}
public class EarthquakeFeature
{
    //properties of the earthquake
    [JsonPropertyName("properties")]
    public EarthquakeProperties Properties { get; set; }
}
public class EarthquakeProperties
{
    //magnitude of the earthquake
    [JsonPropertyName("mag")]
    public double Magnitude { get; set; }
    //place of the earthquake
    [JsonPropertyName("place")]
    public string Place { get; set; }
    //time of the earthquake
    [JsonPropertyName("time")]
    public long Time { get; set; }
}