using AutoDefect.Model;
using AutoDefect.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDefect.View
{
    public partial class DetailDefectView : Form, IDetailDefectView
    {
        private DefectResultModel defectResult;
        private PrintModeModel printMode;
        private PrintLayout _printLayout;
        private TabControlView tabControl;
        private string modelCode;
        private int defectId;
        private int partId;
        private string inspectorId;
        private string message;
        public string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        public string currentTime = DateTime.Now.ToString("HH:mm:ss");

        public DetailDefectView()
        {
            InitializeComponent();
            printMode = new PrintModeModel();  // Inisialisasi printMode
            defectResult = new DefectResultModel();  // Inisialisasi defectResult
            _printLayout = new PrintLayout(new ModelCode());
            tabControl = new TabControlView();
            AssociateAndRaiseViewEvents();
        }


        public string SerialNumber 
        {
            get { return textSerial.Text; }
            set { textSerial.Text = value; }
        }
        public string ModelCode 
        {
            get { return modelCode; }
            set { modelCode = value; }
        }
        public string ModelNumber 
        { 
            get { return textModelNumber.Text; }
            set { textModelNumber.Text = value; }
        }
        public int DefectId 
        {
            get { return defectId; }
            set {  defectId = value; }
        }
        public string DefectName 
        {
            get { return textDefect.Text; }
            set { textDefect.Text = value; }
        }
        public string InspectorId 
        {
            get { return inspectorId; }
            set { inspectorId = value; }
        }
        public string InspectorName 
        {
            get { return TextInspector.Text; }
            set { TextInspector.Text = value; }
        }
        public string Message 
        {
            get { return message; }
            set { message = value; }
        }
        public int Location
        {
            get { return int.Parse(textLocation.Text); }
            set { textLocation.Text = value.ToString(); }
        }

        public int PartId 
        {
            get => partId;
            set => partId = value;
        }
        public string PartName 
        {
            get => labelPart.Text; 
            set => labelPart.Text = value;
        }

        public event EventHandler SaveEvent;
        public event EventHandler DataSaved;

        public void OnDataSaved()
        {
            DataSaved?.Invoke(this, EventArgs.Empty);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnPrint.Click += delegate
            {

                string mode = printMode.GetMode();

                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (mode == "on")
                {

                    defectResult.ModelNumber = ModelNumber;
                    defectResult.SerialNumber = SerialNumber;
                    defectResult.Time = currentTime;
                    defectResult.Date = currentDate;
                    defectResult.Inspector = InspectorName;
                    defectResult.Defect = DefectName;

                    ShowPrintPreviewDialog(defectResult);
                  
                    this.Hide();
                }
                else
                {
                    tabControl.StatusText = "Data berhasil tersimpan, print dalam mode OFF";
                    this.Close();
                }

            };

            btnCancle.Click += delegate
            {
                this.Close();
            };
        }

        public void ShowPrintPreviewDialog(DefectResultModel defectResult)
        {
            // Membuat PrintDocument baru
            PrintDocument pd = new PrintDocument();

            // Menambahkan event handler untuk PrintPage
            pd.PrintPage += (s, e) => _printLayout.Print(e, defectResult);

            // Membuat PrintPreviewDialog dan menetapkan PrintDocument-nya
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pd;

            // Menampilkan dialog preview cetak
            //printPreviewDialog.ShowDialog();
            pd.Print();
        }

        private static DetailDefectView instance;
        public static DetailDefectView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new DetailDefectView();
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}
