#region header

// MouseJiggler - AboutBox.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/22 2:24 PM.
// Updates by: Dimitris Panokostas (midwan)

#endregion

#region using

using System;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace ArkaneSystems.MouseJiggler;

public sealed partial class AboutBox : Form
{
    public AboutBox()
    {
        InitializeComponent();

        // Initialize the about box to display the product information from the assembly information.
        Text = $"About {AssemblyTitle}";
        lbProductName.Text = AssemblyProduct;
        lbVersion.Text = $"Version {AssemblyVersion}";
        lbCopyright.Text = AssemblyCopyright;
        lbCompanyName.Text = AssemblyCompany;
        tbDescription.Text = AssemblyDescription;
    }

    private void cmdOk_Click(object sender, EventArgs e)
    {
        Close();
    }

    #region Assembly attribute accessors

    private static string AssemblyTitle
    {
        get
        {
            // Get all Title attributes on this assembly
            object[] attributes =
                Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            // If there is at least one Title attribute
            if (attributes.Length > 0)
            {
                // Select the first one
                var titleAttribute = (AssemblyTitleAttribute)attributes[0];

                // If it is not an empty string, return it
                if (titleAttribute.Title != "")
                    return titleAttribute.Title;
            }

            // If there was no Title attribute, or if the Title attribute was the empty string, return the assembly name
            return Assembly.GetExecutingAssembly().GetName()!.Name ?? "<unknown>";
        }
    }

    private static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version!.ToString();

    private static string AssemblyDescription
    {
        get
        {
            // Get all Description attributes on this assembly
            object[] attributes =
                Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

            return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
    }

    private static string AssemblyProduct
    {
        get
        {
            // Get all Product attributes on this assembly
            object[] attributes =
                Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);

            return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
        }
    }

    private static string AssemblyCopyright
    {
        get
        {
            // Get all Copyright attributes on this assembly
            object[] attributes =
                Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

            return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }

    private static string AssemblyCompany
    {
        get
        {
            // Get all Company attributes on this assembly
            object[] attributes =
                Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

            return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }

    #endregion Assembly attribute accessors
}