using AutoDefect.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace AutoDefect.Presenter
{
    public class PrintLayout
    {
        private ModelCode _modelCode;

        public void Print(PrintPageEventArgs e, DefectResultModel defectResult)
        {
            // Tentukan posisi awal cetak
            int yPos = 0;
            int xPos = 5;

            // Set font yang akan digunakan
            Font head = new Font("Arial", 10, FontStyle.Bold);
            Font fs1 = new Font("Arial", 9);
            Font fs2 = new Font("Arial", 6, FontStyle.Bold);
            Font fs3 = new Font("Arial", 7, FontStyle.Bold);


            e.Graphics.DrawString("PRODUK TIDAK LULUS INSPEKSI", head, Brushes.Black, new PointF(40, yPos));
            yPos += 20;

            // Gambar informasi model
            e.Graphics.DrawString("Model", fs1, Brushes.Black, new PointF(xPos, yPos + 13));
            yPos += 13;
            e.Graphics.DrawString(":" + defectResult.ModelNumber, fs1, Brushes.Black, new PointF(xPos + 60, yPos));
            e.Graphics.DrawString("................................", fs1, Brushes.Black, new PointF(xPos + 64, yPos + 3));

            // Data dalam tabel
            string[,] tableChecked = new string[3, 2] {
                {" Reconfrim", "Checked"},
                {" ", " "},
                {"", ""}
            };

            int Width = 48;
            int Height = 30;
            int Height1 = 20; // Tinggi untuk baris pertama kolom 3
            int Height2 = 10; // Tinggi untuk baris kedua (lebih besar dari baris 1 dan 3) kolom 1
            int Height3 = 30; // Tinggi untuk baris ketiga kolom 2
            int X = 183;
            int Y = yPos;
            int y1 = 21;

            // Gambar garis vertikal
            for (int i = 0; i <= 2; i++)
            {
                e.Graphics.DrawLine(Pens.Black, X + i * Width, Y, X + i * Width, Y + Height1 + Height2 + Height3);
            }

            // Gambar garis horizontal
            for (int i = 0; i <= 3; i++) // Menambahkan 1 baris untuk baris ketiga
            {
                int currentHeight = (i == 1) ? Height2 : ((i == 2) ? Height3 : Height1); // Menggunakan tinggi yang sesuai untuk setiap baris
                e.Graphics.DrawLine(Pens.Black, X, Y + i * currentHeight, X + Width * 2, Y + i * currentHeight);
            }

            // Gambar data tabel
            for (int row = 0; row < 3; row++) // Mengubah iterasi menjadi 3
            {
                for (int col = 0; col < 2; col++)
                {
                    float x = X + col * Width;
                    float y = y1 + row * Height; // Menggunakan tinggi yang sesuai untuk setiap baris

                    float textX = x + 8;
                    float textY = y;

                    // Geser ke tengah untuk kolom pertama pada setiap baris
                    textX += (Width - e.Graphics.MeasureString(tableChecked[row, col], fs1).Width) / 2;
                    textY += ((row == 1 || row == 2) ? Height2 : Height1) - e.Graphics.MeasureString(tableChecked[row, col], fs1).Height / 2;

                    // Geser ke kanan sedikit untuk kolom kedua
                    if (col == 1)
                    {
                        e.Graphics.DrawString(tableChecked[row, col], fs3, Brushes.Black, new PointF(textX - 3, textY));
                    }
                    else
                    {
                        e.Graphics.DrawString(tableChecked[row, col], fs3, Brushes.Black, new PointF(textX - 3, textY));
                    }
                }
            }

            e.Graphics.DrawString("SN             ", fs1, Brushes.Black, new PointF(xPos, yPos + 16));
            e.Graphics.DrawString(":" + defectResult.SerialNumber, fs1, Brushes.Black, new PointF(xPos + 60, yPos + 16));
            e.Graphics.DrawString("................................", fs1, Brushes.Black, new PointF(xPos + 64, yPos + 20));

            e.Graphics.DrawString("Time             ", fs1, Brushes.Black, new PointF(xPos, yPos + 33));
            e.Graphics.DrawString(":" + defectResult.Time, fs1, Brushes.Black, new PointF(xPos + 60, yPos + 33));
            e.Graphics.DrawString("................................", fs1, Brushes.Black, new PointF(xPos + 64, yPos + 37));

            // Gambar informasi serial number
            e.Graphics.DrawString("Date ", fs1, Brushes.Black, new PointF(xPos, yPos + 50));
            e.Graphics.DrawString(":" + defectResult.Date, fs1, Brushes.Black, new PointF(xPos + 60, yPos + 50));
            e.Graphics.DrawString("................................", fs1, Brushes.Black, new PointF(xPos + 64, yPos + 54));

            // Gambar informasi inspeksi
            e.Graphics.DrawString("Inspection          ", fs1, Brushes.Black, new PointF(xPos, yPos + 68));
            e.Graphics.DrawString(":" + defectResult.Inspector, fs1, Brushes.Black, new PointF(xPos + 60, yPos + 68));
            e.Graphics.DrawString("................................", fs1, Brushes.Black, new PointF(xPos + 64, yPos + 72));

            // Data dalam tabel
            string[,] tableData = new string[3, 2] {
                {"Problem", defectResult.Defect },
                {"Analysis", ""},
                {"Action", "" },
            };

            int cellWidth = 134;
            int cellWidth0 = 0;
            int cellHeight = 30;
            int startX = 7;
            int startY = yPos + 90;

            // Gambar garis horizontal
            for (int i = 0; i <= 3; i++)
            {
                e.Graphics.DrawLine(Pens.Black, startX, startY + i * cellHeight, startX + cellWidth * 2, startY + i * cellHeight);
            }

            // Gambar data tabel
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    float x = startX + col * (col == 0 ? cellWidth0 : cellWidth);
                    float y = startY + row * cellHeight;

                    float textX = x;
                    float textY = y;

                    string text = tableData[row, col];

                    // Jika teks terlalu panjang dan ukuran sel kecil, gunakan font yang lebih kecil
                    Font currentFont = fs1;
                    if (e.Graphics.MeasureString(text, fs1).Width > cellWidth || text.Length > 30)
                    {
                        currentFont = new Font("Arial", 8); // Ubah ukuran font menjadi lebih kecil
                    }

                    // Jika teks lebih dari karakter yang ditentukan, bagi menjadi beberapa baris
                    if (text.Length > 38)
                    {
                        string[] lines = SplitTextIntoLines(text, 38); // Fungsi untuk membagi teks menjadi beberapa baris
                        for (int i = 0; i < lines.Length; i++)
                        {
                            e.Graphics.DrawString(lines[i], currentFont, Brushes.Black, new PointF(textX - 75, textY));
                            e.Graphics.DrawString("............................................................", fs1, Brushes.Black, new PointF(textX - 75, textY + 3));
                            textY += currentFont.GetHeight();
                        }
                    }
                    else
                    {
                        textY += (cellHeight - e.Graphics.MeasureString(text, currentFont).Height) / 2;

                        e.Graphics.DrawString(text, currentFont, Brushes.Black, new PointF(textX, textY));
                    }
                    // Jika di kolom kedua, tambahkan garis putus-putus
                    if (col == 1 && (row == 1 || row == 2))
                    {
                        e.Graphics.DrawString("............................................................", fs1, Brushes.Black, new PointF(textX - 75, textY - 13));
                        e.Graphics.DrawString("............................................................", fs1, Brushes.Black, new PointF(textX - 75, textY));
                    }
                }
            }

            // Membuat barcode dari model number dan serial number
            string qrCode = $"{_modelCode.modelCode1}{defectResult.SerialNumber}";
            BarcodeWriter<Bitmap> barcodeWriter = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    //CharacterSet = "ISO-8859-1",
                    Width = 70, // Lebar QR code
                    Height = 70, // Tinggi QR code
                    Margin = 0
                }
            };
            Bitmap qrBitmap = barcodeWriter.Write(qrCode);

            // Gambar barcode di halaman cetak
            e.Graphics.DrawImage(qrBitmap, new PointF(xPos, yPos + 185)); // Sesuaikan posisi barcode sesuai kebutuhan


            // Data dalam tabel
            string[,] customTableData = new string[3, 1] {
                {"Repaired"},
                {"" },
                {"F3/2LS-PRO-003/1"}
            };

            int customWidth = 50;
            int customHeight1 = 30; // Tinggi kolom kedua
            int customHeight2 = 15; // Tinggi kolom pertama
            int customeHeight3 = 15; // TInggi kolom ketiga
            int customX = 225;
            int customY = 220;
            int customX1 = 223;
            int customY1 = 203;

            // Gambar garis vertikal
            for (int i = 0; i <= 1; i++)
            {
                e.Graphics.DrawLine(Pens.Black, customX + i * customWidth, customY, customX + i * customWidth, customY + customHeight1 + customHeight2 + customeHeight3);
            }

            // Gambar garis horizontal
            for (int i = 0; i < 3; i++) // Menambahkan 1 baris untuk baris ketiga
            {
                int currentHeight = (i == 0) ? customHeight1 : ((i == 1) ? customHeight2 : customHeight1); // Menggunakan tinggi yang sesuai untuk setiap baris
                e.Graphics.DrawLine(Pens.Black, customX, customY + i * currentHeight, customX + customWidth, customY + i * currentHeight);
            }

            // Gambar data tabel
            for (int row = 0; row < 3; row++) // Mengubah iterasi menjadi 2
            {
                for (int col = 0; col < 1; col++)
                {
                    float customXPos = customX1 + col * customWidth;
                    float customYPos = customY1 + row * customHeight1; // Menggunakan tinggi yang sesuai untuk setiap baris

                    float customTextX = customXPos;
                    float customTextY = customYPos + 10;

                    float centerX = 228;
                    customTextX += (customWidth - e.Graphics.MeasureString(customTableData[row, col], fs2).Width) / 2;
                    if (row == 2)
                    {
                        customTextX = centerX - e.Graphics.MeasureString(customTableData[row, col], fs2).Width / 2;
                    }
                    customTextY += (customHeight1 - e.Graphics.MeasureString(customTableData[row, col], fs2).Height) / 2;

                    e.Graphics.DrawString(customTableData[row, col], fs3, Brushes.Black, new PointF(customTextX, customTextY));
                }
            }
        }

        private string[] SplitTextIntoLines(string text, int maxCharactersPerLine)
        {
            List<string> lines = new List<string>();
            for (int i = 0; i < text.Length; i += maxCharactersPerLine)
            {
                lines.Add(text.Substring(i, Math.Min(maxCharactersPerLine, text.Length - i)));
            }
            return lines.ToArray();
        }
    }
}
