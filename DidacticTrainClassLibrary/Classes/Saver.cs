using Spire.Xls;
using System.IO;
using TeamProject;

namespace DidacticTrainClassLibrary
{
    public class ExcelSaver : ISaver
    {
        public void Save(IUser usr)
        {
            Workbook workbook = new Workbook();
            if (File.Exists("Results.xlsx"))
            {
                workbook.LoadTemplateFromFile("Results.xlsx");
            }
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.InsertRow(1);
            worksheet[1, 1].Text = "Имя:";
            worksheet[1, 2].Text = "Группа:";
            worksheet[1, 3].Text = "Возраст:";
            worksheet[1, 4].Text = "Правильные ответы:";
            worksheet[2, 1].Text = $"{usr.Name}";
            worksheet[2, 2].Text = $"{usr.Group}";
            worksheet[2, 3].Text = $"{usr.Age}";
            worksheet[2, 4].Text = $"{usr.Exercise.UserCorrectAnswersCount}/{usr.Exercise.AnswerList.Count}";

            workbook.SaveToFile("Results.xlsx", ExcelVersion.Version2016);
        }
    }
}
