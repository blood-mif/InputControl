using InputControl_9B925.Model;
using L_412_StrData;
using L_412_StrData.DataProcess;
using L_412_StrData.Regims._9B925.Answers;
using L_412_StrData.Regims.iibrkRegims.Answers;
using L_412_StrData.Константы;
using L_412_StrData.Константы.ConAcpV;
using L_412_StrData.Константы.Акселерометры;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputControl_9B925.Analyse
{
    public class BaseAnalyse
    {
        public int Index;
        public EventHandler EventFinishAnalyse;

        public virtual void StartAnalyse(string path)
        {
            string regName ="";
            string currStr = path.Substring(path.Length - 2);
            switch (currStr)
            {
                case "Г1":
                    regName = "\\" + currStr;
                    currStr = "51";
                    break;
                case "Г3":
                    regName = "\\" + currStr;
                    currStr = "61";
                    break;
                case "_0":
                case "_1":
                case "_2":
                case "_3":
                case "_4":
                case "_5":
                    regName = "";
                    currStr = "61";
                    break;
                case "нт":
                    regName = "\\" + "Регламент";
                    currStr = "3";
                    break;
                default:
                    break;
            }
           // RegPki6 dsd = new RegPki6();
            var listCalibration = new ClassData(path +  regName + "\\reg" + currStr + ".mki");
            var listRegRk8A = new ClassData(path + "\\" + regName + "\\Advanced\\Reg" + currStr + "_8.mki");

            //ClassData listRegRk8A;
            //ClassData listCalibration;
            //if (currStr == "3")
            //{
            //     listRegRk8A = new ClassData(path + "\\"+regName+"\\Reg"+currStr+".mki");
            //     listCalibration = new ClassData(path + "\\" + regName + "\\Advanced\\Reg" + currStr + "_8.mki");
            //}
            //else{
            //    listCalibration = new ClassData(path + "\\"+regName+"\\Reg"+currStr+".mki");
            //    listRegRk8A  = new ClassData(path + "\\" + regName + "\\Advanced\\Reg" + currStr + "_8.mki");
            //}
            Index =FindIndex(listRegRk8A);
            CheckPass(listRegRk8A);

            SendPuckP1 sendPuckP1 = new SendPuckP1(listRegRk8A[Index], listCalibration[Index]);
            EventFinishAnalyse?.Invoke(sendPuckP1, null);
        }

        private List<byte> lstByte = new List<byte>();

        private List<byte> CnvArrayUShortToLstBytes(ushort[] ushortArr)
        {
            List<byte> lstBytes = new List<byte>();

            for (int i = 0; i < ushortArr.Length; i++)
            {
                lstBytes.AddRange(BitConverter.GetBytes(ushortArr[i]));
            }
            return lstBytes;
        }
        public virtual void StartAnalysePassportConst(string path)
        {
            //var listRegRk8A = new ClassData(path + "\\pa2.mki");

            //Index = FindIndex(listRegRk8A);
            //CheckPass(listRegRk8A);

            var reg11 = ReaderF.ReadData<RegRk11A>(path + "\\Page0.mki");
            var countPages = reg11[0].Pages;
            List<ClassData> lstPages = new List<ClassData>();

            ushort[] resultMass = new ushort[0];

            for (int i = 1; i < countPages; i++)
            {
                var page = new ClassData(path + "\\Page" + i + ".mki");
                RegRk177A reg177 = ((RegRk177A)page[0]);
                lstByte.AddRange(CnvArrayUShortToLstBytes(reg177.MassData.ToArray()));
            }
            ClassGyrosConstV21 gyroConstFast = new ClassGyrosConstV21();
            gyroConstFast.LoadBin(lstByte.ToArray());
            var ksGyroFast = gyroConstFast.Ks;
            var ksfGyroFast = gyroConstFast.Ksf;
            bool checkGyroKsFast = gyroConstFast.CheckKs;
            var sizeGyroPcFast = gyroConstFast.ByteMas.Count();
        //    gyroConstFast.SaveBin("D:\\gyroConstFast");

            ClassGyrosConstV21 gyroConstSlow = new ClassGyrosConstV21();
            gyroConstSlow.LoadBin(lstByte.ToArray(),sizeGyroPcFast+2);
            var ksGyroSlow = gyroConstSlow.Ks;
            var ksfGyroSlow = gyroConstSlow.Ksf;
            bool checkGyroKsSlow = gyroConstSlow.CheckKs;
            var sizeGyroPcSlow = gyroConstSlow.ByteMas.Count();
            //     gyroConstSlow.SaveBin("D:\\gyroConstSlow");
            ClassAxelConst axelConst = new ClassAxelConst();
            axelConst.LoadBin(lstByte.ToArray(),sizeGyroPcFast + sizeGyroPcSlow+2);
            var ksAxel = axelConst.Ks;
            var ksfAxel = axelConst.Ksf;
            bool checkAxelKs = axelConst.CheckKs;
            var sizeAxelPc = axelConst.ByteMas.Count();
            
            //ClassConV mapConst = new ClassConV();
            //mapConst.LoadBin(lstByte.ToArray(), sizeGyroPc + sizeAxelPc + 4);
            //var ksMap = mapConst.Ks;
            //var ksfMap = mapConst.Ksf;
            //bool checkMapKs = mapConst.CheckKs;


            SendPuckP1 sendPuckP1 = new SendPuckP1(ksGyroFast, ksfGyroFast,ksGyroSlow,ksfGyroSlow, ksAxel, ksfAxel);
          //  SendPuckP1 sendPuckP1 = new SendPuckP1(ksGyro, ksfGyro, ksAxel, ksfAxel);
          //  SendPuckP1 sendPuckP1 = new SendPuckP1(listRegRk8A[Index], checkGyroKs,checkAxelKs, checkMapKs);
            EventFinishAnalyse?.Invoke(sendPuckP1, null);
        }
        public virtual int FindIndex(ClassData _listRegRk8A)
        {
            for (int i = 0; i < _listRegRk8A.Count; i++)
            {
                RegRk8A regRk8 = ((RegRk8A)_listRegRk8A[i]);
                if (regRk8.Status==0)
                    return i;
                //if (((regRk8.Status >> 10) & 0x1) == 0)
                //    return i;
            }
                return 0;
        }
        List<int> listPass = new List<int>();
        public virtual void CheckPass(ClassData _listRegRk8A)
        {
            for (int i = 0; i < _listRegRk8A.Count; i++)
            {
                if (i!=0)
                {
                    RegRk8A prevReg = ((RegRk8A)_listRegRk8A[i-1]);
                    RegRk8A currReg = ((RegRk8A)_listRegRk8A[i]);

                    if (prevReg.N+1 == currReg.N)
                    {
                        if (prevReg.N == prevReg.GetMaxNumber() && currReg.N == 0)
                        {
                            return;
                        }
                        else
                            listPass.Add(i);
                    }
                }
            }
        }
    }
}
