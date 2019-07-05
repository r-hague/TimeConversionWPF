using System;
using System.Collections.Generic;
using System.Text;

namespace TimeCalculator
{
    class TimeValidatorAndCalculator
    {
        public string strExceptionInformation, strSecondsValues = "";
        private Int64 int64SecondsValue;
        private int intSecsInDay = 86400, intSecsInHour = 3600, intSecsInMin = 60;
        public string strSecondsValue
        {
            get { return strSecondsValues; }

            set
            {
                strSecondsValues = value;
            }
        }
        public bool CheckValidSeconds()
        {
            Int64 int64Seconds;
            bool boolSecInInt = Int64.TryParse(strSecondsValue, out int64Seconds);
            if (!boolSecInInt || int64Seconds < 0)
            {
                return false;
            }
            else
            {
                int64SecondsValue = int64Seconds;
                return true;
            }
        }
        public bool GetTimePartsOfSecondsValue(ref Int64 int64DayPartOfSec, ref Int64 int64HourPartOfSec, ref Int64 int64MinPartOfTime, ref Int64 int64SecPartOfTime)
        {
            try
            {
                ///calculate days
                if (int64SecondsValue >= intSecsInDay)
                {
                    int64DayPartOfSec = int64SecondsValue / intSecsInDay;
                    int64SecondsValue = int64SecondsValue % intSecsInDay;
                }
                ///calculate hours
                if (int64SecondsValue >= intSecsInHour)
                {
                    int64HourPartOfSec = int64SecondsValue / intSecsInHour;
                    int64SecondsValue = int64SecondsValue % intSecsInHour;
                }
                ///calculate min
                if (int64SecondsValue >= intSecsInMin)
                {
                    int64MinPartOfTime = int64SecondsValue / intSecsInMin;
                    int64SecondsValue = int64SecondsValue % intSecsInMin;
                }
                //Assign remaining seconds to the returning variable
                int64SecPartOfTime = int64SecondsValue;
                return true;
            }
            catch (Exception ex)
            {
                strExceptionInformation = ex.ToString();
                return false;
            }
        }
    }
}