using System;
using System.Collections.Generic;
using RockHoundr.Models;
using CsvHelper.Configuration;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace RockHoundr.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public string MapboxAccessToken { get; }
        public string DBAccessToken { get; }


        public string GoogleApiKey { get; }

        public double InitialLatitude { get; set; } = 0;
        public double InitialLongitude { get; set; } = 0;
        public int InitialZoom { get; set; } = 1;

        public IndexModel(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            MapboxAccessToken = configuration["DataService.MapKey"];
            DBAccessToken = configuration["DataService.DBKey"];
        }

        public void OnGet()
        {


            InitialLatitude = 39.742043;
            InitialLongitude = -104.991531;
            InitialZoom = 9;

            try
            {
                using (var reader = new DatabaseReader(_hostingEnvironment.WebRootPath + "\\GeoLite2-City.mmdb"))
                {
                    // Determine the IP Address of the request
                    var ipAddress = HttpContext.Connection.RemoteIpAddress;
                    // Get the city from the IP Address
                    var city = reader.City(ipAddress);

                    if (city?.Location?.Latitude != null && city?.Location?.Longitude != null)
                    {
                        InitialLatitude = city.Location.Latitude.Value;
                        InitialLongitude = city.Location.Longitude.Value;
                        InitialZoom = 9;
                    }
                }
            }
            catch (Exception e)
            {
                // Just suppress errors. If we could not retrieve the location for whatever reason
                // there is not reason to notify the user. We'll just simply not know their current
                // location and won't be able to center the map on it
            }
        }

        public IActionResult OnGetAirports()
        {

            var configuration = new Configuration
            {
                BadDataFound = context => { }
            };

            //using (var sr = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, "mapsdata_mines.dat")))
            //using (var reader = new CsvReader(sr, configuration))
            {
                FeatureCollection featureCollection = new FeatureCollection();

                //while (reader.Read())
                using (var db = new gisdbContext(DBAccessToken))
                {

                    foreach (var dept in db.Testrocks)
                    {

                        string name = dept.Name;
                        string minerals = dept.Mineral;
                        string raregems = dept.Raregems;
                        double latitude = dept.Latitude;
                        double longitude = dept.Longitude;

                        //string name = reader.GetField<string>(4);
                        //string iataCode = reader.GetField<string>(12);
                        //string minedesc = reader.GetField<string>(12);
                        //double latitude = reader.GetField<double>(5);
                        //double longitude = reader.GetField<double>(6);

                        featureCollection.Features.Add(new Feature(
                            new Point(new Position(latitude, longitude)),
                            new Dictionary<string, object>
                            {
                            {"name", name},
                            {"minerals", minerals},
                            {"raregems", raregems}
                            }));

                    }
                }

                return new JsonResult(featureCollection);
            }
        }
    }
}