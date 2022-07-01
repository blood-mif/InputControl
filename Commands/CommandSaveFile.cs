//using Microsoft.Win32;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Input;

//namespace InputControl_9B925.Commands
//{
//    public class CommandSaveFile : ICommand
//    {
//        public event EventHandler CanExecuteChanged;

//        public bool CanExecute(object parameter)
//        {
//            return true;
//        }

//        public void Execute(object parameter)
//        {
//            SaveFile();
//        }
//        public void SaveFile()
//        {
//            SaveFileDialog saveFileDialog = new SaveFileDialog();
//            if (saveFileDialog.ShowDialog() == false)
//            {
//                MessageBoxResult mbr = MessageBox.Show("Вы уверены что не хотите сохранять файл?", "", MessageBoxButton.YesNo);
//                if (mbr == MessageBoxResult.Yes)
//                {
//                    return;
//                }
//                SaveFile();
//            }
//            if (saveFileDialog.FileName != "")
//            {
//                if (saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length - 4) == ".xps")
//                    File.Copy(pathToSaveFileDefault, saveFileDialog.FileName,true);
//                else
//                File.Copy(pathToSaveFileDefault, saveFileDialog.FileName + ".xps", true);
//                MessageBox.Show("Файл сохранён");
//            }
            
//        }
//        private string pathToSaveFileDefault = Directory.GetCurrentDirectory() + "\\reportFile.xps";
//    }
//}
