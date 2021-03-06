﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;
using Util;

namespace PLWPF.GuestRequestWindows
{
    /// <summary>
    /// Interaction logic for GuestRequestWindow.xaml
    /// </summary>
    public partial class GuestRequestWindow : Window
    {

        public GuestRequest guestRequest { get; set; }  = new GuestRequest();

        public List<ValidationError> _errors = new List<ValidationError>();

        public GuestRequestWindow(Mode mode, [Optional] GuestRequest GuestRequest)
        {
            
            guestRequest = GuestRequest ?? guestRequest;

            InitializeComponent();

            

            if(guestRequest.Id != 0)
            {
                IdBox.IsEnabled = false;
            }

            setDataInEnums();

            if (mode == Mode.Add)
                Add();

            if (mode == Mode.Update)
                Update();

            this.DataContext = guestRequest;

        }

        public void Add() {

            addBtn.Visibility = Visibility.Visible;

            guestRequest.EntryDate = DateTime.Now.Date;
            guestRequest.ReleaseDate = DateTime.Now.AddDays(1).Date;

        }

        public void Update() {

            for (var i = 0; i < areaBox.Items.Count; i++)
            {
                if ((VecationAreas)areaBox.Items[i] == guestRequest.Area)
                {
                    areaBox.SelectedIndex = i;
                }
            }

            for (var i = 0; i < typeBox.Items.Count; i++)
            {
                if ((HostingUnitTypes)typeBox.Items[i] == guestRequest.Type)
                {
                    typeBox.SelectedIndex = i;
                }
            }

            for (var i = 0; i < poolBox.Items.Count; i++)
            {
                if ((Additions)poolBox.Items[i] == guestRequest.Pool)
                {
                    poolBox.SelectedIndex = i;
                }
            }

            for (var i = 0; i < jzziBox.Items.Count; i++)
            {
                if ((Additions)jzziBox.Items[i] == guestRequest.Jacuzzi)
                {
                    jzziBox.SelectedIndex = i;
                }
            }

            for (var i = 0; i < gardBox.Items.Count; i++)
            {
                if ((Additions)gardBox.Items[i] == guestRequest.Garden)
                {
                    gardBox.SelectedIndex = i;
                }
            }

            for (var i = 0; i < chilAttrBox.Items.Count; i++)
            {
                if ((Additions)chilAttrBox.Items[i] == guestRequest.ChildrensAttractions)
                {
                    chilAttrBox.SelectedIndex = i;
                }
            }


            updateBtn.Visibility = Visibility.Visible;
           // findBtn.Visibility = Visibility.Visible;
            delBtn.Visibility = Visibility.Visible;

        }

        private void setDataInEnums()
        {

            areaBox.ItemsSource = Enum.GetValues(typeof(VecationAreas));
            areaBox.SelectedIndex = 0;
            typeBox.ItemsSource = Enum.GetValues(typeof(HostingUnitTypes));
            typeBox.SelectedIndex = 0;
            poolBox.ItemsSource = Enum.GetValues(typeof(Additions));
            poolBox.SelectedIndex = 0;
            jzziBox.ItemsSource = Enum.GetValues(typeof(Additions));
            jzziBox.SelectedIndex = 0;
            gardBox.ItemsSource = Enum.GetValues(typeof(Additions));
            gardBox.SelectedIndex = 0;
            chilAttrBox.ItemsSource = Enum.GetValues(typeof(Additions));
            chilAttrBox.SelectedIndex = 0;

        }

        public void getDataFromEnums() {

            guestRequest.Area = (VecationAreas)areaBox.SelectedItem;
            guestRequest.Type = (HostingUnitTypes)typeBox.SelectedItem;
            guestRequest.Pool = (Additions)poolBox.SelectedItem;
            guestRequest.Jacuzzi = (Additions)jzziBox.SelectedItem;
            guestRequest.Garden = (Additions)gardBox.SelectedItem;
            guestRequest.ChildrensAttractions = (Additions)chilAttrBox.SelectedItem;

        }

        public bool ValidateBeforeAddOrUpdate() {

            if (guestRequest.Id == 0) {
                MessageBox.Show("יש להזין מספר זהות");
                return false;
            }

            if (string.IsNullOrEmpty(guestRequest.PrivateName))
            {
                MessageBox.Show("יש להזין שם");
                return false;
            }

            if (string.IsNullOrEmpty(guestRequest.MailAddress))
            {
                MessageBox.Show("יש להזין כתובת מייל");
                return false;
            }

            if (guestRequest.Adults < 1 )
            {
                MessageBox.Show("יש לציין מבוגר אחד לפחות");
                return false;
            }

            return true;

        }

        #region events

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateBeforeAddOrUpdate() == false)
                    return;

                getDataFromEnums();

                DialogResult = BL_Singletone.Instance.AddGuestRequest(guestRequest);

                Close();

            }
            catch (LogicException ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("general error");
            }

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateBeforeAddOrUpdate() == false)
                    return;

                getDataFromEnums();

                DialogResult = BL_Singletone.Instance.UpdateGuestRequest(guestRequest);

                Close();

            }
            catch (LogicException ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("general error");
            }

        }

        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var grList = BL_Singletone.Instance.GetGuestRequestsById(guestRequest.Id);

                if (grList.Count() == 0)
                {
                    MessageBox.Show("No Items Found", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                GuestRequestGrid guestRequestGrid = new GuestRequestGrid(grList);
                guestRequestGrid.ShowDialog();

                if (guestRequestGrid.DialogResult == true)
                {
                    updateBtn.IsEnabled = true;

                    guestRequest = guestRequestGrid.selectedGR;

                    for (var i = 0; i < areaBox.Items.Count; i++)
                    {
                        if ((VecationAreas)areaBox.Items[i] == guestRequest.Area)
                        {
                            areaBox.SelectedIndex = i;
                        }
                    }

                    for (var i = 0; i < typeBox.Items.Count; i++)
                    {
                        if ((HostingUnitTypes)typeBox.Items[i] == guestRequest.Type)
                        {
                            typeBox.SelectedIndex = i;
                        }
                    }

                    for (var i = 0; i < poolBox.Items.Count; i++)
                    {
                        if ((Additions)poolBox.Items[i] == guestRequest.Pool)
                        {
                            poolBox.SelectedIndex = i;
                        }
                    }

                    for (var i = 0; i < jzziBox.Items.Count; i++)
                    {
                        if ((Additions)jzziBox.Items[i] == guestRequest.Jacuzzi)
                        {
                            jzziBox.SelectedIndex = i;
                        }
                    }

                    for (var i = 0; i < gardBox.Items.Count; i++)
                    {
                        if ((Additions)gardBox.Items[i] == guestRequest.Garden)
                        {
                            gardBox.SelectedIndex = i;
                        }
                    }

                    for (var i = 0; i < chilAttrBox.Items.Count; i++)
                    {
                        if ((Additions)chilAttrBox.Items[i] == guestRequest.ChildrensAttractions)
                        {
                            chilAttrBox.SelectedIndex = i;
                        }
                    }

                    this.DataContext = guestRequest;


                }


            }
            catch (LogicException ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("general error");
            }
        }

        private void Validation_OnError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors.Add(e.Error);
            else
                _errors.Remove(e.Error);

            addBtn.IsEnabled = updateBtn.IsEnabled = !_errors.Any();

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (guestRequest.GuestRequestKey == 0)
                return;

            try
            {
                BL_Singletone.Instance.DeleteGuestRequestsByKey(guestRequest.GuestRequestKey);

                MessageBox.Show("guest request successfully deleted.");

                Close();
            }
            catch (LogicException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("general error");
            }      
     
        }

        #endregion
    }
}
