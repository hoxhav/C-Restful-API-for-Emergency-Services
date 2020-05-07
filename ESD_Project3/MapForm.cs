using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESD_Project3
{
    /// <summary>
    /// Reference how to use  GMAP saw this tutorial
    /// http://www.independent-software.com/gmap-net-tutorial-maps-markers-and-polygons.html
    /// </summary>
    public partial class MapForm : Form
    {
        private string position;
        private double latitude, longitude;
        
        public MapForm(string position)
        {
            InitializeComponent();
            this.position = position;
        }

        public MapForm(double latitude, double longitude)
        {
            InitializeComponent();
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /// <summary>
        /// Check if the position has been initialied (for hte address)
        /// if not than we can use latitude nad longitude, else use address (Position var)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapForm_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.position))
            {
                map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                map.Position = new PointLatLng(this.latitude, this.longitude);
            } else
            {
                /*Due to the Visual Studio 2017 I cannot update GoogleLocationService
                 to the latest version so I can use my own API Key to make it work 
                AIzaSyAnwRek3V5mTZ_RI-mbyq47IW3FnPO-9ro 
                because tGoogleLocationService has been recently updated.
                I am using Visual Studio 2017 and not the new 2019 one because we were using in the class
                If I would have the new one with a higher version of the .NETFramework than this would work
                you would pass the API Key to the constructor of GoogleLocationService, but with this version
                it does not take a custom API key, instead it uses the public one which is busy all the time and pops
                an exception. 
                 */
                map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            //    GoogleLocationService locationService = new GoogleLocationService();
                //Could have used the upcoming two lines of code if GoogleService would work
              // MapPoint point = locationService.GetLatLongFromAddress(this.position);
               //map.Position = new PointLatLng(point.Latitude, point.Longitude);
               map.SetPositionByKeywords(this.position);

            }
        }
    }
}
