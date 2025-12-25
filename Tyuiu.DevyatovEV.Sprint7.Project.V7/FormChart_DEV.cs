using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    public partial class FormChart_DEV : Form
    {
        private readonly DataTable table_DEV;

        public FormChart_DEV(DataTable table)
        {
            InitializeComponent();
            table_DEV = table;

            Text = "График распределения квартир по количеству комнат";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(800, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            DoubleBuffered = true;
            BackColor = Color.FromArgb(250, 250, 255);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (table_DEV == null || table_DEV.Rows.Count == 0)
            {
                DrawNoData(e.Graphics);
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            using Pen penAxis = new Pen(Color.FromArgb(64, 64, 64), 2);
            using Pen penBar = new Pen(Color.FromArgb(0, 102, 204), 2);
            using SolidBrush brushBar = new SolidBrush(Color.FromArgb(173, 216, 230));
            using SolidBrush brushText = new SolidBrush(Color.FromArgb(64, 64, 64));
            using Font fontTitle = new Font("Segoe UI", 12, FontStyle.Bold);
            using Font fontAxis = new Font("Segoe UI", 10, FontStyle.Regular);
            using Font fontValue = new Font("Segoe UI", 9, FontStyle.Bold);

            var groups = table_DEV.AsEnumerable()
                .GroupBy(r => r.Field<int>("RoomsCount"))
                .OrderBy(gp => gp.Key)
                .Select(gp => new
                {
                    Rooms = gp.Key,
                    Count = gp.Count()
                })
                .ToList();

            int marginLeft = 80;
            int marginTop = 70;
            int marginBottom = 100;
            int marginRight = 40;

            int chartWidth = ClientSize.Width - marginLeft - marginRight;
            int chartHeight = ClientSize.Height - marginTop - marginBottom;

            int maxCount = groups.Max(gp => gp.Count);
            if (maxCount == 0) maxCount = 1;

            // Заголовок графика
            string title = "Распределение квартир по количеству комнат";
            SizeF titleSize = g.MeasureString(title, fontTitle);
            g.DrawString(title, fontTitle, brushText,
                (ClientSize.Width - titleSize.Width) / 2, 20);

            // Оси
            g.DrawLine(penAxis,
                marginLeft,
                marginTop,
                marginLeft,
                marginTop + chartHeight);

            g.DrawLine(penAxis,
                marginLeft,
                marginTop + chartHeight,
                marginLeft + chartWidth,
                marginTop + chartHeight);

            // Шкала значений Y
            int yStepCount = 10;
            for (int i = 0; i <= yStepCount; i++)
            {
                int y = marginTop + chartHeight - (i * chartHeight / yStepCount);
                g.DrawLine(new Pen(Color.FromArgb(220, 220, 220), 1),
                    marginLeft, y, marginLeft + chartWidth, y);

                int value = maxCount * i / yStepCount;
                g.DrawString(value.ToString(), fontAxis, brushText,
                    marginLeft - 40, y - 8);
            }

            int barWidth = Math.Min(60, (chartWidth / groups.Count) - 30);
            int spacing = 30;
            int x = marginLeft + spacing;

            // Цвета для столбцов
            Color[] barColors = {
                Color.FromArgb(0, 102, 204),
                Color.FromArgb(51, 153, 255),
                Color.FromArgb(102, 178, 255),
                Color.FromArgb(153, 204, 255),
                Color.FromArgb(204, 229, 255)
            };

            int colorIndex = 0;

            foreach (var item in groups)
            {
                int barHeight = (int)((double)item.Count / maxCount * chartHeight);
                int y = marginTop + chartHeight - barHeight;

                // Столбец с градиентом
                using (SolidBrush barBrush = new SolidBrush(barColors[colorIndex % barColors.Length]))
                {
                    g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                }
                g.DrawRectangle(penBar, x, y, barWidth, barHeight);

                // Подпись количества комнат (X)
                string roomText = $"{item.Rooms} комн.";
                SizeF roomTextSize = g.MeasureString(roomText, fontAxis);
                g.DrawString(roomText, fontAxis, brushText,
                    x + barWidth / 2 - roomTextSize.Width / 2,
                    marginTop + chartHeight + 10);

                // Значение (количество квартир) над столбцом
                string valueText = item.Count.ToString();
                SizeF valueTextSize = g.MeasureString(valueText, fontValue);
                g.DrawString(valueText, fontValue, Brushes.White,
                    x + barWidth / 2 - valueTextSize.Width / 2,
                    y - 25);

                // Маленький индикатор над значением
                g.FillEllipse(Brushes.White, x + barWidth / 2 - 3, y - 30, 6, 6);

                x += barWidth + spacing;
                colorIndex++;
            }

            // Подписи осей
            g.DrawString("Количество комнат", fontTitle, brushText,
                marginLeft + chartWidth / 2 - 70,
                ClientSize.Height - 50);

            using (StringFormat sf = new StringFormat())
            {
                sf.FormatFlags = StringFormatFlags.DirectionVertical;
                g.DrawString("Количество квартир", fontTitle, brushText,
                    20, marginTop + chartHeight / 2 - 60, sf);
            }

            // Легенда
            DrawLegend(g, groups, fontAxis, marginLeft + chartWidth + 20, marginTop);
        }

        private void DrawNoData(Graphics g)
        {
            using Font font = new Font("Segoe UI", 14, FontStyle.Bold);
            using SolidBrush brush = new SolidBrush(Color.FromArgb(128, 128, 128));

            string message = "Нет данных для построения графика";
            SizeF size = g.MeasureString(message, font);

            g.DrawString(message, font, brush,
                (ClientSize.Width - size.Width) / 2,
                (ClientSize.Height - size.Height) / 2);
        }

        private void DrawLegend(Graphics g, dynamic groups, Font font, int startX, int startY)
        {
            using SolidBrush brushText = new SolidBrush(Color.FromArgb(64, 64, 64));
            using Font fontLegend = new Font("Segoe UI", 10, FontStyle.Bold);

            string legendTitle = "Легенда:";
            g.DrawString(legendTitle, fontLegend, brushText, startX, startY);

            startY += 30;

            int colorIndex = 0;
            Color[] barColors = {
                Color.FromArgb(0, 102, 204),
                Color.FromArgb(51, 153, 255),
                Color.FromArgb(102, 178, 255),
                Color.FromArgb(153, 204, 255),
                Color.FromArgb(204, 229, 255)
            };

            foreach (var item in groups)
            {
                using (SolidBrush colorBrush = new SolidBrush(barColors[colorIndex % barColors.Length]))
                {
                    g.FillRectangle(colorBrush, startX, startY, 15, 15);
                }
                g.DrawRectangle(Pens.Gray, startX, startY, 15, 15);

                string legendText = $"{item.Rooms} комнат: {item.Count} кв.";
                g.DrawString(legendText, font, brushText, startX + 25, startY - 2);

                startY += 25;
                colorIndex++;

                if (startY > ClientSize.Height - 100) break;
            }
        }

        private void FormChart_DEV_Load(object sender, EventArgs e)
        {

        }
    }
}