using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * Program takes input integer and converts seconds to minutes, hours, and days as appropriate.
 * Will convert to minutes under one hour, hours under one day, and days over one day.
 * Pairs with proper units and handles input errors.
 * */
 
namespace Exercise4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            //hide error message if visible from prior run
            errorMessage.Visible = false;

            //check if blank
            if (!String.IsNullOrWhiteSpace(secondsBox.Text))
            {
                int seconds = 0;
                //check if the input is an integer
                if (int.TryParse(secondsBox.Text, out seconds) == true)
                {
                    double time = 0;
                    String unit = "";

                    //convert to minutes
                    if (seconds >= 60 && seconds < 3600)
                    {
                        time = (int)seconds / 60;
                        if (time < 2)
                            unit = " minute";
                        else
                            unit = " minutes";
                    }
                    //convert to hours
                    else if (seconds >= 3600 && seconds < 86400)
                    {
                        time = (int)seconds / 3600;
                        if (time < 2)
                            unit = " hour";
                        else
                            unit = " hours";
                    }
                    //convert to days
                    else if (seconds >= 86400)
                    {
                        time = (int)seconds / 86400;
                        if (time < 2)
                            unit = " day";
                        else
                            unit = " days";
                    }
                    //just output as seconds
                    else
                    {
                        time = seconds;
                        unit = " seconds";
                    }

                    //reveal the answer text, set to string to tell how many seconds in the unit
                    answerText.Visible = true;
                    answerText.Text = time.ToString() + unit + " in " + seconds + " seconds";
                }
                //output an error if not an integer
                else
                {
                    answerText.Visible = false;
                    errorMessage.Visible = true;
                }
            }
        }
    }
}
