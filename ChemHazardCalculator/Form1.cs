using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using AdvancedATP45.ChemHazard;

namespace ChemHazardCalculator
{
    public partial class Form1 : Form
    {
        public static ChemHazardViewModel vm;
        public TotalDosagePattern totalPattern;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtmosphericStability.DataSource = Enum.GetValues(typeof(AdvancedATP45.ChemHazard.PasquillStabilityCategory));

            vm = new ChemHazardViewModel();

            // set up the form data bindings to the view model
            AtmosphericStability.DataBindings.Add(new Binding("SelectedItem", vm, "Psc", true,
                DataSourceUpdateMode.OnPropertyChanged));

            TSTButtonLand.DataBindings.Add(new Binding("Checked", vm, "TstButtonLand", true,
                DataSourceUpdateMode.OnPropertyChanged));

            TSTButtonSea.DataBindings.Add(new Binding("Checked", vm, "TstButtonSea", true,
                DataSourceUpdateMode.OnPropertyChanged));

            MphKphLabel.DataBindings.Add(new Binding("Text", vm, "MphKphLabelString", true,
                DataSourceUpdateMode.OnPropertyChanged));

            WindspeedUpDown.DataBindings.Add(new Binding("Value", vm, "UKts", true,
                DataSourceUpdateMode.OnPropertyChanged));

            WeaponNameTextbox.DataBindings.Add(new Binding("Text", vm, "WeaponName", true,
                DataSourceUpdateMode.OnPropertyChanged));

            AgentNameTextbox.DataBindings.Add(new Binding("Text", vm, "AgentName", true,
                DataSourceUpdateMode.OnPropertyChanged));

            FillWeightUpDown.DataBindings.Add(new Binding("Value", vm, "Qkg", true,
                DataSourceUpdateMode.OnPropertyChanged));

            ThresholdUpDown.DataBindings.Add(new Binding("Value", vm, "ThresholdDosage", true,
                DataSourceUpdateMode.OnPropertyChanged));

            ICT50UpDown.DataBindings.Add(new Binding("Value", vm, "ICT50Dosage", true,
                DataSourceUpdateMode.OnPropertyChanged));

            LCT50UpDown.DataBindings.Add(new Binding("Value", vm, "LCT50Dosage", true,
                DataSourceUpdateMode.OnPropertyChanged));

            CalculateButton.DataBindings.Add(new Binding("Enabled", vm, "EnableCalculate", true,
                DataSourceUpdateMode.OnPropertyChanged));

            ClearButton.Enabled = true;
        }

        // we do it this way rather than bind to the viewmodel property to ensure immediate UI update
        private void WindspeedUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal windspeedKts = WindspeedUpDown.Value;

            string labelValue = string.Format("{0:N1} KPH, {1:N1} MPH, {2:N1} MPS", (double)windspeedKts * ChemHazardViewModel.ktsToKphFactor,
                (double)windspeedKts * ChemHazardViewModel.ktsToMphFactor, (double)windspeedKts * ChemHazardViewModel.ktsToMpsFactor);

            MphKphLabel.Text = labelValue;
        }

        // clear and reset the form
        private void ClearButton_Click(object sender, EventArgs e)
        {
            // clear all the form values
            vm.AgentName = string.Empty;
            vm.WeaponName = string.Empty;
            vm.ICT50Dosage = 0;
            vm.LCT50Dosage = 0;
            vm.ThresholdDosage = 0;
            vm.Qkg = 0;
            vm.UKts = 0;
            vm.EnableCalculate = false;
            vm.WpnNameEntered = false;
            vm.AgentNameEntered = false;
            vm.FillWeightEntered = false;
            vm.WindspeedEntered = false;
            vm.ThresholdEntered = false;
            vm.ICT50Entered = false;
            vm.LCT50Entered = false;
        }

        // calculate and display the results in the RichTextBox
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            // check the values in the ViewModel to see if they are correct before we calculate

            if(( vm.LCT50Dosage > vm.ICT50Dosage ) && (vm.ICT50Dosage > vm.ThresholdDosage) && (vm.ThresholdDosage > 0) && (vm.UKts > 0) && (vm.Qkg > 0))
            {
                // we don't have to check the other values because we wouldn't have gotten here unless they are > 0
                totalPattern = new TotalDosagePattern();
                totalPattern.AgentName = vm.AgentName;
                totalPattern.WeaponName = vm.WeaponName;
                totalPattern.Qkg = vm.Qkg;
                totalPattern.UKts = vm.UKts;
                totalPattern.Psc = vm.Psc;
                totalPattern.Tst = vm.Tst;

                // calculate the dosage patterns & stats
                totalPattern.Patterns.Add(totalPattern.CalculateDosagePattern(vm.ThresholdDosage));
                totalPattern.Patterns.Add(totalPattern.CalculateDosagePattern(vm.ICT50Dosage));
                totalPattern.Patterns.Add(totalPattern.CalculateDosagePattern(vm.LCT50Dosage));

                vm.CalculatedPattern = totalPattern;

                ResultsRichText.Clear();

                // output the results to the ResultsRichText box
                ResultsRichText.AppendText(string.Format("Total Dosage Patterns for {0}{1}", totalPattern.WeaponName, Environment.NewLine));
                ResultsRichText.AppendText(string.Format("Filled with {0} kilograms of {1}, explosive release{2}", totalPattern.Qkg, totalPattern.AgentName, Environment.NewLine));
                ResultsRichText.AppendText(string.Format("Atmospheric stability of {0}{1}", totalPattern.Psc.ToString(), Environment.NewLine));
                ResultsRichText.AppendText(string.Format("Target Surface Type is {0}{1}", totalPattern.Tst.ToString(), Environment.NewLine));
                ResultsRichText.AppendText(string.Format("Windspeed is {0:0.0} knots", totalPattern.UKts));
                ResultsRichText.AppendText(Environment.NewLine);
                ResultsRichText.AppendText(Environment.NewLine);

                foreach(DosageField df in totalPattern.Patterns)
                {
                    ResultsRichText.AppendText(string.Format("For Dosage {0} mg.min/m^3{1}", df.Threshold, Environment.NewLine));
                    ResultsRichText.AppendText(string.Format("Maximum Downwind Distance is {0:0.00} meters{1}", df.MaxDownwindDistance, Environment.NewLine));
                    ResultsRichText.AppendText(string.Format("Maximum Crosswind Distance is {0:0.00} meters{1}", df.MaxCrosswindDistance, Environment.NewLine));
                    ResultsRichText.AppendText(string.Format("Area Coverage is {0:0.00} square meters{1}", df.AreaCovergeSquareMeters, Environment.NewLine));
                    ResultsRichText.AppendText(Environment.NewLine);
                }
            }
            else
            {
                ResultsRichText.Clear();

                ResultsRichText.AppendText("LCT50 must be greater than ICT50. ICT50 must be greater than Threshold.");
                ResultsRichText.AppendText(Environment.NewLine);
                ResultsRichText.AppendText("Threshold, Windspeed, and Fill Weight must all be greater than zero.");
                ResultsRichText.AppendText(Environment.NewLine);
                ResultsRichText.AppendText("Please adjust your input parameters and try again.");
            }
        }

        // This utility method assigns the value of a ToolStripItem
        // control's Text property to the Text property of the
        // ToolStripStatusLabel.
        private void UpdateStatus(ToolStripItem item)
        {
            if (item != null)
            {
                string msg = String.Format("{0} selected", item.Text);
                this.statusStrip1.Items[0].Text = msg;

                if(item.Name == "newToolStripMenuItem")
                {
                    ClearButton_Click(null,null);
                }
                else if (item.Name == "exitToolStripMenuItem")
                {
                    // check save status then
                    Application.Exit();
                }
            }
        }

        // This method is the DropDownItemClicked event handler.
        // It passes the ClickedItem object to a utility method
        // called UpdateStatus, which updates the text displayed
        // in the StatusStrip control.
        private void fileToolStripMenuItem_DropDownItemClicked(
            object sender, ToolStripItemClickedEventArgs e)
        {
            this.UpdateStatus(e.ClickedItem);
        }

        private void OpenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
                    DataContractSerializer ser = new DataContractSerializer(typeof(ChemHazardViewModel));

                    // Deserialize the data and read it from the instance.
                    ChemHazardViewModel diskVM =
                        (ChemHazardViewModel)ser.ReadObject(reader, true);
                    reader.Close();

                    fileStream.Close();

                    // update the View Model with the values from disk.
                    // We do it this way to trigger property change notifications
                    // so the UI is updated with the values.
                    vm.AgentName = diskVM.AgentName;
                    vm.WeaponName = diskVM.WeaponName;
                    vm.ICT50Dosage = diskVM.ICT50Dosage;
                    vm.LCT50Dosage = diskVM.LCT50Dosage;
                    vm.ThresholdDosage = diskVM.ThresholdDosage;
                    vm.Qkg = diskVM.Qkg;
                    vm.UKts = diskVM.UKts;
                    vm.Tst = diskVM.Tst;
                    vm.Psc = diskVM.Psc;
                    vm.CalculatedPattern = diskVM.CalculatedPattern;
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Stream myStream;
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        DataContractSerializer ser =
                            new DataContractSerializer(typeof(ChemHazardViewModel));
                        ser.WriteObject(myStream, vm);

                        // Code to write the stream goes here.
                        myStream.Close();
                    }
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Stream myStream;
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        DataContractSerializer ser =
                            new DataContractSerializer(typeof(ChemHazardViewModel));
                        ser.WriteObject(myStream, vm);

                        // Code to write the stream goes here.
                        myStream.Close();
                    }
                }
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show(this);
            if(a.DialogResult == DialogResult.OK)
                a.Dispose();
        }
    }
}
