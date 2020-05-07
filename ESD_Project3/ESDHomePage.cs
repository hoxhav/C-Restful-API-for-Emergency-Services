using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace ESD_Project3
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
   
        }

        /// <summary>
        /// When form loads, it fills the Combobox for organizations and states, and disables the
        /// Extra Point Save Initial search to XML button because the user has not searched anything yet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            saveSearch.Enabled = false;
            GetOrgType();
            GetStates();
        }

        /// <summary>
        /// Respecting DRY
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

        /// <summary>
        /// Autofilling the States
        /// </summary>
        private void GetStates()
        {
            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/States");
                stateComboBox.Items.Add("--All States--"); //adding initial text for searching all states purpose
                while (reader.Read())
                {
                    reader.ReadToFollowing("State");
                    stateComboBox.Items.Add(reader.ReadElementContentAsString());
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        /// <summary>
        /// Same logic as state but for organizations
        /// </summary>
        private void GetOrgType()
        {
            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/OrgTypes");
                orgTypeComboBox.Items.Add("--All Organizations--");

             while (reader.Read())
                {
                    reader.ReadToFollowing("type");
                    orgTypeComboBox.Items.Add(reader.ReadElementContentAsString());
                    
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        /// <summary>
        /// Based on the state we update the county, and if the state resets, county and city combobox's will reset too
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/Counties?state=" + stateComboBox.GetItemText(stateComboBox.SelectedItem));
                countyComboBox.Items.Clear();
                cityComboBox.Items.Clear();
                countyComboBox.Items.Add("--All Counties--");
                while (reader.Read())
                {
                    reader.ReadToFollowing("CountyName");
                    countyComboBox.Items.Add(reader.ReadElementContentAsString());

                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }
        
        /// <summary>
        /// Same logic as for the state except only city combobox resets if we change the county
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/Cities?county=" + countyComboBox.GetItemText(countyComboBox.SelectedItem));
                cityComboBox.Items.Clear();
                cityComboBox.Items.Add("--All Cities--");
                while (reader.Read())
                {
                    reader.ReadToFollowing("city");
                    cityComboBox.Items.Add(reader.ReadElementContentAsString());

                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

       /// <summary>
       /// When search button is clicked we first validate the zip code field, then checks  if we have
       /// the "All" for the comboboxes in order to make a search
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            this.validate();
            try
            {
                //Puts the search button to loading
                searchButton.Text = "Loading";
                searchPanel.Enabled = false; //disables the panel in order not to multiclick while searching
                string type, town, state, county;
                if(orgTypeComboBox.GetItemText(orgTypeComboBox.SelectedItem).Equals("--All Organizations--"))
                {
                    type = "";
                } else
                {
                    type = orgTypeComboBox.GetItemText(orgTypeComboBox.SelectedItem);
                }

                if(cityComboBox.GetItemText(cityComboBox.SelectedItem).Equals("--All Cities--"))
                {
                    town = "";
                } else
                {
                    town = cityComboBox.GetItemText(cityComboBox.SelectedItem);
                }

                if(stateComboBox.GetItemText(stateComboBox.SelectedItem).Equals("--All States--"))
                {
                    state = "";
                } else
                {
                    state = stateComboBox.GetItemText(stateComboBox.SelectedItem);
                }


                if(countyComboBox.GetItemText(countyComboBox.SelectedItem).Equals("--All Counties"))
                {
                    county = "";
                } else
                {
                    county = countyComboBox.GetItemText(countyComboBox.SelectedItem);
                }
                saveSearch.Enabled = true;
                XmlReader reader = GetXmlForGivenPath("http://simon.ist.rit.edu:8080/Services/resources/ESD/Organizations?type=" + type +  "&name=" + orgNameTextBox.Text+ "&town=" + town + "&state=" + state + "&zip=" +zipTextBox.Text+"&county=" + county);
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                esdDataGridView.DataSource = dataSet.Tables[0];
                if(esdDataGridView.Columns.Count <= 8) // physician data if it is higher than 8 colums
                {
                    esdDataGridView.Columns[0].Visible = false;
                } else
                {
                    esdDataGridView.Columns[3].Visible = false; // hide id for physician
                }

                searchPanel.Enabled = true; //re enable everything
                searchButton.Text = "Search";
                
            }
            catch(IndexOutOfRangeException eee)
            {
                MessageBox.Show("No results with this search");
                searchPanel.Enabled = true;
                searchButton.Text = "Search";
                Debug.Write(eee.StackTrace);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        /// <summary>
        /// Validates the textbox for zip, it must contain only numeric values
        /// I used this tutorial how to do it, and modified it a little by myself
        /// REFERENCE: https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number
        /// </summary>
        private void validate()
        {
            if (zipTextBox.Text.Length > 0)
            {
                if (!Regex.IsMatch(zipTextBox.Text, @"^\d+$"))
                {
                    MessageBox.Show("Zip code should be numeric");
                    return;
                }
            }
        }

        /// <summary>
        /// If you click name we go to the Tabs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void esdDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            int id = 0;
            if(esdDataGridView.Columns[col].Name.Equals("Name"))
            {
                if(esdDataGridView.Columns.Count > 8)
                {
                    id = 3;
                } 
                int orgId = Convert.ToInt32(esdDataGridView[id, row].Value);
                string url = "/Tabs?orgId=" + orgId;
                TabsForm form = new TabsForm(url, orgId);
                form.Show();
            }
        }

        /// <summary>
        /// Saves the Data grid view to a .xml file for the Extra Point part
        /// You can find the file into the /bin/debug folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveSearch_Click(object sender, EventArgs e)
        {
            DataTable dataT = (DataTable)esdDataGridView.DataSource;
            dataT.WriteXml("savedSearch.xml"); //bin/debug folder
        }

        /// <summary>
        /// Clear button which resets the search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            orgNameTextBox.Text = "";
            zipTextBox.Text = "";
        }
    }
}
