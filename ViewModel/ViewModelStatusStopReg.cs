using InputControl_9B925.Model;
using L_412_StrData.Regims.iibrkRegims.Answers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputControl_9B925.ViewModel
{
    public class ViewModelStatusStopReg : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void GetStatusStopReg(object o, EventArgs e)
        {
            SendPuckP1 spP1 = ((SendPuckP1)o);
            var reg8A = (RegRk8A)(spP1.Reg8A);

            if (reg8A.Status == 0)
                StatusStopReg = "\u2714";
            else
                StatusStopReg = "X";



            if (Ksf == Ks)
                CheckReglamentStr = "Соответствует";
            if (Ksf != Ks)
                CheckReglamentStr = "Ошибка";

            ErrorKs = (reg8A.Status & 0x1) == 0 ? "\u2714" : "X";
            ErrorCyclogramm = ((reg8A.Status >> 1) & 0x1) == 0 ? "\u2714" : "X";
            ErrorLg = ((reg8A.Status >> 2) & 0x1) == 0 ? "\u2714" : "X";
            ErrorAx = ((reg8A.Status >> 3) & 0x1) == 0 ? "\u2714" : "X";
            ErrorTdLg = ((reg8A.Status >> 4) & 0x1) == 0 ? "\u2714" : "X";
            ErrorTdAx = ((reg8A.Status >> 5) & 0x1) == 0 ? "\u2714" : "X";
            ErrorBopi = ((reg8A.Status >> 6) & 0x1) == 0 ? "\u2714" : "X";
            ErrorKren = ((reg8A.Status >> 7) & 0x1) == 0 ? "\u2714" : "X";
            ErrorOverVibration = ((reg8A.Status >> 8) & 0x1) == 0 ? "\u2714" : "X";
            ErrorG = ((reg8A.Status >> 9) & 0x1) == 0 ? "\u2714" : "X";
            ProcessReg = ((reg8A.Status >> 10) & 0x1) == 0 ? "\u2714" : "X";
            DataNotUpdate = ((reg8A.Status >> 11) & 0x1) == 0 ? "\u2714" : "X";

            Ksf = reg8A.Ksf;
            Ks = reg8A.Ks;



        }


        public List<string> LstResultStopReg
        {
            get
            {
                List<string> lstResultStopReg = new List<string>();
                lstResultStopReg.Add(StatusStopReg);
                lstResultStopReg.Add(Ks.ToString());
                lstResultStopReg.Add(Ksf.ToString());

                return lstResultStopReg;
            }
        }

        public List<string> LstResultRefusalAndMessages
        {
            get
            {
                List<string> lstResultRefusalAndMessages = new List<string>();
                lstResultRefusalAndMessages.Add(ErrorKs);
                lstResultRefusalAndMessages.Add(ErrorCyclogramm);
                lstResultRefusalAndMessages.Add(ErrorLg);
                lstResultRefusalAndMessages.Add(ErrorAx);
                lstResultRefusalAndMessages.Add(ErrorTdLg);
                lstResultRefusalAndMessages.Add(ErrorTdAx);
                lstResultRefusalAndMessages.Add(ErrorBopi);
                lstResultRefusalAndMessages.Add(ErrorKren);
                lstResultRefusalAndMessages.Add(ErrorOverVibration);
                lstResultRefusalAndMessages.Add(ErrorG);
                lstResultRefusalAndMessages.Add(ProcessReg);
                lstResultRefusalAndMessages.Add(DataNotUpdate);

                return lstResultRefusalAndMessages;
            }
        }



        private double ks;
        public double Ks
        {
            get { return ks; }
            set
            {
                ks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ks"));
            }
        }


        private double ksf;
        public double Ksf
        {
            get { return ksf; }
            set
            {
                ksf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ksf"));
            }
        }

        private string checkReglamentStr;
        public string CheckReglamentStr
        {
            get { return checkReglamentStr; }
            set
            {
                checkReglamentStr = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CheckReglamentStr"));
            }
        }


        private string errorKs;
        public string ErrorKs
        {
            get { return errorKs; }
            set
            {
                errorKs = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorKs"));
            }
        }

        private string errorCyclogramm;
        public string ErrorCyclogramm
        {
            get { return errorCyclogramm; }
            set
            {
                errorCyclogramm = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorCyclogramm"));
            }
        }

        private string errorLg;
        public string ErrorLg
        {
            get { return errorLg; }
            set
            {
                errorLg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorLg"));
            }
        }

        private string errorAx;
        public string ErrorAx
        {
            get { return errorAx; }
            set
            {
                errorAx = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorAx"));
            }
        }

        private string errorTdLg;
        public string ErrorTdLg
        {
            get { return errorTdLg; }
            set
            {
                errorTdLg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorTdLg"));
            }
        }

        private string errorTdAx;
        public string ErrorTdAx
        {
            get { return errorTdAx; }
            set
            {
                errorTdAx = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorTdAx"));
            }
        }

        private string errorBopi;
        public string ErrorBopi
        {
            get { return errorBopi; }
            set
            {
                errorBopi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorBopi"));
            }
        }

        private string errorKren;
        public string ErrorKren
        {
            get { return errorKren; }
            set
            {
                errorKren = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorKren"));
            }
        }

        private string errorOverVibration;
        public string ErrorOverVibration
        {
            get { return errorOverVibration; }
            set
            {
                errorOverVibration = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorOverVibration"));
            }
        }

        private string errorG;
        public string ErrorG
        {
            get { return errorG; }
            set
            {
                errorG = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorG"));
            }
        }

        private string processReg;
        public string ProcessReg
        {
            get { return processReg; }
            set
            {
                processReg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProcessReg"));
            }
        }

        private string dataNotUpdate;
        public string DataNotUpdate
        {
            get { return dataNotUpdate; }
            set
            {
                dataNotUpdate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DataNotUpdate"));
            }
        }

        private string statusStopReg;

        public string StatusStopReg
        {
            get { return statusStopReg; }
            set 
            { 
                statusStopReg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StatusStopReg"));
            }
        }

    }
}
