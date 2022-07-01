using L_412_StrData.DataProcess;
using L_412_StrData.Regims;
using L_412_StrData.Regims.iibrkRegims.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputControl_9B925.Model
{
    public class SendPuckP1 
    {
        public SendPuckP1(BaseReg reg8A, BaseReg regCalibration51)
        {
            Reg8A = reg8A;
            RegRkCAlibration = regCalibration51;
        }

        public SendPuckP1(BaseReg reg8A,bool ksGyroConst, bool ksAxelConst, bool checkMapKs)
        {
            Reg8A = reg8A;
            KsBoolGyroConst = ksGyroConst;
            KsBoolAxelConst = ksAxelConst;
            KsBoolMapConst = checkMapKs;
        }
        public SendPuckP1(short ksGyro,int ksfGyro,short ksAxel,int ksfAxel)
        {
            KsGyro = ksGyro;
            KsfGyro = ksfGyro;
            KsAxel = ksAxel;
            KsfAxel = ksfAxel;
        }
        public SendPuckP1(short ksGyroFast, int ksfGyroFast, short ksGyroSlow, int ksfGyroSlow, short ksAxel, int ksfAxel)
        {
            KsGyroFast = ksGyroFast;
            KsfGyroFast = ksfGyroFast;
            KsGyroSlow = ksGyroSlow;
            KsfGyroSlow = ksfGyroSlow;
            KsAxel = ksAxel;
            KsfAxel = ksfAxel;
        }
        public short KsGyroFast;
        public short KsGyroSlow;
        public int KsfGyroFast;
        public int KsfGyroSlow;
        public short KsGyro;
        public int KsfGyro;
        public short KsAxel;
        public int KsfAxel;
        public bool KsBoolMapConst;
        public bool KsBoolGyroConst;
        public bool KsBoolAxelConst;
        public BaseReg Reg8A;
        public BaseReg RegRkCAlibration;
    }
}
