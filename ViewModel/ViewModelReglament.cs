﻿using InputControl_9B925.Model;
using L_412_StrData.Regims.iibrkRegims.Answers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputControl_9B925.ViewModel
{
    public class ViewModelReglament : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void GetDataReglament(object o, EventArgs e)
        {

            SendPuckP1 spP1 = ((SendPuckP1)o);
            var regReglament = (RegRk3A)(spP1.RegRkCAlibration);
            var reg8A = (RegRk8A)(spP1.Reg8A);


            OfsetX = regReglament.Ha[0];
            OfsetY = regReglament.Ha[1];
            OfsetZ = regReglament.Ha[2];
            DriftX = regReglament.DOmega[0];
            DriftY = regReglament.DOmega[1];
            DriftZ = regReglament.DOmega[2];
            AccelX = regReglament.DHa[0];
            AccelY = regReglament.DHa[1];
            AccelZ = regReglament.DHa[2];

            

            Azimuth = regReglament.Azimuth;
            Bank = regReglament.Alpha;
            Pitch = regReglament.Betta;

            Ksf = regReglament.Ksf;
            Ks = regReglament.Ks;


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



        }

        public List<float> LstResultReglament
        {
            get 
            {
                List<float> lstResultReglament = new List<float>();
                lstResultReglament.Add(azimuth);
                lstResultReglament.Add(pitch);
                lstResultReglament.Add(bank);
                lstResultReglament.Add(OfsetX); 
                lstResultReglament.Add(OfsetY); 
                lstResultReglament.Add(OfsetZ); 
                lstResultReglament.Add(DriftX); 
                lstResultReglament.Add(DriftY); 
                lstResultReglament.Add(DriftZ); 
                lstResultReglament.Add(AccelX); 
                lstResultReglament.Add(AccelY);
                lstResultReglament.Add(AccelZ);
                lstResultReglament.Add(Ks);
                lstResultReglament.Add(Ksf);

                return lstResultReglament;
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


        private float ks;
        public float Ks
        {
            get { return ks; }
            set 
            {
                ks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ks"));
            }
        }


        private float ksf;
        public float Ksf
        {
            get { return ksf; }
            set { 
                ksf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ksf"));
            }
        }

        private string checkReglamentStr;
        public string CheckReglamentStr
        {
            get { return checkReglamentStr; }
            set { checkReglamentStr = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CheckReglamentStr"));
            }
        }



        private float azimuth;
        public float Azimuth
        {
            get { return azimuth; }
            set 
            {
                azimuth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Azimuth"));
            }
        }

        private float pitch;
        public float Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pitch"));
            }
        }
        
        private float bank;
        public float Bank
        {
            get { return bank; }
            set
            {
                bank = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bank"));
            }
        }

        private float ofsetX;
        public float OfsetX
        {
            get { return ofsetX; }
            set
            {
                ofsetX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OfsetX"));
            }
        }
    
        private float ofsetY;
        public float OfsetY
        {
            get { return ofsetY; }
            set
            {
                ofsetY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OfsetY"));
            }
        }
        
        private float ofsetZ;
        public float OfsetZ
        {
            get { return ofsetZ; }
            set
            {
                ofsetZ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OfsetZ"));
            }
        }

        private float driftX;
        public float DriftX
        {
            get { return driftX; }
            set
            {
                driftX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DriftX"));
            }
        }
        
        private float driftY;
        public float DriftY
        {
            get { return driftY; }
            set
            {
                driftY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DriftY"));
            }
        }

        private float driftZ;
        public float DriftZ
        {
            get { return driftZ; }
            set
            {
                driftZ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DriftZ"));
            }
        }

        private float accelX;
        public float AccelX
        {
            get { return accelX; }
            set
            {
                accelX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AccelX"));
            }
        }
        
        private float accelY;
        public float AccelY
        {
            get { return accelY; }
            set
            {
                accelY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AccelY"));
            }
        }
        
        private float accelZ;
        public float AccelZ
        {
            get { return accelZ; }
            set
            {
                accelZ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AccelZ"));
            }
        }

    }
}
