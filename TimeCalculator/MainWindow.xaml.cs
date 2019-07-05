using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeValidatorAndCalculator objTimeValidate = new TimeValidatorAndCalculator();
        Label[] lblTimes = new Label[8];

        public MainWindow()
        {
            InitializeComponent();
            ///assign label displaying time parts in a label array
            lblTimes[0] = lblDaysLabel;
            lblTimes[1] = lblHoursLabel;
            lblTimes[2] = lblMinsLabel;
            lblTimes[3] = lblSecsLabel;
            lblTimes[4] = lblCalculatedDays;
            lblTimes[5] = lblCalculatedHours;
            lblTimes[6] = lblCalculatedMins;
            lblTimes[7] = lblCalculatedSecs;
            DataContext = objTimeValidate;
        }

        private void btnCalculateTime_Click(object sender, RoutedEventArgs e)
        {
            //clear previous calculated value of time parts
            this.ClearTimePartsFields();

            //check if entered seconds contains invalid seconds format
            bool boolCheckValidSeconds = objTimeValidate.CheckValidSeconds();
            if (boolCheckValidSeconds)
            {
                Int64 int64DayPartOfSec = 0, int64HourPartOfSec = 0, int64MinPartOfTime = 0, int64SecPartOfTime = 0;
                bool boolTimePartsCalculated = objTimeValidate.GetTimePartsOfSecondsValue(ref int64DayPartOfSec, ref int64HourPartOfSec, ref int64MinPartOfTime, ref int64SecPartOfTime);
                if (boolTimePartsCalculated == true)
                {
                    //show calculated time parts and hide invalid seconds message
                    this.HideDisplayedTimeValueLables(false);
                    lblCalculatedDays.Content = int64DayPartOfSec;
                    lblCalculatedHours.Content = int64HourPartOfSec;
                    lblCalculatedMins.Content = int64MinPartOfTime;
                    lblCalculatedSecs.Content = int64SecPartOfTime;
                }
                else
                {
                    MessageBox.Show("Unable to convert due to below error\n" + objTimeValidate.strExceptionInformation, "Conversion failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
            }
            else
            {
                //hide calculated time parts and show invalid seconds message
                this.HideDisplayedTimeValueLables(true);
            }
        }

        private void HideDisplayedTimeValueLables(bool boolHideShowTimeValueLables)
        {
            if (boolHideShowTimeValueLables)
            {
                lblInvalidSecondsFormat.Visibility = Visibility.Visible;
                foreach (Label lblTimeParts in lblTimes)
                {
                    lblTimeParts.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                lblInvalidSecondsFormat.Visibility = Visibility.Hidden;
                foreach (Label lblTimeParts in lblTimes)
                {
                    lblTimeParts.Visibility = Visibility.Visible;
                }
            }
        }

        private void ClearTimePartsFields()
        {
            lblCalculatedDays.Content = string.Empty;
            lblCalculatedHours.Content = string.Empty;
            lblCalculatedMins.Content = string.Empty;
            lblCalculatedSecs.Content = string.Empty;
        }
    }
}