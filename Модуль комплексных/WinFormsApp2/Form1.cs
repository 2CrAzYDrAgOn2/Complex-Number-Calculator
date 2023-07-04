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
        /// calculateButton_Click выполняет действия по кнопке "Вычислить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // получаем введенные пользователем значения
                realPart = EvaluateExpression(realTextBox);
                imaginaryPart = EvaluateExpression(imaginaryTextBox);
                Complex complexNumber = new(realPart, imaginaryPart);// создаем комплексное число
                modulus = Complex.Abs(complexNumber);// вычисляем модуль
                argument = Math.Atan2(complexNumber.Imaginary, complexNumber.Real);// вычисляем главный аргумент
                // выводим результаты
                modulusLabel.Text = "Модуль: " + modulus.ToString();
                argumentLabel.Text = "Главный аргумент: " + argument.ToString();
                if (modulusLabel.Text.Contains("\u221E") || argumentLabel.Text.Contains("\u221E"))
                {
                    modulusLabel.Text = "На ноль делить нельзя";
                    argumentLabel.Text = "На ноль делить нельзя";
                    MessageBox.Show("На ноль делить нельзя");
                }
                MessageBox.Show("Рассчёт выполнен!"); // вывод сообщения
                realTextBox.ForeColor = Color.Black; // изменение текста в realTextBox на черный
                imaginaryTextBox.ForeColor = Color.Black; // изменение текста в imaginaryTextBox на черный
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message); // вывод ошибки
            }
        }

        /// <summary>
        /// clearButton_Click выполняет действия по нажатию кнопки "Очистить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            realPart = imaginaryPart = modulus = argument = 0.0; // очистка публичных переменных double
            realTextBox.Text = imaginaryTextBox.Text = string.Empty; // очистка textBox
            realTextBox.ForeColor = imaginaryTextBox.ForeColor = Color.Black; // изменение цвета textBox на черный
        }

        /// <summary>
        /// wordButton_Click выполняет действия по нажатию кнопки "Показать в Word"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wordButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new(); // создание объекта Word
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add(); // создание нового документа Word
            if (modulusLabel.Text == "На ноль делить нельзя" || argumentLabel.Text == "На ноль делить нельзя")
            {
                doc.Paragraphs[1].Range.Text = "На ноль делить нельзя"; // вывод текста
            }
            else
            {
                doc.Paragraphs[1].Range.Text = "Реальная часть: " + realPart + "\nМнимая часть: " + imaginaryPart + "\nМодуль: " + modulus + "\nАргумент: " + argument; // вывод текста
            }
            word.Visible = true;
        }

        /// <summary>
        /// excelButton_Click выполняет действия по кнопке "Показать в Excel"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excelButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new(); // создание объекта Excel
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(); // создание новой книги Excel
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet; // выбор активного листа
            // вывод текста на ячейку
            if (modulusLabel.Text == "На ноль делить нельзя" || argumentLabel.Text == "На ноль делить нельзя")
            {
                sheet.Cells[1, 1].Value = "На ноль делить нельзя";
            }
            else
            {
                sheet.Cells[1, 1].Value = "Реальная часть: ";
                sheet.Cells[2, 1].Value = "Мнимая часть: ";
                sheet.Cells[3, 1].Value = "Модуль: ";
                sheet.Cells[4, 1].Value = "Аргумент: ";
                sheet.Cells[1, 2].Value = realPart;
                sheet.Cells[2, 2].Value = imaginaryPart;
                sheet.Cells[3, 2].Value = modulus;
                sheet.Cells[4, 2].Value = argument;
            }
            sheet.Columns.AutoFit(); // выравнивание столбцов
            sheet.Rows.AutoFit(); // выравнивание строк
            excel.Visible = true;
        }

        /// <summary>
        /// exitButton_Click выполняет действия по кнопке "Выйти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // выход из приложения
        }

        /// <summary>
        /// EvaluateExpression преобразует выражения в числа
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static double EvaluateExpression(TextBox expression)
        {
            try
            {
                expression.Text = expression.Text.Replace(" ", ""); // удаление пробелов из выражения
                System.Data.DataTable dt = new(); // создание объекта для вычисления математических выражений
                var result = dt.Compute(expression.Text, ""); // вычисление математических выражений
                return Convert.ToDouble(result); // возврат результата
            }
            catch (Exception ex)
            {
                expression.ForeColor = Color.Red; // меняет цвет текста на красный
                expression.Text = "0"; // обнуляет текст
                MessageBox.Show($"Ошибка в {expression}: " + ex.Message + "Все поля с ошибками были заменены на 0"); // вывод ошибки
                return 0.0; // возврат нуля
            }
        }

        /// <summary>
        /// realTextBox_KeyPress выполняет действие по нажатию кнопки во время фокусировки на realTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void realTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // предотвращает дальнейшую обработку нажатия клавиши Enter
                imaginaryTextBox.Focus(); // переводит фокус на другой TextBox
            }
        }

        /// <summary>
        /// imaginaryTextBox_KeyPress выполняет действие по нажатию кнопки во время фокусировки на imaginaryTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imaginaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // предотвращает дальнейшую обработку нажатия клавиши Enter
                calculateButton.PerformClick(); // выполняет действие, аналогичное нажатию кнопки
            }
        }
    }
}