using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTH3_Bai7
{
    public partial class Form1 : Form
    {
        private readonly int[] seatPrices = new int[16] { 0, 5000, 5000, 5000, 5000, 5000, 6500, 6500, 6500, 6500, 6500, 8000, 8000, 8000, 8000, 8000 };
        private int[] seatStatus = new int[16];
        private Button[] seatButtons;

        public Form1()
        {
            InitializeComponent();
            SetupSeatControls();
            SetupInitialState();
            CalculateTotalPrice();
        }

        private void SetupSeatControls()
        {
            seatButtons = new Button[16];
            for (int i = 1; i <= 15; i++)
            {
                seatButtons[i] = (Button)this.Controls.Find($"btn{i}", true)[0];
                seatButtons[i].Click += SeatButton_Click;
            }
        }

        private void SetupInitialState()
        {
            for (int i = 1; i <= 15; i++)
            {
                UpdateSeatColor(i);
            }
        }

        private void UpdateSeatColor(int seatIndex)
        {
            switch (seatStatus[seatIndex])
            {
                case 0:
                    seatButtons[seatIndex].BackColor = Color.White;
                    seatButtons[seatIndex].ForeColor = Color.Black;
                    break;
                case 1:
                    seatButtons[seatIndex].BackColor = Color.Yellow;
                    seatButtons[seatIndex].ForeColor = Color.Black;
                    break;
                case 2:
                    seatButtons[seatIndex].BackColor = Color.Blue;
                    seatButtons[seatIndex].ForeColor = Color.White;
                    break;
            }
        }

        private void CalculateTotalPrice()
        {
            long totalPrice = 0;
            for (int i = 1; i <= 15; i++)
            {
                if (seatStatus[i] == 2)
                {
                    totalPrice += seatPrices[i];
                }
            }
            tbCash.Text = totalPrice.ToString("N0") + " VND";
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int seatIndex = int.Parse(clickedButton.Text);

            if (seatStatus[seatIndex] == 1)
            {
                MessageBox.Show("Vị trí này đã được bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (seatStatus[seatIndex] == 0)
            {
                seatStatus[seatIndex] = 2;
            }
            else if (seatStatus[seatIndex] == 2)
            {
                seatStatus[seatIndex] = 0;
            }

            UpdateSeatColor(seatIndex);
            CalculateTotalPrice();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            long totalMoney = 0;
            long moneyToConfirm = 0;

            for (int i = 1; i <= 15; i++)
            {
                if (seatStatus[i] == 2)
                {
                    moneyToConfirm += seatPrices[i];
                }
            }

            if (moneyToConfirm > 0)
            {
                for (int i = 1; i <= 15; i++)
                {
                    if (seatStatus[i] == 2)
                    {
                        seatStatus[i] = 1;
                        totalMoney += seatPrices[i];
                        UpdateSeatColor(i);
                    }
                }

                tbCash.Text = totalMoney.ToString("N0") + " VND";
                MessageBox.Show($"Đã xác nhận mua vé. Tổng tiền: {totalMoney.ToString("N0")} VND.", "Thanh toán thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ghế trước khi nhấn CHỌN.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCash.Text = "0 VND";
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
            {
                if (seatStatus[i] == 2)
                {
                    seatStatus[i] = 0;
                    UpdateSeatColor(i);
                }
            }
            tbCash.Text = "0 VND";
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}