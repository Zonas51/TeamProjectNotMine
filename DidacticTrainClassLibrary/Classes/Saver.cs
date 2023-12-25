using DidacticTrainClassLibrary.Classes;
using DidacticTrainClassLibrary.Interfaces;
using Spire.Xls;
using System.IO;

namespace DidacticTrainClassLibrary
{
    public class ExcelSaver : ISaver
    {
        public void Save(IStatistics statistics)
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
            worksheet[1, 5].Text = "Тип задания:";
            worksheet[2, 1].Text = $"{statistics.User.Name}";
            worksheet[2, 2].Text = $"{statistics.User.Group}";
            worksheet[2, 3].Text = $"{statistics.User.Age}";
            worksheet[2, 4].Text = $"{statistics.UserCorrectAnswersCount}/{statistics.AllAnswersCount}";
            worksheet[2, 5].Text = $"{statistics.ExName}";

            workbook.SaveToFile("Results.xlsx", ExcelVersion.Version2016);
        }
    }
}
