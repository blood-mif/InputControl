using InputControl_9B925.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputControl_9B925.Report
{
    public class ReportModel
    {
        public ViewModelErrorsCalibration VMErrCal51 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_0 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_1 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_2 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_3 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_4 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_5 { get; set; }
        //public ViewModelSettingMeasurementType WMsettMT1 { get; set; }
        //public ViewModelSettingMeasurementType WMsettMT2 { get; set; }
        //public ViewModelSettingMeasurementType WMsettMT3 { get; set; }
        //public ViewModelSettingMeasurementType WMsettMT4 { get; set; }
        //public ViewModelStatusStopReg VMStatusSR { get; set; }
        public ViewModelReglament WMReglament { get; set; }
        public ViewModelPassportConst VMPassportConst { get; set; }
        public List<string> LstHeader { get; set; }

    }
}
