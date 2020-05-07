using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using static System.Net.WebRequestMethods;
using System.IO;

namespace ESD_Project3
{
    /// <summary>
    /// Not proud of my code solution, but anyhow it is hard way to deal with it because
    /// I am adding everything on runtime dinamically and I am not hardcoding references before.
    /// So I need to add everything during runtime.
    /// </summary>
    public partial class TabsForm : Form
    {

        private Dictionary<int, double> latDict = new Dictionary<int, double>();
        private Dictionary<int, double> longDict = new Dictionary<int, double>();
        private Dictionary<int, string> addrDict = new Dictionary<int, string>();


        private ComboBox locationCombo = new ComboBox();
        private TextBox label = new TextBox();
        private Panel panel = new Panel();
        private Dictionary<int, string> locDict = new Dictionary<int, string>();

        private Panel peoplePanel = new Panel();
        private TextBox peopleBox = new TextBox();
        private ComboBox peopleCombo = new ComboBox();
        private Dictionary<int, string> peopleDict = new Dictionary<int, string>();

        /// <summary>
        /// Gets the orgId and the url from the cell click
        /// </summary>
        /// <param name="url"></param>
        /// <param name="orgId"></param>
        public TabsForm(string url, int orgId)
        {
            InitializeComponent();
            //adds event handles to the combo box manually for the people and location comboboxes
            this.locationCombo.SelectedIndexChanged += new System.EventHandler(this.locationCombo_SelectedIndexChanged);
            this.peopleCombo.SelectedIndexChanged += new System.EventHandler(this.peopleCombo_SelectedIndexChanged);

            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/Application" + url);
                while (reader.Read())
                {   
                    //Adds all Tabs based on the Organization Id dynmically with data retrieved from Simon for that org Id
                    reader.ReadToFollowing("Tab");
                    string t = reader.ReadElementContentAsString();
                    TabPage tab = new TabPage(t);
                    //Adds to the tabPage data for particular tab
                    if(tab.Text.Equals("General")) { 
                    Label label = this.GetGeneral(orgId);
                        tab.Controls.Add(label);
                    } else if(tab.Text.Equals("Locations"))
                    {
                        Panel panel = this.getLocations(orgId);
                        tab.Controls.Add(panel);
                    }
                    else if(tab.Text.Equals("Treatment"))
                    {
                        //Respecting DRY by using one method for all tabs except General, Location, and People
                        DataGridView treatmentTable = this.getDataForTabs(orgId, "Treatments", "treatment");
                        tab.Controls.Add(treatmentTable);
                    }
                    else if (tab.Text.Equals("Training"))
                    {
                        DataGridView trainingTable = this.getDataForTabs(orgId, "Training", "training");
                        tab.Controls.Add(trainingTable);
                    }
                    else if (tab.Text.Equals("Facilities"))
                    {
                        DataGridView facilityTable = this.getDataForTabs(orgId, "Facilities", "facility");
                        tab.Controls.Add(facilityTable);
                    }
                    else if (tab.Text.Equals("Equipment"))
                    {
                        DataGridView equipmentTable = this.getDataForTabs(orgId, "Equipment", "equipment");
                        tab.Controls.Add(equipmentTable);
                    }
                    else if (tab.Text.Equals("Physicians"))
                    {
                        DataGridView physiciansTable = this.getDataForTabs(orgId, "Physicians", "physician");
                        tab.Controls.Add(physiciansTable);
                    }
                    else if(tab.Text.Equals("People"))
                    {
                        Panel panel = this.GetPeople(orgId);
                        tab.Controls.Add(panel);
                    }

                    tabControl.TabPages.Add(tab);

                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        /// <summary>
        /// Changing the TextBox text with dictionary value based on ComboBox selected index since the dictionary
        /// has same keys as the selected indexes.
        /// Note: This is the same logic that I used for the JQuery project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locationCombo_SelectedIndexChanged(object sender,System.EventArgs e)
        {
            Debug.WriteLine(locationCombo.SelectedIndex);
            foreach (KeyValuePair<int, string> entry in locDict)
            {
                //Indexes start from 0, whereas keys start from 1
                if(locationCombo.SelectedIndex+1 == entry.Key) {
                    label.Text = entry.Value;
                }

            }

            //If the latitude dictionary does not have contents than it must mean they were null
            //so we use the Address Dictionary to pass it to the Map Form
            if(latDict.Count == 0)
            {
                MapForm formAddr = new MapForm(addrDict[locationCombo.SelectedIndex]);
                formAddr.ShowDialog();
            } else
            {

                MapForm form = new MapForm(latDict[locationCombo.SelectedIndex], longDict[locationCombo.SelectedIndex]);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Same logic as the locations with the index key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peopleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Debug.WriteLine(peopleCombo.SelectedIndex);
            foreach (KeyValuePair<int, string> entry in peopleDict)
            {
                if (peopleCombo.SelectedIndex == entry.Key)
                {
                    peopleBox.Text = entry.Value;
                }
            }
        }

        /// <summary>
        /// Gets the location textbox, combobox
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        private Panel getLocations(int orgId)
        {
            panel.Size = new System.Drawing.Size(535, 578);
            locationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            panel.AutoScroll = true;
            label.AutoSize = true;
            label.Multiline = true;
            label.ScrollBars = ScrollBars.Vertical;
            label.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Size = new System.Drawing.Size(300, 325);

            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgId + "/Locations");
                string genString = "";
                int latCounter = 0, longCounter = 0;
                while (reader.Read())
                {
                    //Read through tags, go in, skip the tag name, skip the end tag name
                    if (reader.Name.Equals("type"))
                    {
                        reader.Read();
                        genString += "\r\n" + "\r\n" +"Type: " + reader.Value + "\r\n";
                        locationCombo.Items.Add(reader.Value);
                        reader.Read();
                    }
                   if (reader.Name.Equals("address1"))
                    {
                        reader.Read();
                        genString += "Address1: " + reader.Value + "\r\n";
                        addrDict.Add(latCounter, reader.Value);
                        reader.Read();
                    } 
                    if (reader.Name.Equals("address2"))
                    {
                        reader.Read();
                        genString += "Address2: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("city"))
                    {
                        reader.Read();
                        genString += "City: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("state"))
                    {
                        reader.Read();
                        genString += "State: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("zip"))
                    {
                        reader.Read();
                        genString += "ZIP: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("phone"))
                    {
                        reader.Read();
                        genString += "Phone: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("ttyphone"))
                    {
                        reader.Read();
                        genString += "TTYPhone: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("fax"))
                    {
                        reader.Read();
                        genString += "Fax: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("latitude"))
                    {
                        reader.Read();
                        genString += "Latitude: " + reader.Value + "\r\n";
                        Debug.WriteLine(reader.Value.Equals("null"));
                        //If latitude or longitude not null, add to dictionary
                        if (!reader.Value.Equals("null"))
                        {
                            latDict.Add(latCounter, Convert.ToDouble(reader.Value));
                        }
                        latCounter++;
                        reader.Read();
                    }
                    if (reader.Name.Equals("longitude"))
                    {
                        reader.Read();
                        genString += "Longitude: " + reader.Value + "\r\n";
                        if (!reader.Value.Equals("null"))
                        { 
                            longDict.Add(longCounter, Convert.ToDouble(reader.Value));
                        }
                        longCounter++;
                        reader.Read();
                    }
                    if (reader.Name.Equals("countyName"))
                    {
                        reader.Read();
                        genString += "County Name: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if(reader.Name.Equals("siteId"))
                    {
                        reader.Read();
                        locDict.Add(Convert.ToInt32(reader.Value), genString);
                        reader.Read();
                        genString = "";
                    }
                }
               label.Text = locDict[1];
                panel.Controls.Add(locationCombo);
               panel.Controls.Add(label);
                genString = "";
                reader = null;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }

            return panel;
        }

        /// <summary>
        /// Generic method used for all tabs except general, location and people
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="tabType"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        private DataGridView getDataForTabs(int orgId, string tabType, string tag)
        {
            DataGridView table = new DataGridView();
            table.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            table.Size = new System.Drawing.Size(800, 300);

            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgId + "/" + tabType);
                DataSet dataSet = new DataSet();
                
                while(reader.Read())
                {
                    reader.ReadToFollowing(tag);
                    dataSet.ReadXml(reader);
                }
               
                table.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
            return table;
        }

        /// <summary>
        /// Same logic as the location tab with dictionary
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        private Panel GetPeople(int orgId)
        {
            peoplePanel.Size = new System.Drawing.Size(535, 578);
            peopleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            peoplePanel.AutoScroll = true;
            peopleBox.AutoSize = true;
            peopleBox.ReadOnly = true;
            peopleBox.Multiline = true;
            peopleBox.ScrollBars = ScrollBars.Vertical;
            peopleBox.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            peopleBox.Size = new System.Drawing.Size(300, 325);
            try
            {
                int counter = 0;
                String genString = "";
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgId + "/People");
                DataSet dataSet = new DataSet();
                reader.ReadToFollowing("site");
                peopleCombo.Items.Add(reader.GetAttribute("address"));
                while (reader.Read())
                {
                    if (reader.HasAttributes)
                    {
                        peopleCombo.Items.Add(reader.GetAttribute("address"));
                    }
                    if (reader.Name.Equals("fName"))
                    {
                        reader.Read();
                        genString += "\r\n" + "\r\n" + "First Name: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("lName"))
                    {
                        reader.Read();
                        genString += "Last Name: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (reader.Name.Equals("role"))
                    {
                        reader.Read();
                        genString += "Role: " + reader.Value + "\r\n";
                        reader.Read();
                    }
                    if (!reader.HasAttributes && reader.Name.Equals("site"))
                    {
                        peopleDict.Add(counter, genString);
                        counter++;
                        genString = "";
                    }
                }

                peopleBox.Text = peopleDict[0];

            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }

            peoplePanel.Controls.Add(peopleCombo);
            peoplePanel.Controls.Add(peopleBox);
            return this.peoplePanel;
        }

        /// <summary>
        /// Gets the general info into a custom label
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        private Label GetGeneral(int orgId)
        {
            Debug.WriteLine(orgId);
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           label.Size = new System.Drawing.Size(93, 25);

            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgId +"/General");
                string genString = "";
                string[] tagNames = {"Name: ", "Description: ", "Email: ", "Website: ", "Number for Members: ", "Number of Calls: ", "Service Area: " };
                int counter = 0;
                while (reader.Read())
                {
                    if (reader.Value != string.Empty) { 
                        genString += tagNames[counter++] + "   " + reader.Value + "\n\r";
                    }
                }
                label.Text = genString;
                counter = 0;
                genString = "";
                reader = null;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }

            return label;
        }

        /// <summary>
        /// Generic method to respect DRY
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private XmlReader GetXmlForGivenPath(string path)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            request.Method = Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            XmlReader reader = XmlReader.Create(response.GetResponseStream());
            return reader;
        }
    }
}
