//using InputControl_9B925.Analyse;
//using InputControl_9B925.UserControls;
//using InputControl_9B925.ViewModel;
//using Microsoft.Win32;
//using Ookii.Dialogs.Wpf;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Windows.Input;

//namespace InputControl_9B925.Commands
//{
//    public class CommandAnalyseCalibration : ICommand
//    {

//        public event EventHandler CanExecuteChanged;
//       // public BaseAnalyse BaseAnCal = new BaseAnalyse();
//        public BaseAnalyse AnCal51 = new BaseAnalyse();
//        public BaseAnalyse AnCal61 = new BaseAnalyse();
//        public BaseAnalyse AnCalReglament = new BaseAnalyse();
//        public BaseAnalyse AnCalSMT1 = new BaseAnalyse();
//        public BaseAnalyse AnCalSMT2 = new BaseAnalyse();
//        public BaseAnalyse AnCalSMT3 = new BaseAnalyse();
//        public BaseAnalyse AnCalSMT4 = new BaseAnalyse();
//        public BaseAnalyse AnCalStatusSR = new BaseAnalyse();
//        public BaseAnalyse AnCalPassportConst = new BaseAnalyse();
//        public string path;

//        public bool CanExecute(object parameter)
//        {
//            //if (true)
//            //{
//            //    return false;
//            //}
            
//                return true;
//        }
//        public EventHandler EventChangeVisibleFlag;

//        public void Execute(object parameter)
//        {
//           // ViewModelMain vmm = new ViewModelMain();

//            VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog(); 
//            if (vistaFolderBrowserDialog.ShowDialog() == false)
//                return;
//            path = vistaFolderBrowserDialog.SelectedPath;
//            AnCal51.StartAnalyse(path + "\\Режим Г1");
//            AnCal61.StartAnalyse(path + "\\Режим Г3");
//            AnCalReglament.StartAnalyse(path + "\\Регламент");
//            AnCalStatusSR.StartAnalyse(path + "\\Прекращение режима");

//            AnCalSMT1.StartAnalyse(path + "\\Установка типа измерений\\Тип 1");
//            AnCalSMT2.StartAnalyse(path + "\\Установка типа измерений\\Тип 2");
//            AnCalSMT3.StartAnalyse(path + "\\Установка типа измерений\\Тип 3");
//            AnCalSMT4.StartAnalyse(path + "\\Установка типа измерений\\Тип 4");

//            AnCalPassportConst.StartAnalysePassportConst(path + "\\Чтение паспортных констант");
//            EventChangeVisibleFlag?.Invoke(path, null);


//        }

//    }
//}
