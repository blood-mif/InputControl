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
    public class ViewModelPassportConst : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void GetDataPassportConst(object o, EventArgs e)
        {
            SendPuckP1 spP1 = ((SendPuckP1)o);
            //var reg8A = (RegRk8A)(spP1.Reg8A);
            //       var axelks = (short)(spP1.KsAxel); 
            if (spP1.KsGyro == spP1.KsfGyro)
                ConstGyro = "Соответствует";
            else
                ConstGyro = "Ошибка";

            if (spP1.KsAxel == spP1.KsfAxel)
                ConstAxel = "Соответствует";
            else
                ConstAxel = "Ошибка";

            //if (spP1.KsBoolMapConst)
            //    ConstMAP = "Соответствует";
            //else
            //    ConstMAP = "Ошибка";

            
            //!!!!!!!!!!!!!!!!!!!!! инфо добавить когда будет инфа!!!!!!!!


            Ksf = spP1.KsfAxel+spP1.KsfGyro;
            Ks = spP1.KsAxel+spP1.KsGyro;


            if (Ksf == Ks)
                CheckReglamentStr = "Соответствует";
            else
                CheckReglamentStr = "Ошибка";

        }

        private List<string> lstResultPC;
        public List<string> LstResultPC
        {
            get
            {
                lstResultPC.Add(ConstGyro);
                lstResultPC.Add(ConstAxel);
                lstResultPC.Add(ConstMAP);

                return lstResultPC;
            }
        }

        private List<string> lstResultRefusalAndMessages;
        public List<string> LstResultRefusalAndMessages
        {
            get
            {
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



        private int info;
        public int Info
        {
            get { return info; }
            set
            {
                info = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Info"));
            }
        }

        private string constGyro;
        public string ConstGyro
        {
            get { return constGyro; }
            set
            {
                constGyro = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConstGyro"));
            }
        }

        private string constAxel;
        public string ConstAxel
        {
            get { return constAxel; }
            set
            {
                constAxel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConstAxel"));
            }
        }

        private string constMAP;
        public string ConstMAP
        {
            get { return constMAP; }
            set
            {
                constMAP = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConstMAP"));
            }
        }



    }

}
