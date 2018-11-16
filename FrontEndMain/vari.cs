using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.IO;
using Microsoft.Win32;

namespace FrontEndMain
{
    class vari
    {
        //CONFIGURATOR SETTING VARS
        public static string DefaultDirectory;
        public static string MicaTemplateName;
        public static string StripTemplateName;
        public static string CartTemplateName;
        public static string CeramicTemplateName;
        public static string TempDir;
        public static string SMT;
        public static string SMTcart;
        public static string SMTcer;


        //QUOTING SYSTEM VARS
        public static int CustID;
        public static double p1;
        public static double p2;
        public static double p3;
        public static double p4;
        public static string pn;
        public static string SelectedCustomer;
        public static string SavedPDFDir;
        public static bool Adders;
        public static string desc;


        //CUSTOMER MANAGER VARIABLES
        public static int CustIndex;
        public static string CustSelect;
        public static string CustType;
        public static bool CustRefreshCond;
        public static bool ModCust;

        //ADDER CONFIGURATOR
        public static string AdderSelect;
        public static int AdderIndex;
        public static int AdderID;
        public static object[,] AdderArray;

        //QUOTE RECALLER
        public static int rIndex;
        public static string drvSel;
        public static string rDep;
        public static string rPre;
        public static string rTempStr;
        public static string rTempCust;
        public static int rQuoteID;
        public static string[] rQD;
        public static bool Recall;
        public static DataRowView drvSelect;
        public static DataSet RQD;

        //PART CREATION
        public static string filenumber;
        public static bool filegen;
    }

}
