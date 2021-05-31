using System;
using System.Windows.Forms;

namespace Lesson4
{

    // объявление своего собственного делегата(аналог процедурного типа в  Delphi):
    public delegate int MathOperation(int x, int y);

    public partial class MainForm : Form
    {
        //Общение с пользователем
        private Action<object> ByToUser;
        private Action<object> HelloToUser;


        #region Form
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Составим план приветствия
            HelloToUser += (s) => MessageBox.Show("Привет!");  //лямбда-выражение
            HelloToUser += (s) =>                              //лямбда-метод
            {
                MessageBox.Show("Представляем Вашему вниманию наш супер-калькулятор!");
            };

            // Составим план трогательной истории прощания
            ByToUser += SayResult;
            ByToUser += SayBestRegars;
            ByToUser += SayBay;
            ByToUser += (s) => {
                MessageBox.Show("И это было последнее ...");
            };

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //Поприветствуем пользователя через 2 лямбды
            HelloToUser(sender);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Расскажем пользователю трогательную историю прощания...
            ByToUser(sender);
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region MathOperation
        private void btnMathOperation_Click(object sender, EventArgs e)
        {
            //btnMathOperation_ClickCustomDlg(sender, e); //работаем через свой собственный делегат
            btnMathOperation_ClickFunc(sender, e);        //работаем через стандартный делегат
        }


        // применение стандартного делегата Func:
        private void btnMathOperation_ClickFunc(object sender, EventArgs e)
        {
            Func<int, int, int> currMathOperation = null;
            Button ClickedBtn = (sender as Button);

            if (ClickedBtn.Text == "+")
            {
                currMathOperation = Add;
            }
            else if (ClickedBtn.Text == "-")
            {
                currMathOperation = Sub;
            };

            lblOperationName.Text = ClickedBtn.Text;
            int Result;
            Result = currMathOperation(Int32.Parse(txtOperand1.Text), Int32.Parse(txtOperand2.Text));
            txtResult.Text = Result.ToString();
        }


        // применение своего собственного делегата:
        private void btnMathOperation_ClickCustomDlg(object sender, EventArgs e)
        {
            MathOperation currMathOperation = null;
            Button ClickedBtn = (sender as Button);

            if (ClickedBtn.Text == "+")
            {
                currMathOperation = new MathOperation(Add);
            }
            else if (ClickedBtn.Text == "-")
            {
                currMathOperation = new MathOperation(Sub);
            };

            lblOperationName.Text = ClickedBtn.Text;
            int Result;
            Result = currMathOperation(Int32.Parse(txtOperand1.Text), Int32.Parse(txtOperand2.Text));
            txtResult.Text = Result.ToString();
        }

        private int Add(int x, int y)
        {
            return (x + y);
        }

        private int Sub(int x, int y)
        {
            return (x - y);
        }
        #endregion

        #region ByToUser
        private void SayHello(object sender)
        {
            MessageBox.Show("И снова здаствуйте!");
        }

        private void SayResult(object sender)
        {
            MessageBox.Show("Результат последней операции был =" + txtResult.Text);
        }

        private void SayBestRegars(object sender)
        {
            MessageBox.Show("Ваше мнение очень важно для нас! Оставьте отзыв на нашем сайте!");
        }

        private void SayBay(object sender)
        {
            MessageBox.Show("До новых встреч!");
        }
        #endregion

    }


}
