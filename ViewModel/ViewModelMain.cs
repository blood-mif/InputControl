using InputControl_9B925.Analyse;
using InputControl_9B925.Properties;
using InputControl_9B925.Report;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using PpdControls.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InputControl_9B925.ViewModel
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public CommandAnalyseCalibration CmdAnCal { get; set; }
        // public CommandSaveFile CmdSaveFile { get; set; }

        public ViewModelMain()
        {
            // CmdAnCal = new CommandAnalyseCalibration(); 
            // CmdSaveFile = new CommandSaveFile(); 
            VMErrCal51 = new ViewModelErrorsCalibration();
            VMErrCal61 = new ViewModelErrorsCalibration();

            VMErrCal61_0 = new ViewModelErrorsCalibration();
            VMErrCal61_1 = new ViewModelErrorsCalibration();
            VMErrCal61_2 = new ViewModelErrorsCalibration();
            VMErrCal61_3 = new ViewModelErrorsCalibration();
            VMErrCal61_4 = new ViewModelErrorsCalibration();
            VMErrCal61_5 = new ViewModelErrorsCalibration();
            
            WMReglament = new ViewModelReglament();
            WMsettMT1 = new ViewModelSettingMeasurementType();
            WMsettMT2 = new ViewModelSettingMeasurementType();
            WMsettMT3 = new ViewModelSettingMeasurementType();
            WMsettMT4 = new ViewModelSettingMeasurementType();
            VMStatusSR = new ViewModelStatusStopReg();
            VMPassportConst = new ViewModelPassportConst();



            EventChangeVisibleFlag += ChangeVisibleFlag;
            AnCal51.EventFinishAnalyse += VMErrCal51.GetData;
            AnCal61.EventFinishAnalyse += VMErrCal61.GetData;

            AnCal61_0.EventFinishAnalyse += VMErrCal61_0.GetData;
            AnCal61_1.EventFinishAnalyse += VMErrCal61_1.GetData;
            AnCal61_2.EventFinishAnalyse += VMErrCal61_2.GetData;
            AnCal61_3.EventFinishAnalyse += VMErrCal61_3.GetData;
            AnCal61_4.EventFinishAnalyse += VMErrCal61_4.GetData;
            AnCal61_5.EventFinishAnalyse += VMErrCal61_5.GetData;

            AnCalReglament.EventFinishAnalyse += WMReglament.GetDataReglament;
            AnCalStatusSR.EventFinishAnalyse += VMStatusSR.GetStatusStopReg;

            AnCalSMT1.EventFinishAnalyse += WMsettMT1.GetDataSettingTypeInfo1;
            AnCalSMT2.EventFinishAnalyse += WMsettMT2.GetDataSettingTypeInfo2;
            AnCalSMT3.EventFinishAnalyse += WMsettMT3.GetDataSettingTypeInfo3;
            AnCalSMT4.EventFinishAnalyse += WMsettMT4.GetDataSettingTypeInfo4;

            AnCalPassportConst.EventFinishAnalyse += VMPassportConst.GetDataPassportConst;

            CMDStartAbalyse = new ClassCommand(OpenForStartAnalyse);
            CMDSaveReport = new ClassCommand(SaveReport);
            CMDWindowInfo = new ClassCommand(OpenWindowInfo);
        }

        public ViewModelErrorsCalibration VMErrCal51 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61 { get; set; }
        
        public ViewModelErrorsCalibration VMErrCal61_0 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_1 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_2 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_3 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_4 { get; set; }
        public ViewModelErrorsCalibration VMErrCal61_5 { get; set; }

        public ViewModelSettingMeasurementType WMsettMT1 { get; set; }
        public ViewModelSettingMeasurementType WMsettMT2 { get; set; }
        public ViewModelSettingMeasurementType WMsettMT3 { get; set; }
        public ViewModelSettingMeasurementType WMsettMT4 { get; set; }
        public ViewModelReglament WMReglament { get; set; }
        public ViewModelStatusStopReg VMStatusSR { get; set; }
        public ViewModelPassportConst VMPassportConst { get; set; }

        public BaseAnalyse AnCal51 = new BaseAnalyse();
        public BaseAnalyse AnCal61 = new BaseAnalyse();

        public BaseAnalyse AnCal61_0 = new BaseAnalyse();
        public BaseAnalyse AnCal61_1 = new BaseAnalyse();
        public BaseAnalyse AnCal61_2 = new BaseAnalyse();
        public BaseAnalyse AnCal61_3 = new BaseAnalyse();
        public BaseAnalyse AnCal61_4 = new BaseAnalyse();
        public BaseAnalyse AnCal61_5 = new BaseAnalyse();

        public BaseAnalyse AnCalReglament = new BaseAnalyse();
        public BaseAnalyse AnCalSMT1 = new BaseAnalyse();
        public BaseAnalyse AnCalSMT2 = new BaseAnalyse();
        public BaseAnalyse AnCalSMT3 = new BaseAnalyse();
        public BaseAnalyse AnCalSMT4 = new BaseAnalyse();
        public BaseAnalyse AnCalStatusSR = new BaseAnalyse();
        public BaseAnalyse AnCalPassportConst = new BaseAnalyse();
        public string path;


        public ClassCommand CMDSaveReport { get; set; }
        public ClassCommand CMDStartAbalyse { get; set; }
        public ClassCommand CMDWindowInfo { get; set; }


        public VMReportImputControl VMReport { get; set; }
        private string pathToSaveFileDefault = Directory.GetCurrentDirectory() + "\\reportFile.xps";


        public void OpenWindowInfo(object o)
        {
            WindowInfo wi = new WindowInfo();
            wi.ShowDialog();
        }

        public EventHandler EventChangeVisibleFlag;
        public void OpenForStartAnalyse(object o)
        {
            VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
            if (vistaFolderBrowserDialog.ShowDialog() == false)
                return;
            path = vistaFolderBrowserDialog.SelectedPath;
            AnCal51.StartAnalyse(path + "\\Работа ИИБ в режиме Г1");
            AnCal61.StartAnalyse(path + "\\Работа ИИБ в режиме Г3");

            AnCal61_0.StartAnalyse(path + "\\Работа ИИБ в режиме Г3\\Г3_0");
            AnCal61_1.StartAnalyse(path + "\\Работа ИИБ в режиме Г3\\Г3_1");
            AnCal61_2.StartAnalyse(path + "\\Работа ИИБ в режиме Г3\\Г3_2");
            AnCal61_3.StartAnalyse(path + "\\Работа ИИБ в режиме Г3\\Г3_3");
            AnCal61_4.StartAnalyse(path + "\\Работа ИИБ в режиме Г3\\Г3_4");
            AnCal61_5.StartAnalyse(path + "\\Работа ИИБ в режиме Г3\\Г3_5");
            
            AnCalReglament.StartAnalyse(path + "\\Работа ИИБ в режиме Регламент");
            //AnCalStatusSR.StartAnalyse(path + "\\Прекращение режима");
            //AnCalSMT1.StartAnalyse(path + "\\Установка типа измерений\\Тип 1");
            //AnCalSMT2.StartAnalyse(path + "\\Установка типа измерений\\Тип 2");
            //AnCalSMT3.StartAnalyse(path + "\\Установка типа измерений\\Тип 3");
            //AnCalSMT4.StartAnalyse(path + "\\Установка типа измерений\\Тип 4");

           // AnCalPassportConst.StartAnalysePassportConst(path + "\\Паспортные константы");
            EventChangeVisibleFlag?.Invoke(path, null);
        }

        public void SaveReport(object o)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == false)
            {
                MessageBoxResult mbr = MessageBox.Show("Вы уверены что не хотите сохранять файл?", "", MessageBoxButton.YesNo);
                if (mbr == MessageBoxResult.Yes)
                    return;
                SaveReport(o);
            }
            if (saveFileDialog.FileName != "")
            {
                if (saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length - 4) == ".xps")
                    File.Copy(pathToSaveFileDefault, saveFileDialog.FileName, true);
                else
                    File.Copy(pathToSaveFileDefault, saveFileDialog.FileName + ".xps", true);
                MessageBox.Show("Файл сохранён");
            }
        }

        public void ChangeVisibleFlag(object o, EventArgs e)
        {
            pathFolder = o.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PathFolder"));
            flagVisibleTabControl = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FlagVisibleTabControl"));

            List<string> lstHeader = new List<string>();
            lstHeader.Add(ProductType);
            lstHeader.Add(ProductNumber);
            lstHeader.Add(nowData);
            lstHeader.Add(OperatorFIO);

            ReportModel repMod = new ReportModel()
            {
                VMErrCal51 = this.VMErrCal51,
                VMErrCal61 = this.VMErrCal61,

                VMErrCal61_0 = this.VMErrCal61_0,
                VMErrCal61_1 = this.VMErrCal61_1,
                VMErrCal61_2 = this.VMErrCal61_2,
                VMErrCal61_3 = this.VMErrCal61_3,
                VMErrCal61_4 = this.VMErrCal61_4,
                VMErrCal61_5 = this.VMErrCal61_5,

                VMPassportConst = this.VMPassportConst,
                WMReglament = this.WMReglament,
                //VMStatusSR = this.VMStatusSR,
                //WMsettMT1 = this.WMsettMT1,
                //WMsettMT2 = this.WMsettMT2,
                //WMsettMT3 = this.WMsettMT3,
                //WMsettMT4 = this.WMsettMT4,
                LstHeader = lstHeader
            };
            VMReport = new VMReportImputControl(repMod);
        }

        private string operatorFIO = "";
        public string OperatorFIO
        {
            get { return operatorFIO; }
            set
            {
                operatorFIO = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OperatorFIO"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FlagEnableButton"));
            }
        }

        private string productType = "9Б925";
        public string ProductType
        {
            get { return productType; }
            set
            {
                productType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FlagEnableButton"));
            }
        }

        private string productNumber = "";
        public string ProductNumber
        {
            get { return productNumber; }
            set
            {
                productNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductNumber"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FlagEnableButton"));
            }
        }

        private bool flagEnableButton = false;
        public bool FlagEnableButton
        {
            get
            {
                if (ProductNumber != "" && OperatorFIO != "")
                    return true;

                return false;
            }
            set
            {
                flagEnableButton = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FlagEnableButton"));
            }
        }
        //private string pathToSaveFileDefault = Directory.GetCurrentDirectory() + "\\dateFile.mki";

        private string pathFolder;
        public string PathFolder
        {
            get
            {
                Settings.Default.PathFolder = pathFolder;
                Settings.Default.Save();
                return pathFolder;
            }
            set
            {
                pathFolder = value;
                Settings.Default.PathFolder = value;
                Settings.Default.Save();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PathFolder"));
            }
        }

        private double breadth;
        public double Breadth
        {
            get { return breadth; }
            set
            {
                breadth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Breadth"));
            }
        }

        private string nowData = DateTime.Now.ToString("dd.MM.yyyy");
        public string NowData
        {
            get { return nowData; }
            set { nowData = value; }
        }

        private bool flagVisibleTabControl = false;
        public bool FlagVisibleTabControl
        {
            get { return flagVisibleTabControl; }
            set
            {
                flagVisibleTabControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FlagVisibleTabControl"));
            }
        }
    }
}
