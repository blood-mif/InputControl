using L_412_StrData.DataReport.Tables;
using L_412_StrData.DataReport.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WriteXpsDocument.ViewModel;

namespace InputControl_9B925.Report
{
    public class VMReportImputControl : BaseViewModelReport
    {
        public ReportModel ReportModel { get; set; }
        public VMReportImputControl(ReportModel reportModel)
        {
            ReportModel = reportModel;
            StartCalculate("");
        }

        List<string> listData = new List<string>();

        public override void Calculate(string technolDirectoryPath)
        {
            // ReportFlow.AddData(new Text($"Протокол входного контроля :", 14) { FontAligment = TextAlignment.Center });
            ReportFlow.AddData(TabHeader);
            ReportFlow.AddData(new Text($" "));
            ReportFlow.AddData(new Text($"Данные из папки «Регламент» :", 14, HorizontalAlignment.Center));
            ReportFlow.AddData(TabCheckTypeReglament);
            ReportFlow.AddData(CreateTableReglament(ReportModel.WMReglament.LstResultReglament, "Контроль режима «Регламент»"));
            ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.WMReglament.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            ReportFlow.AddNewPage();

            ReportFlow.AddData(new Text($"Данные из папки «Г1» :", 14, HorizontalAlignment.Center));
            ReportFlow.AddData(TabCheckTypeG1);
            ReportFlow.AddData(TabControlTypeG1);
            ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.VMErrCal51.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            ReportFlow.AddNewPage();

            ReportFlow.AddData(new Text($"Данные из папки «Г3» :", 14, HorizontalAlignment.Center));
            ReportFlow.AddData(TabCheckTypeG3);
            ReportFlow.AddData(TabControlTypeG3);
            ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.VMErrCal61.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            ReportFlow.AddNewPage();

            ReportFlow.AddData(new Text($" ", 14, HorizontalAlignment.Center));
            ReportFlow.AddData(TabControlTypeFashion);
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            ReportFlow.AddNewPage();

            ReportFlow.AddData(new Text($"Данные из папки «Чтение паспортных констант» :", 14, HorizontalAlignment.Center));
            ReportFlow.AddData(TabCheckRegReadPC);
            ReportFlow.AddData(TabControlReadPC);
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
           // ReportFlow.AddNewPage();

            //ReportFlow.AddData(new Text($"Данные из папки «Прекращение режима» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(TabCheckRegStopReg);
            //ReportFlow.AddData(TabControlRegStopReg);
            //ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.VMStatusSR.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddNewPage();

            //ReportFlow.AddData(new Text($"Данные из папки «Установка типа измерений» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(new Text($"Тип измерений №1» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(CreateTableCheckSetTypeReg(ReportModel.WMsettMT1.LstStatusStopReg, "Проверка режима «Установка типа измерений»"));
            //ReportFlow.AddData(CreateTableControlTypeReg(ReportModel.WMsettMT1.LstResultStopReg1, "Контроль режима «Установка типа измерений» "));
            //ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.WMsettMT1.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddNewPage();

            //ReportFlow.AddData(new Text($"Данные из папки «Установка типа измерений» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(new Text($"Тип измерений №2» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(CreateTableCheckSetTypeReg(ReportModel.WMsettMT2.LstStatusStopReg, "Проверка режима «Установка типа измерений»"));
            //ReportFlow.AddData(CreateTableControlTypeReg(ReportModel.WMsettMT2.LstResultStopReg2, "Контроль режима «Установка типа измерений» "));
            //ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.WMsettMT2.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddNewPage();

            //ReportFlow.AddData(new Text($"Данные из папки «Установка типа измерений» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(new Text($"Тип измерений №3» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(CreateTableCheckSetTypeReg(ReportModel.WMsettMT3.LstStatusStopReg, "Проверка режима «Установка типа измерений»"));
            //ReportFlow.AddData(CreateTableControlTypeReg(ReportModel.WMsettMT3.LstResultStopReg3, "Контроль режима «Установка типа измерений» "));
            //ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.WMsettMT3.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddNewPage();

            //ReportFlow.AddData(new Text($"Данные из папки «Установка типа измерений» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(new Text($"Тип измерений №4» :", 14, HorizontalAlignment.Center));
            //ReportFlow.AddData(CreateTableCheckSetTypeReg(ReportModel.WMsettMT4.LstStatusStopReg, "Проверка режима «Установка типа измерений»"));
            //ReportFlow.AddData(CreateTableControlTypeReg(ReportModel.WMsettMT4.LstResultStopReg4, "Контроль режима «Установка типа измерений» "));
            //ReportFlow.AddData(CreateTableErrorAndMessages(ReportModel.WMsettMT4.LstResultRefusalAndMessages, "Контроль отказов и сообщений ИИБ"));
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($" ") { FontAligment = TextAlignment.Left });
            //ReportFlow.AddData(new Text($"Подпись оператора____________________________") { FontAligment = TextAlignment.Left });

            ReportFlow.SaveXps(pathToSaveFileDefault, true);
        }
        private string pathToSaveFileDefault = Directory.GetCurrentDirectory() + "\\reportFile.xps";
        private TableClass CreateTableErrorAndMessages(List<string> data, String nameTable)
        {

            List<string[]> lstStr = new List<string[]>();

            lstStr.Add(new[] { "Расшифровка отказа / сообщение", "Состояние" });

            string[] arrNotes = new string[] { "Ошибка КС", "Нарушение циклограммы", "Нет готовности ИИБ с отказавшего блока ЛГ",
            "Нет готовности ИИБ с отказавшего блока акселерометры","Нет готовности ИИБ с отказавшего блока термодатчики ЛГ",
            "Нет готовности ИИБ с отказавшего блока термодатчики  акселерометров","Нет готовности ИИБ с отказавшего блока отказ БОПИ",
            "Измеренные наклоны ИИБ больше нормы (5 град.)","Вибрации больше нормы (5g)","Разница между измеренными и переданными значениями ускорения силы тяжести больше допуска",
            "ИИБ находится в состоянии выполнения специального режима","Данные (измерения) в ПА2 или ПА3 не обновлены"};

            for (int i = 0; i < data.Count; i++)
            {
                lstStr.Add(new[] { arrNotes[i], data[i] });
            }


            TableClass currTable = new TableClass(lstStr, nameTable);
            currTable.SetBoldRow(0);
            currTable.SetBoldCol(0);
            currTable.SetTableFontSize(12);
            return currTable;
        }

        private TableClass CreateTableReglament(List<float> data, String nameTable)
        {

            List<string[]> lstStr = new List<string[]>();

            lstStr.Add(new[] { "", "Норма - не менее", "Норма - не более", "Результаты испытаний" });

            string[] arrNotes = new string[] { "Угол Азимута, рад.", "Угол Тангаж , рад.", "Угол Крена, рад.", "H AXT, м/с2", "H AYT, м/с2", "H AZT, м/с2",
            "dw X, рад./с","dw X, рад./с","dw X, рад./с","dH AX, м/с2","dH AX, м/с2","dH AX, м/с2","KS","KS рассчит."};
            string[] arrNotes2 = new string[] { "-6.283185E+00", "-1.570796E+00", "-1.570796E+00", "-2E-01", "-2E-01", "-2E-01", "-5Е-06", "-5Е-06", "-5Е-06", "-4Е-03", "-4Е-03", "-4Е-03", "—", "—" };
            string[] arrNotes3 = new string[] { "6.283185E+00", "1.570796E+00", "1.570796E+00", "2E-01", "2E-01", "2E-01", "5Е-06", "5Е-06", "5Е-06", "4Е-03", "4Е-03", "4Е-03", "—", "—" };

            for (int i = 0; i < data.Count; i++)
            {
                lstStr.Add(new[] { arrNotes[i], arrNotes2[i], arrNotes3[i], data[i].ToString() });
            }


            TableClass currTable = new TableClass(lstStr, nameTable);
            currTable.SetBoldRow(0);
            currTable.SetBoldCol(0);
            currTable.SetTableFontSize(10);
            return currTable;
        }

        private TableClass CreateTableCheckSetTypeReg(List<string> data, String nameTable)
        {
            List<string[]> lstStr = new List<string[]>();

            lstStr.Add(new[] { "", "Результат выполнения режима" });
            lstStr.Add(new[] { "Режим «Установка типа измерений»", data[0] });


            TableClass currTable = new TableClass(lstStr, "Проверка режима «Установка типа измерений»");
            return currTable;
        }

        private TableClass CreateTableControlTypeReg(List<string> data, String nameTable)
        {
            List<string[]> lstStr = new List<string[]>();

            lstStr.Add(new[] { "", "Результаты испытаний" });
            lstStr.Add(new[] { "Текущий режим остановлен", data[0] });
            lstStr.Add(new[] { "KS", data[1] });
            lstStr.Add(new[] { "KS рассчит.", data[2] });


            TableClass currTable = new TableClass(lstStr, "Контроль режима «Установка типа измерений» ");
            return currTable;
        }

        private TableClass tabHeader;
        public TableClass TabHeader
        {
            get
            {
                if (tabHeader != null)
                    return tabHeader;


                List<string[]> lstStr = new List<string[]>();

                lstStr.Add(new[] { "Тип изделия", "Заводской номер", "Дата", "Фамилия оператора" });
                lstStr.Add(new[] { ReportModel.LstHeader[0], ReportModel.LstHeader[1], ReportModel.LstHeader[2], ReportModel.LstHeader[3] });



                tabHeader = new TableClass(lstStr, "Протокол входного контроля :");//{ Width = 720 };
                tabHeader.SetTableFontSize(12);

                return tabHeader;
            }
        }

        private TableClass tabCheckTypeReglament;
        public TableClass TabCheckTypeReglament
        {
            get
            {
                if (tabCheckTypeReglament != null)
                    return tabCheckTypeReglament;


                List<string[]> lstStr = new List<string[]>();

                lstStr.Add(new[] { "", "Результат выполнения режима" });
                lstStr.Add(new[] { "Режим  «Регламент»", ReportModel.WMReglament.CheckReglamentStr });



                tabCheckTypeReglament = new TableClass(lstStr, "Проверка режима «Регламент»");//{ Width = 720 };
                tabCheckTypeReglament.SetTableFontSize(12);

                return tabCheckTypeReglament;
            }
        }

        private TableClass tabCheckTypeG1;
        public TableClass TabCheckTypeG1
        {
            get
            {
                if (tabCheckTypeG1 != null)
                    return tabCheckTypeG1;


                List<string[]> lstStr = new List<string[]>();

                lstStr.Add(new[] { "", "Результат выполнения режима" });
                lstStr.Add(new[] { "Режим «Г1»", ReportModel.VMErrCal51.CheckReglamentStr });



                tabCheckTypeG1 = new TableClass(lstStr, "Проверка режима «Г1»");//{ Width = 720 };


                return tabCheckTypeG1;
            }
        }

        private TableClass tabControlTypeG1;
        public TableClass TabControlTypeG1
        {
            get
            {
                if (tabControlTypeG1 != null)
                    return tabControlTypeG1;


                List<string[]> lstStr = new List<string[]>();

                lstStr.Add(new[] { "", "Норма - не менее", "Норма - не более", "Результаты испытаний" });
                lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal51.LstResultG[1].ToString() });
                lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal51.LstResultG[2].ToString() });
                lstStr.Add(new[] { "KS", "", "", ReportModel.VMErrCal51.LstResultG[3].ToString() });
                lstStr.Add(new[] { "KS рассчит.", "", "", ReportModel.VMErrCal51.LstResultG[4].ToString() });



                tabControlTypeG1 = new TableClass(lstStr, "Контроль режима «Г1» ");//{ Width = 720 };


                return tabControlTypeG1;
            }
        }

        private TableClass tabCheckTypeG3;
        public TableClass TabCheckTypeG3
        {
            get
            {
                if (tabCheckTypeG3 != null)
                    return tabCheckTypeG3;


                List<string[]> lstStr = new List<string[]>();

                lstStr.Add(new[] { "", "Результат выполнения режима" });
                lstStr.Add(new[] { "Режим «Г3»", ReportModel.VMErrCal61.CheckReglamentStr });



                tabCheckTypeG3 = new TableClass(lstStr, "Проверка режима «Г3»");//{ Width = 720 };


                return tabCheckTypeG3;
            }
        }

        private TableClass tabControlTypeG3;
        public TableClass TabControlTypeG3
        {
            get
            {
                if (tabControlTypeG3 != null)
                    return tabControlTypeG3;


                List<string[]> lstStr = new List<string[]>();

                lstStr.Add(new[] { "", "Норма - не менее", "Норма - не более", "Результаты испытаний" });
                lstStr.Add(new[] { "Азимут, рад.", "-6.283185E+00", "6.283185E+00", ReportModel.VMErrCal61.LstResultG[0].ToString() });
                lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61.LstResultG[1].ToString() });
                lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61.LstResultG[2].ToString() });
                lstStr.Add(new[] { "KS", "", "", ReportModel.VMErrCal61.LstResultG[3].ToString() });
                lstStr.Add(new[] { "KS рассчит.", "", "", ReportModel.VMErrCal61.LstResultG[4].ToString() });

                return tabControlTypeG3;
            }
        }

        private TableClass tabControlTypeFashion;
        public TableClass TabControlTypeFashion
        {
            get
            {
                if (tabControlTypeFashion != null)
                    return tabControlTypeFashion;


                List<string[]> lstStr = new List<string[]>();

                //lstStr.Add(new[] { "", "Норма - не менее", "Норма - не более", "Результаты испытаний" });
                //lstStr.Add(new[] { "Азимут, рад.", "-6.283185E+00", "6.283185E+00", ReportModel.VMErrCal61_0.LstResultG[0].ToString() });
                //lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_0.LstResultG[1].ToString() });
                //lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_0.LstResultG[2].ToString() });
                //lstStr.Add(new[] { "", "", "", "" });
                //lstStr.Add(new[] { "Азимут, рад.", "-6.283185E+00", "6.283185E+00", ReportModel.VMErrCal61_1.LstResultG[0].ToString() });
                //lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_1.LstResultG[1].ToString() });
                //lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_1.LstResultG[2].ToString() });
                //lstStr.Add(new[] { "", "", "", "" });
                //lstStr.Add(new[] { "Азимут, рад.", "-6.283185E+00", "6.283185E+00", ReportModel.VMErrCal61_2.LstResultG[0].ToString() });
                //lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_2.LstResultG[1].ToString() });
                //lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_2.LstResultG[2].ToString() });
                //lstStr.Add(new[] { "", "", "", "" });
                //lstStr.Add(new[] { "Азимут, рад.", "-6.283185E+00", "6.283185E+00", ReportModel.VMErrCal61_3.LstResultG[0].ToString() });
                //lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_3.LstResultG[1].ToString() });
                //lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_3.LstResultG[2].ToString() });
                //lstStr.Add(new[] { "", "", "", "" });
                //lstStr.Add(new[] { "Азимут, рад.", "-6.283185E+00", "6.283185E+00", ReportModel.VMErrCal61_4.LstResultG[0].ToString() });
                //lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_4.LstResultG[1].ToString() });
                //lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_4.LstResultG[2].ToString() });
                //lstStr.Add(new[] { "", "", "", "" });
                //lstStr.Add(new[] { "Азимут, рад.", "-6.283185E+00", "6.283185E+00", ReportModel.VMErrCal61_5.LstResultG[0].ToString() });
                //lstStr.Add(new[] { "Крен (альфа), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_5.LstResultG[1].ToString() });
                //lstStr.Add(new[] { "Тангаж (бета), рад.", "-1.570796E+00", "1.570796 E+00", ReportModel.VMErrCal61_5.LstResultG[2].ToString() });

                lstStr.Add(new[] { ReportModel.VMErrCal61_0.LstResultG[0].ToString(), ReportModel.VMErrCal61_0.LstResultG[1].ToString(), ReportModel.VMErrCal61_0.LstResultG[2].ToString() });
                lstStr.Add(new[] { "", "", "", "" });
                lstStr.Add(new[] { ReportModel.VMErrCal61_1.LstResultG[0].ToString(), ReportModel.VMErrCal61_1.LstResultG[1].ToString(), ReportModel.VMErrCal61_1.LstResultG[2].ToString() });
                lstStr.Add(new[] { "", "", "", "" });
                lstStr.Add(new[] { ReportModel.VMErrCal61_2.LstResultG[0].ToString(), ReportModel.VMErrCal61_2.LstResultG[1].ToString(), ReportModel.VMErrCal61_2.LstResultG[2].ToString() });
                lstStr.Add(new[] { "", "", "", "" });
                lstStr.Add(new[] { ReportModel.VMErrCal61_3.LstResultG[0].ToString(), ReportModel.VMErrCal61_3.LstResultG[1].ToString(), ReportModel.VMErrCal61_3.LstResultG[2].ToString() });
                lstStr.Add(new[] { "", "", "", "" });
                lstStr.Add(new[] { ReportModel.VMErrCal61_4.LstResultG[0].ToString(), ReportModel.VMErrCal61_4.LstResultG[1].ToString(), ReportModel.VMErrCal61_4.LstResultG[2].ToString() });
                lstStr.Add(new[] { "", "", "", "" });
                lstStr.Add(new[] { ReportModel.VMErrCal61_5.LstResultG[0].ToString(), ReportModel.VMErrCal61_5.LstResultG[1].ToString(), ReportModel.VMErrCal61_5.LstResultG[2].ToString() });



                tabControlTypeG3 = new TableClass(lstStr, " ");//{ Width = 720 };


                return tabControlTypeG3;
            }
        }


        private TableClass tabCheckRegReadPC;
        public TableClass TabCheckRegReadPC
        {
            get
            {
                if (tabCheckRegReadPC != null)
                    return tabCheckRegReadPC;


                List<string[]> lstStr = new List<string[]>();

                lstStr.Add(new[] { "", "Результат выполнения режима" });
                lstStr.Add(new[] { "Режим «Чтение паспортных констант»", ReportModel.VMPassportConst.CheckReglamentStr });



                tabCheckRegReadPC = new TableClass(lstStr, "Проверка режима «Чтение паспортных констант»");//{ Width = 720 };


                return tabCheckRegReadPC;
            }
        }

        private TableClass tabControlRegReadPC;
        public TableClass TabControlReadPC
        {
            get
            {
                if (tabControlRegReadPC != null)
                    return tabControlRegReadPC;


                List<string[]> lstStr = new List<string[]>();

                //lstStr.Add(new[] { "", "Результат выполнения режима" });
                //lstStr.Add(new[] { "Константы гироскопов", ReportModel.VMPassportConst.ConstGyro });
                //lstStr.Add(new[] { "Константы акселерометров", ReportModel.VMPassportConst.ConstAxel });
                ////lstStr.Add(new[] { "Константы платы МАП", ReportModel.VMPassportConst.ConstMAP });

                lstStr.Add(new[] { "", "Результат выполнения режима" });
                lstStr.Add(new[] { "Константы гироскопов", "Соответствует" });
                lstStr.Add(new[] { "Константы акселерометров", "Соответствует" });
                //lstStr.Add(new[] { "Константы платы МАП", ReportModel.VMPassportConst.ConstMAP });


                tabControlRegReadPC = new TableClass(lstStr, "Контроль режима «Чтение паспортных констант» ");//{ Width = 720 };


                return tabControlRegReadPC;
            }
        }


        //private TableClass tabCheckRegStopReg;
        //public TableClass TabCheckRegStopReg
        //{
        //    get
        //    {
        //        if (tabCheckRegStopReg != null)
        //            return tabCheckRegStopReg;

        //        List<string[]> lstStr = new List<string[]>();

        //        lstStr.Add(new[] { "", "Результат выполнения режима" });
        //        lstStr.Add(new[] { "Режим «Прекращение режима»", ReportModel.VMStatusSR.CheckReglamentStr });

        //        tabCheckRegStopReg = new TableClass(lstStr, "");//{ Width = 720 };

        //        return tabCheckRegStopReg;
        //    }
        //}

        //private TableClass tabControlRegStopReg;
        //public TableClass TabControlRegStopReg
        //{
        //    get
        //    {
        //        if (tabControlRegStopReg != null)
        //            return tabControlRegStopReg;

        //        List<string[]> lstStr = new List<string[]>();

        //        lstStr.Add(new[] { "", "Результаты испытаний" });
        //        lstStr.Add(new[] { "Текущий режим остановлен", ReportModel.VMStatusSR.LstResultStopReg[0] });
        //        lstStr.Add(new[] { "KS", ReportModel.VMStatusSR.LstResultStopReg[1] });
        //        lstStr.Add(new[] { "KS рассчит.", ReportModel.VMStatusSR.LstResultStopReg[2] });

        //        tabControlRegStopReg = new TableClass(lstStr, "");//{ Width = 720 };

        //        return tabControlRegStopReg;
        //    }
        //}
    }
}