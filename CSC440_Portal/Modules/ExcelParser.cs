using CSC440_Project.Models;
using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace CSC440_Project.Modules
{
    public static class ExcelParser
    {
        public static void ProcessFile(Stream inputStream)
        {
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(inputStream);

            DataSet result = excelReader.AsDataSet();

            ParseDataSet(result);

            excelReader.Close();
        }

        private static void ParseDataSet(DataSet result)
        {
            //each data set should have x tables, we need to get each one of these, but only certain ones for now
            var worksheets = result.Tables;

            //we are only interested in the first two tables for now
            ParseOccupationalGroups(worksheets[1]);
            ParseDetailedOccupation(worksheets[2]);
        }

        private static void ParseDetailedOccupation(DataTable table)
        {
            var context = new AppDbContext();

            for(int i = 3; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                if(row[0].ToString() == "")
                {
                    break;
                }

                //get the correct parent group up front, otherwise the system complains because
                //it doesn't want to do the lambda expression and put all the list in memory
                var groupList = context.OccupationalGroups.ToList();
                var parentGroup = groupList.FirstOrDefault(g => g.GroupName == row[3].ToString());

                var occupation = new DetailedOccupation()
                {
                    OccupationalCode = row[1].ToString(),
                    Title = row[2].ToString(),
                    OccupationalGroup = parentGroup,
                    CurrentEmployment = (int)Math.Round(Convert.ToDecimal(row[4])),
                    FutureEmployment = (int)Math.Round(Convert.ToDecimal(row[5])),
                    NumberChange = (int)Math.Round(Convert.ToDecimal(row[6])),
                    PercentageChange = Convert.ToDouble(row[7]),
                    OpeningsAndReplacementsGrowth = (int)Math.Round(Convert.ToDecimal(row[8]))
                };

                try
                {
                    var existingOccupation = context.DetailedOccupations.FirstOrDefault(o => o.Title == occupation.Title);

                    if (existingOccupation == null)
                    {
                        context.DetailedOccupations.Add(occupation);
                    }

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    //TODO: send the user to an error page with the correct error details
                }
            }
        }

        private static void ParseOccupationalGroups(DataTable table)
        {
            var context = new AppDbContext();

            //we want to make sure we ignore the first few rows...they are just the title (and the first row, it is just the TOTAL)
            for (int i = 3; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                //if you are at the end of the Excel file, don't continue
                if (row[0].ToString() == "")
                {
                    break;
                }

                var group = new OccupationalGroup()
                {
                    //a lot of casting going on here due to issues with the source data
                    OccupationalCode = row[1].ToString(),
                    GroupName = row[2].ToString(),
                    CurrentEmploymentNumber = (int)Math.Round(Convert.ToDecimal(row[3])),
                    FutureEmploymentNumber = (int)Math.Round(Convert.ToDecimal(row[4])),
                    PercentChange = Convert.ToDouble(row[5]),
                    NumberChange = (int)Math.Round(Convert.ToDecimal(row[6])),
                    Replacements = (int)Math.Round(Convert.ToDecimal(row[7])),
                    Openings = (int)Math.Round(Convert.ToDecimal(row[8])),
                    MedianAnnualWage = (int)Math.Round(Convert.ToDecimal(row[9]))
                };

                try
                {
                    var existingGroup = context.OccupationalGroups.FirstOrDefault(g => g.GroupName == group.GroupName);

                    if (existingGroup == null)
                    {
                        context.OccupationalGroups.Add(group);
                    }

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    //TODO: send the user to an error page with the correct error details
                }
            }
        }
    }
}