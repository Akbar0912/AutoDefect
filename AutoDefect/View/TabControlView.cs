using AutoDefect.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoDefect.Presenter.TabControlPresenter;
using static AutoDefect.View.ITabControlView;

namespace AutoDefect.View
{
    public partial class TabControlView : UserControl, ITabControlView
    {
        private string inspectorId;
        private string latestReceivedData;
        private bool disableEvent = false;
        private bool buttonClickedOnce = false;
        private TCPConnection connection;

        public TabControlView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        public string SerialNumber
        {
            get { return textBoxSerial.Text; }
            set { textBoxSerial.Text = value; }
        }
        public string ModelCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }
        public string ModelNumber
        {
            get { return textBoxNumber.Text; }
            set { textBoxNumber.Text = value; }
        }
        public string InspectorId
        {
            get { return inspectorId; }
            set { inspectorId = value; }
        }
        public string Inspector
        {
            get { return textBoxInspector.Text; }
            set { textBoxInspector.Text = value; }
        }
        public string StatusText
        {
            get { return textBoxStatus.Text; }
            set { textBoxStatus.Text = value; }
        }
        public bool IsKeyboardEnabled
        {
            get { return true; }
            set { }
        }
        public Color BackColorStatus
        {
            get { return textBoxStatus.BackColor; }
            set { textBoxStatus.BackColor = value; }
        }
        public Color ForeColorStatus
        {
            get { return textBoxStatus.ForeColor; }
            set { textBoxStatus.ForeColor = value; }
        }

        public DateTime SelectedDate => dt.Value;

        public string DefectName => textBoxSearch.Text;

        public event EventHandler<ITabControlView.ModelEventArgs> SearchModelNumber;
        public event EventHandler ClearEvent;
        public event TopDefectEventHandler DefectFilterEvent;
        public event EventHandler EditButtonClicked;
        public event EventHandler CellClicked;
        public event KeyEventHandler KeyDownEvent;
        public event EventHandler SearchFilter;
        public event EventHandler CheckProperties;

        private void AssociateAndRaiseViewEvents()
        {
            //Clear
            btnClear.Click += delegate
            {
                if (buttonClickedOnce)
                {
                    ClearEvent?.Invoke(this, EventArgs.Empty);
                    textBoxSerial.Focus();
                }
                else
                {
                    textBoxStatus.Text = "";
                    textBoxStatus.BackColor = SystemColors.Control;
                    //textBoxSerial.Text = "";
                    //textBoxNumber.Text = "";
                    //textBoxCode.Text = "";
                }
                textBoxStatus.BackColor = SystemColors.Control;
            };

            btnSearch.Click += (sender, e) =>
            {
                SearchFilter?.Invoke(sender, e);
            };

            btnPrintManual.Click += delegate
            {
                if (!buttonClickedOnce)
                {
                    disableEvent = true;
                    btnPrintManual.BackColor = Color.FromArgb(122, 178, 178);
                    btnPrintManual.ForeColor = Color.White;
                    btnPrintManual.Text = "Auto Print";
                    textBoxSerial.ReadOnly = false;
                    textBoxSerial.Focus();

                    SerialNumber = "";
                    ModelNumber = "";
                    ModelCode = "";

                    buttonClickedOnce = true;
                }
                else
                {
                    disableEvent = false;
                    btnPrintManual.BackColor = Color.FromArgb(77, 134, 156);
                    btnPrintManual.ForeColor = Color.White;
                    textBoxStatus.Text = "";
                    textBoxStatus.BackColor = SystemColors.Control;
                    btnPrintManual.Text = "Print Manual";
                    textBoxSerial.ReadOnly = true;

                    SerialNumber = "";
                    ModelNumber = "";
                    ModelCode = "";

                    buttonClickedOnce = false;
                }
            };

            btnA.Click += delegate
            {
                ChangeColorButton(btnA, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnA.Tag.ToString()));
            };

            btnB.Click += delegate
            {
                ChangeColorButton(btnB, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnB.Tag.ToString()));
            };

            btnC.Click += delegate
            {
                ChangeColorButton(btnC, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnC.Tag.ToString()));
            };

            btnD.Click += delegate
            {
                ChangeColorButton(btnD, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnD.Tag.ToString()));
            };

            btnE.Click += delegate
            {
                ChangeColorButton(btnE, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnE.Tag.ToString()));
            };

            btnF.Click += delegate
            {
                ChangeColorButton(btnF, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnF.Tag.ToString()));
            };

            btnG.Click += delegate
            {
                ChangeColorButton(btnG, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnG.Tag.ToString()));
            };

            btnH.Click += delegate
            {
                ChangeColorButton(btnH, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnH.Tag.ToString()));
            };

            btnI.Click += delegate
            {
                ChangeColorButton(btnI, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnI.Tag.ToString()));
            };

            btnJ.Click += delegate
            {
                ChangeColorButton(btnJ, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnJ.Tag.ToString()));
            };

            btnK.Click += delegate
            {
                ChangeColorButton(btnK, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnK.Tag.ToString()));
            };

            btnL.Click += delegate
            {
                ChangeColorButton(btnL, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnL.Tag.ToString()));
            };

            btnM.Click += delegate
            {
                ChangeColorButton(btnM, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnM.Tag.ToString()));
            };

            btnN.Click += delegate
            {
                ChangeColorButton(btnN, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnN.Tag.ToString()));
            };

            btnO.Click += delegate
            {
                ChangeColorButton(btnO, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnO.Tag.ToString()));
            };

            btnP.Click += delegate
            {
                ChangeColorButton(btnP, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnP.Tag.ToString()));
            };

            btnQ.Click += delegate
            {
                ChangeColorButton(btnQ, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnQ.Tag.ToString()));
            };

            btnR.Click += delegate
            {
                ChangeColorButton(btnR, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnR.Tag.ToString()));
            };

            btnS.Click += delegate
            {
                ChangeColorButton(btnS, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnS.Tag.ToString()));
            };

            btnT.Click += delegate
            {
                ChangeColorButton(btnT, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnT.Tag.ToString()));
            };

            btnU.Click += delegate
            {
                ChangeColorButton(btnU, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnU.Tag.ToString()));
            };

            btnV.Click += delegate
            {
                ChangeColorButton(btnV, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnV.Tag.ToString()));
            };

            btnW.Click += delegate
            {
                ChangeColorButton(btnW, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnW.Tag.ToString()));
            };

            btnX.Click += delegate
            {
                ChangeColorButton(btnX, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnX.Tag.ToString()));
            };

            btnY.Click += delegate
            {
                ChangeColorButton(btnY, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnY.Tag.ToString()));
            };

            btnZ.Click += delegate
            {
                ChangeColorButton(btnZ, null);
                DefectFilterEvent?.Invoke(this, EventArgs.Empty, int.Parse(btnZ.Tag.ToString()));
            };

            textBoxSerial.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(textBoxSerial.Text))
                {
                    textBoxStatus.Text = "...";
                }
            };

            textBoxSerial.KeyDown += (sender, e) =>
            {
                KeysConverter keysConverter = new KeysConverter();
                if (e.KeyCode == Keys.Enter)
                {
                    latestReceivedData = textBoxSerial.Text;
                    SerialNumber = latestReceivedData.Substring(2);
                    ModelCode = latestReceivedData.Substring(0, 2);
                    PerformModelSearch();

                }
                else
                {
                    // Akumulasi karakter hingga tombol Enter ditekan
                    string character = keysConverter.ConvertToString(e.KeyCode);
                    latestReceivedData += character;
                }
            };

            dataGridView1.CellContentClick += (sender, e) =>
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                var selectedPerson = selectedRow.DataBoundItem as DefectModel;
                CheckProperties?.Invoke(this, new EventArgs());
            };

            dataGridView1.RowPostPaint += (sender, e) =>
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                row.Cells["No"].Value = (e.RowIndex + 1).ToString();
                row.Cells["No"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            };

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 60;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal; // Change to your desired color
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 16);
            dataGridView1.RowTemplate.Height = 50;

            dataGridView2.RowPostPaint += (sender, e) =>
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                int totalRows = dataGridView2.Rows.Count;
                row.Cells["No2"].Value = (totalRows - e.RowIndex).ToString();
                row.Cells["No2"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            };

            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18, FontStyle.Bold);
            dataGridView2.ColumnHeadersHeight = 40;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal; // Change to your desired color
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 16);
            dataGridView2.RowTemplate.Height = 50;

            timer1.Tick += delegate
            {
                labelDate.Text = DateTime.Now.ToLongDateString();
                labelTime.Text = DateTime.Now.ToLongTimeString();
            };

            btnClear2.Click += delegate
            {
                textBoxSearch.Text = "";
                textBoxSearch.Focus();
                dt.Text = DateTime.Now.ToString();
                SearchFilter?.Invoke(this, EventArgs.Empty);
            };
        }

        private void ChangeColorButton(object sender, EventArgs e)
        {
            foreach (Control c in Panel3.Controls)
            {
                c.BackColor = Color.FromArgb(77, 134, 156);
            }
            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(122, 178, 178);
        }

        private void PerformModelSearch()
        {
            // Raise the event with the data from the view
            SearchModelNumber?.Invoke(this, new ModelEventArgs(SerialNumber));
        }

        public void UpdateCodeBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxCode.InvokeRequired)
            {
                textBoxCode.Invoke((MethodInvoker)(() => UpdateCodeBox(message)));
            }
            else
            {
                textBoxCode.Text = message;
            }
            PerformModelSearch();
        }
        public void UpdateSerialBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxSerial.InvokeRequired)
            {
                textBoxSerial.Invoke((MethodInvoker)(() => UpdateSerialBox(message)));
            }
            else
            {
                textBoxSerial.Text = message;
            }

        }

        public void AddNoData()
        {
            // Clear existing data source
            dataGridView1.DataSource = null;

            // Bersihkan semua baris yang ada di DataGridView
            dataGridView1.Rows.Clear();

            dataGridView1.Columns[0].HeaderText = "No Data";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void RemoveNoData(BindingSource defectList)
        {
            // Bersihkan semua baris yang ada di DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.RowPostPaint += (sender, e) =>
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                row.Cells["No"].Value = (e.RowIndex + 1).ToString();
                row.Cells["No"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            };
            dataGridView1.Columns[0].HeaderText = "No";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // Set nilai DataSource menjadi null untuk menghapus sumber data
            SetDefectListBindingSource(defectList);
        }

        public void SelectTabPageByIndex(int data)
        {
            if (data >= 0 && data < tabControl1.TabPages.Count)
            {
                tabControl1.SelectedIndex = data;
            }
        }

        public void SetDefectListBindingSource(BindingSource defectList)
        {
            dataGridView1.DataSource = defectList;
        }

        public void SetDefectListBindingSource2(BindingSource resultList)
        {
            dataGridView2.DataSource = resultList;
        }

        public void ShowPopupForm()
        {
            DetailDefectView popupForm = new DetailDefectView();
            popupForm.ShowDialog();
        }

        private async void TabControlView_Load(object sender, EventArgs e)
        {
            timer1.Start();
            connection = new TCPConnection(UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await connection.ConnectToServerAsync();
        }

        private void textBoxSerial_TextChanged(object sender, EventArgs e)
        {
            if (!disableEvent)
            {
                if (textBoxSerial.Text != null)
                {
                    textBoxStatus.Text = "...";
                    textBoxStatus.BackColor = Color.Orange;
                }
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchFilter?.Invoke(sender, e);
            }

        }

        private void dt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchFilter?.Invoke(sender, e);
            }
        }
    }
}
