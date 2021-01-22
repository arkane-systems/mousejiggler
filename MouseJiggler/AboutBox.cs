#region header

// MouseJiggler - AboutBox.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/22 2:24 PM.

#endregion

#region using

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace ArkaneSystems.MouseJiggler
{
    public partial class AboutBox : Form
    {
        public AboutBox ()
        {
            this.InitializeComponent ();

            // Initialize the about box to display the product information from the assembly information.
            this.Text               = $"About {this.AssemblyTitle}";
            this.lbProductName.Text = this.AssemblyProduct;
            this.lbVersion.Text     = $"Version {this.AssemblyVersion}";
            this.lbCopyright.Text   = this.AssemblyCopyright;
            this.lbCompanyName.Text = this.AssemblyCompany;
            this.tbDescription.Text = this.AssemblyDescription;
        }

        private void cmdOk_Click (object sender, EventArgs e)
        {
            this.Close ();
        }

        #region Assembly attribute accessors

        private string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly ()
                            .GetCustomAttributes (attributeType: typeof (AssemblyTitleAttribute), inherit: false);

                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];

                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }

                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return Path.GetFileNameWithoutExtension (path: Assembly.GetExecutingAssembly ().Location);
            }
        }

        private string AssemblyVersion => Assembly.GetExecutingAssembly ().GetName ().Version!.ToString ();

        private string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly ()
                            .GetCustomAttributes (attributeType: typeof (AssemblyDescriptionAttribute), inherit: false);

                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        private string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly ()
                            .GetCustomAttributes (attributeType: typeof (AssemblyProductAttribute), inherit: false);

                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        private string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly ()
                            .GetCustomAttributes (attributeType: typeof (AssemblyCopyrightAttribute), inherit: false);

                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        private string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly ()
                            .GetCustomAttributes (attributeType: typeof (AssemblyCompanyAttribute), inherit: false);

                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        #endregion Assembly attribute accessors
    }
}
