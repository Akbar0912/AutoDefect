using AutoDefect.Model;
using AutoDefect.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private PrinterTypeModel _printerType;
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
            _printerType = new PrinterTypeModel();
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
            set { defectId = value; }
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
                if (mode == "on" || mode == "preview")
                {

                    defectResult.ModelNumber = ModelNumber;
                    defectResult.SerialNumber = SerialNumber;
                    defectResult.Time = currentTime;
                    defectResult.Date = currentDate;
                    defectResult.Inspector = InspectorName;
                    defectResult.Defect = DefectName;

                    string printerType = _printerType.GetPrinterType();
                    ShowPrintPreviewDialog(defectResult,printerType);

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

        public void ShowPrintPreviewDialog(DefectResultModel defectResult, string printerName)
        {
            string mode = printMode.GetMode();
            string printerType = _printerType.GetPrinterType();

            // Membuat PrintDocument baru
            PrintDocument pd = new PrintDocument();

            if (!string.IsNullOrEmpty(printerName))
            {
                pd.PrinterSettings.PrinterName = printerName;
            }

            // Menambahkan event handler untuk PrintPage
            pd.PrintPage += (s, e) => _printLayout.Print(e, defectResult);

            // Membuat PrintPreviewDialog dan menetapkan PrintDocument-nya
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pd;

            if (mode == "preview")
            {
                // Menampilkan dialog preview cetak
                printPreviewDialog.Load += (s, e) =>
                {
                    // Mengakses PrintPreviewControl menggunakan refleksi
                    PrintPreviewControl printPreviewControl = FindPrintPreviewControl(printPreviewDialog);

                    if (printPreviewControl != null)
                    {
                        printPreviewControl.Zoom = 2.0; // Mengatur zoom 200%
                    }

                    // Mengatur posisi jendela ke tengah layar
                    printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
                    printPreviewDialog.WindowState = FormWindowState.Maximized;
                };

                // Menampilkan dialog preview cetak
                printPreviewDialog.ShowDialog();
            }
            else
            {
                pd.Print();
            }
        }

        private PrintPreviewControl FindPrintPreviewControl(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is PrintPreviewControl previewControl)
                {
                    return previewControl;
                }
                else
                {
                    PrintPreviewControl foundControl = FindPrintPreviewControl(control);
                    if (foundControl != null)
                    {
                        return foundControl;
                    }
                }
            }
            return null;
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

        private void DetailDefectView_Load(object sender, EventArgs e)
        {
        }
    }
}
