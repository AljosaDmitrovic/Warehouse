﻿using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class LocationCard : Form
    {
        private LocationRepositoryBus locationRepository = new LocationRepositoryBus();
        public LocationCard()
        {
            InitializeComponent();
        }

        public void SetParameters(Boolean New, Location location)
        {
            switch (New)
            {
                case true:
                    labelInsert.Visible = true;
                    buttonInsert.Visible = true;
                    break;
                case false:
                    labelUpdate.Visible = true;
                    buttonUpdate.Visible = true;
                    textBoxId.Text = Convert.ToString(location.Id);
                    textBoxName.Text = location.Name;
                    textBoxAddress.Text = location.Adress;
                    textBoxCountry.Text = location.Country;
                    break;
                default:
                    break;
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxAddress.Text) || string.IsNullOrEmpty(textBoxCountry.Text))
            {

                MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Location location = new Location();
                    location.Name = textBoxName.Text;
                    location.Adress = textBoxAddress.Text;
                    location.Country = textBoxCountry.Text;
                    locationRepository.InsertLocation(location);

                    AutoClosingMessageBox.Show("You have successfully inserted your Location!", "Congratulations!", 1700);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxAddress.Text) || string.IsNullOrEmpty(textBoxCountry.Text))
            {
                MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    Location location = new Location();
                    location.Id = Convert.ToInt32(textBoxId.Text);

                    location.Name = textBoxName.Text;
                    location.Adress = textBoxAddress.Text;
                    location.Country = textBoxCountry.Text;
                    locationRepository.UpdateLocation(location);

                    AutoClosingMessageBox.Show("You have successfully updated your Location!", "Congratulations!", 1700);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /* KLASA AUTO-CLOSING MSGBOX */
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }


        /*---IS ALL LETTERS---*/
        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        /*---IS ALL DIGITS---*/
        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /*---IS ALL LETTERS OR DIGITS---*/

        public static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }

        /*---ONLY LETTERS, DIGITS, UNDERSCORES---*/
        public static bool IsAllLettersOrDigitsOrUnderscores(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c) && c != '_')
                    return false;
            }
            return true;
        }

        private void LocationCard_Activated(object sender, EventArgs e)
        {
            textBoxName.Focus();
        }
    }
}
