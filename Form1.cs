using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 디데이 //DateTimePicker 컨트롤을 이용한 디데이 계산기
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("T"); 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) //날짜를 선택할 수 있는 달력 형태
        {
            textBox1.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd"); //선택된 날짜를 텍스트 박스에 표시
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") //목표일 이름이 설정되지 않은 경우 메시지 창이 나옴
            {
                MessageBox.Show("목표일과 목표일 이름을 입력하였는지 확인해주세요!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //확인
            }
            else // 목표일 이름이 설정된 경우 현재 날짜에서 선택된 날짜의 차이를 빼서 목표일 이름과 함께 보여줌
            {
                int ts = -(DateTime.Now - dateTimePicker1.Value).Days;
                ts = ts + 1;

                if (DateTime.Now.Date == dateTimePicker1.Value.Date) //dateTimePicker에서 오늘 날짜를 선택한 경우
                {
                    lblResult.Text = textBox1.Text +  " D-DAY 입니다.";
                }
                else // 그 외
                {
                    lblResult.Text = textBox1.Text + " " + textBox2.Text + "까지 " + ts + "일 남았습니다.";
                }
            }
        }
    }
}
