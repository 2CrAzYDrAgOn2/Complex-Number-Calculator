using System.Numerics;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        public double realPart, imaginaryPart, modulus, argument;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// calculateButton_Click ��������� �������� �� ������ "���������"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // �������� ��������� ������������� ��������
                realPart = EvaluateExpression(realTextBox);
                imaginaryPart = EvaluateExpression(imaginaryTextBox);
                Complex complexNumber = new(realPart, imaginaryPart);// ������� ����������� �����
                modulus = Complex.Abs(complexNumber);// ��������� ������
                argument = Math.Atan2(complexNumber.Imaginary, complexNumber.Real);// ��������� ������� ��������
                // ������� ����������
                modulusLabel.Text = "������: " + modulus.ToString();
                argumentLabel.Text = "������� ��������: " + argument.ToString();
                if (modulusLabel.Text.Contains("\u221E") || argumentLabel.Text.Contains("\u221E"))
                {
                    modulusLabel.Text = "�� ���� ������ ������";
                    argumentLabel.Text = "�� ���� ������ ������";
                    MessageBox.Show("�� ���� ������ ������");
                }
                MessageBox.Show("������� ��������!"); // ����� ���������
                realTextBox.ForeColor = Color.Black; // ��������� ������ � realTextBox �� ������
                imaginaryTextBox.ForeColor = Color.Black; // ��������� ������ � imaginaryTextBox �� ������
            }
            catch (Exception ex)
            {
                MessageBox.Show("������: " + ex.Message); // ����� ������
            }
        }

        /// <summary>
        /// clearButton_Click ��������� �������� �� ������� ������ "��������"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            realPart = imaginaryPart = modulus = argument = 0.0; // ������� ��������� ���������� double
            realTextBox.Text = imaginaryTextBox.Text = string.Empty; // ������� textBox
            realTextBox.ForeColor = imaginaryTextBox.ForeColor = Color.Black; // ��������� ����� textBox �� ������
        }

        /// <summary>
        /// wordButton_Click ��������� �������� �� ������� ������ "�������� � Word"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wordButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new(); // �������� ������� Word
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add(); // �������� ������ ��������� Word
            if (modulusLabel.Text == "�� ���� ������ ������" || argumentLabel.Text == "�� ���� ������ ������")
            {
                doc.Paragraphs[1].Range.Text = "�� ���� ������ ������"; // ����� ������
            }
            else
            {
                doc.Paragraphs[1].Range.Text = "�������� �����: " + realPart + "\n������ �����: " + imaginaryPart + "\n������: " + modulus + "\n��������: " + argument; // ����� ������
            }
            word.Visible = true;
        }

        /// <summary>
        /// excelButton_Click ��������� �������� �� ������ "�������� � Excel"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excelButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new(); // �������� ������� Excel
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(); // �������� ����� ����� Excel
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet; // ����� ��������� �����
            // ����� ������ �� ������
            if (modulusLabel.Text == "�� ���� ������ ������" || argumentLabel.Text == "�� ���� ������ ������")
            {
                sheet.Cells[1, 1].Value = "�� ���� ������ ������";
            }
            else
            {
                sheet.Cells[1, 1].Value = "�������� �����: ";
                sheet.Cells[2, 1].Value = "������ �����: ";
                sheet.Cells[3, 1].Value = "������: ";
                sheet.Cells[4, 1].Value = "��������: ";
                sheet.Cells[1, 2].Value = realPart;
                sheet.Cells[2, 2].Value = imaginaryPart;
                sheet.Cells[3, 2].Value = modulus;
                sheet.Cells[4, 2].Value = argument;
            }
            sheet.Columns.AutoFit(); // ������������ ��������
            sheet.Rows.AutoFit(); // ������������ �����
            excel.Visible = true;
        }

        /// <summary>
        /// exitButton_Click ��������� �������� �� ������ "�����"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // ����� �� ����������
        }

        /// <summary>
        /// EvaluateExpression ����������� ��������� � �����
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static double EvaluateExpression(TextBox expression)
        {
            try
            {
                expression.Text = expression.Text.Replace(" ", ""); // �������� �������� �� ���������
                System.Data.DataTable dt = new(); // �������� ������� ��� ���������� �������������� ���������
                var result = dt.Compute(expression.Text, ""); // ���������� �������������� ���������
                return Convert.ToDouble(result); // ������� ����������
            }
            catch (Exception ex)
            {
                expression.ForeColor = Color.Red; // ������ ���� ������ �� �������
                expression.Text = "0"; // �������� �����
                MessageBox.Show($"������ � {expression}: " + ex.Message + "��� ���� � �������� ���� �������� �� 0"); // ����� ������
                return 0.0; // ������� ����
            }
        }

        /// <summary>
        /// realTextBox_KeyPress ��������� �������� �� ������� ������ �� ����� ����������� �� realTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void realTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // ������������� ���������� ��������� ������� ������� Enter
                imaginaryTextBox.Focus(); // ��������� ����� �� ������ TextBox
            }
        }

        /// <summary>
        /// imaginaryTextBox_KeyPress ��������� �������� �� ������� ������ �� ����� ����������� �� imaginaryTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imaginaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // ������������� ���������� ��������� ������� ������� Enter
                calculateButton.PerformClick(); // ��������� ��������, ����������� ������� ������
            }
        }
    }
}