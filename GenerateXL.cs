﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Scholar_Bowl {
    public class GenerateXL {

        public static void ThisPlayer(object o) {
            Player player = (Player)o;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            ws.Name = player.Name;

            Range header = ws.get_Range("A1", "D1");
            header.Borders[XlBordersIndex.xlEdgeBottom].Color = 0;
            header.Font.Bold = true;

            ws.Cells[1, 1] = "Date";
            ws.Cells[1, 2] = "Tossups";
            ws.Cells[1, 3] = "Games played";
            ws.Cells[1, 4] = "Average per game";

            int r = 2;
            foreach (var v in MatchList.AllMatches.GetForEachDate(player)) {
                ws.Cells[r, 1] = v.Key;
                ws.Cells[r, 2] = v.Value[0];
                ws.Cells[r, 3] = v.Value[1];
                if ((v.Value[0] + v.Value[1]) != 0) {
                    ws.Cells[r, 4] = "=B" + r + "/C" + r;
                }
                r++;
            }

            int last = r;
            r--;

            Range total = ws.get_Range("A" + last, "D" + last);
            total.Borders[XlBordersIndex.xlEdgeTop].Color = System.Drawing.Color.Black.ToArgb();
            total.Font.Bold = true;

            ws.Cells[last, 1] = "Total";
            ws.Cells[last, 2] = "=SUM(B2:B" + r + ")";
            ws.Cells[last, 3] = "=SUM(C2:C" + r + ")";
            ws.Cells[last, 4] = "=B" + last + "/C" + last;

            Range avg = ws.get_Range("D1", "D" + last);
            avg.NumberFormat = "##,###.00";

            ((Range)ws.Columns[1]).EntireColumn.ColumnWidth = 12;
            ((Range)ws.Columns[3]).EntireColumn.ColumnWidth = 12.5;
            ((Range)ws.Columns[4]).EntireColumn.ColumnWidth = 16;
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects();
            ChartObject chartObj = chartObjs.Add(470, 20, 350, 300);
            Chart xlChart = chartObj.Chart;
            xlChart.ChartType = XlChartType.xlLine;

            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Average Tossups per Day";

            Axis a = (Axis)xlChart.Axes(
                XlAxisType.xlValue, XlAxisGroup.xlPrimary);
            a.HasTitle = true;
            a.AxisTitle.Text = "Average Tossups";

            a = (Axis)xlChart.Axes(
                XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            a.HasTitle = true;
            a.AxisTitle.Text = "Date";

            SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection();

            Series series2 = seriesCollection.NewSeries();
            series2.Name = "Tossups";
            series2.XValues = ws.Range["A2", "A" + r];
            series2.Values = ws.Range["D2", "D" + r];
            xlApp.Visible = true;
        }

        /*

        public static void ThisTeam(object o) {
            Team t = (Team)o;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            ws.Name = "Sheet 1"; //comboBox4.SelectedItem.ToString() + " - " + comboBox5.SelectedItem.ToString();

            Range header = ws.get_Range("A1", "E1");
            header.Font.Bold = true;
            header.Borders[XlBordersIndex.xlEdgeBottom].Color = System.Drawing.Color.Black.ToArgb();
            ws.Cells[1, 1] = "Date";
            ws.Cells[1, 2] = "Wins";
            ws.Cells[1, 3] = "Losses";
            ws.Cells[1, 4] = "% Win";
            ws.Cells[1, 5] = "% Loss";

            int r = 2;

            foreach (var v in Event.GetForEachDate(t.Events)) {
                ws.Cells[r, 1] = v.Key;
                ws.Cells[r, 2] = v.Value[0];
                ws.Cells[r, 3] = v.Value[1];
                if ((v.Value[0] + v.Value[1]) != 0) {
                    ws.Cells[r, 4] = "=B" + r + "/(B" + r + "+C" + r + ")";
                    ws.Cells[r, 5] = "=C" + r + "/(B" + r + "+C" + r + ")";
                }
                r++;
            }

            int last = r;
            r--;

            Range percents = ws.get_Range("D2", "E" + last);
            percents.NumberFormat = "###,##.00%";

            Range total = ws.get_Range("A" + last, "E" + last);
            total.Borders[XlBordersIndex.xlEdgeTop].Color = System.Drawing.Color.Black.ToArgb();
            total.Font.Bold = true;

            ws.Cells[last, 1] = "Total";
            ws.Cells[last, 2] = "=SUM(B2:B" + r + ")";
            ws.Cells[last, 3] = "=SUM(C2:C" + r + ")";
            ws.Cells[last, 4] = "=B" + last + "/(B" + last + "+C" + last + ")";
            ws.Cells[last, 5] = "=C" + last + "/(B" + last + "+C" + last + ")";

            ((Range)ws.Columns[1]).EntireColumn.ColumnWidth = 11;
            ((Range)ws.Columns[2]).EntireColumn.ColumnWidth = 9;
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects();
            ChartObject chartObj = chartObjs.Add(470, 20, 350, 300);
            Chart xlChart = chartObj.Chart;
            xlChart.ChartType = XlChartType.xlLine;

            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Wins/Losses per Day";

            Axis a = (Axis)xlChart.Axes(
                XlAxisType.xlValue, XlAxisGroup.xlPrimary);
            a.HasTitle = true;
            a.AxisTitle.Text = "Percentage";

            a = (Axis)xlChart.Axes(
                XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            a.HasTitle = true;
            a.AxisTitle.Text = "Date";

            SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection();

            Series series2 = seriesCollection.NewSeries();
            series2.Name = "Wins";
            series2.XValues = ws.Range["A2", "A" + r];
            series2.Values = ws.Range["D2", "D" + r];

            Series series3 = seriesCollection.NewSeries();
            series3.Name = "Losses";
            series3.XValues = ws.Range["A2", "A" + r];
            series3.Values = ws.Range["E2", "E" + r];

            xlApp.Visible = true;
        }

        */

        public static void AllPlayers(object o) {
            List<Player> players = (List<Player>)o;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            ws.Name = "Player Rankings"; //comboBox4.SelectedItem.ToString() + " - " + comboBox5.SelectedItem.ToString();

            Range header = ws.get_Range("A1", "F1");
            header.Font.Bold = true;
            header.Borders[XlBordersIndex.xlEdgeBottom].Color = System.Drawing.Color.Black.ToArgb();
            ws.Cells[1, 1] = "Rank";
            ws.Cells[1, 2] = "Name";
            ws.Cells[1, 3] = "School";
            ws.Cells[1, 4] = "Tossups";
            ws.Cells[1, 5] = "Games";
            ws.Cells[1, 6] = "Tossups/Game";

            int r = 2;
            int rank = 0;
            players.Sort((a, b) => a.CompareTo(b));
            decimal lastAvg = -2;
            decimal lastGames = -2;
            foreach (Player p in players) {
                decimal avg = MatchList.AllMatches.GetAverage(p);
                decimal games = MatchList.AllMatches.GetGamesPlayed(p);
                if (avg != lastAvg) {
                    rank++;
                }
                else {
                    if (lastGames > games) {
                        rank++;
                    }
                }
                ws.Cells[r, 1] = rank;
                ws.Cells[r, 2] = p.Name;
                ws.Cells[r, 3] = p.Team.School.Name + " - " + p.Team.Name;
                decimal tossups = MatchList.AllMatches.GetTotalTossups(p);
                ws.Cells[r, 4] = tossups;
                ws.Cells[r, 5] = games;
                if (games > 0) {
                    ws.Cells[r, 6] = "=D" + r + "/E" + r;
                }
                r++;
                lastAvg = avg;
                lastGames = games;
            }

            Range dec = ws.get_Range("E2", "F" + r);
            dec.NumberFormat = "0.000";

            ((Range)ws.Columns[1]).EntireColumn.ColumnWidth = 5;
            ((Range)ws.Columns[2]).EntireColumn.ColumnWidth = 20;
            ((Range)ws.Columns[3]).EntireColumn.ColumnWidth = 30;
            ((Range)ws.Columns[6]).EntireColumn.ColumnWidth = 13;

            xlApp.Visible = true;
        }

        public static void AllTeams(object o) {
            List<Team> teams = (List<Team>)o;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            ws.Name = "Team Rankings"; //comboBox4.SelectedItem.ToString() + " - " + comboBox5.SelectedItem.ToString();

            Range header = ws.get_Range("A1", "F1");
            header.Font.Bold = true;
            header.Borders[XlBordersIndex.xlEdgeBottom].Color = System.Drawing.Color.Black.ToArgb();
            ws.Cells[1, 1] = "Rank";
            ws.Cells[1, 2] = "Team";
            ws.Cells[1, 3] = "Wins";
            ws.Cells[1, 4] = "Losses";
            ws.Cells[1, 5] = "Win %";
            ws.Cells[1, 6] = "Loss %";

            int r = 2;
            int rank = 0;
            teams.Sort((a, b) => a.CompareTo(b));
            decimal lastAvg = -2;
            decimal lastGames = -2;
            foreach (Team t in teams) {
                decimal avg = MatchList.AllMatches.GetAverageWins(t);
                decimal wins = MatchList.AllMatches.GetWins(t);
                decimal losses = MatchList.AllMatches.GetLosses(t);
                decimal games = wins + losses;
                if (avg != lastAvg) {
                    rank++;
                }
                else {
                    if (lastGames > games) {
                        rank++;
                    }
                }
                ws.Cells[r, 1] = rank;
                ws.Cells[r, 2] = t.School.Name + " - " + t.Name;
                ws.Cells[r, 3] = wins;
                ws.Cells[r, 4] = losses;
                if (games > 0) {
                    ws.Cells[r, 5] = "=C" + r + "/(C" + r + " + D" + r + ")";
                    ws.Cells[r, 6] = "=D" + r + "/(C" + r + " + D" + r + ")";
                }
                r++;
                lastAvg = avg;
                lastGames = games;
            }

            Range dec = ws.get_Range("E2", "F" + r);
            dec.NumberFormat = "0.00%";

            ((Range)ws.Columns[1]).EntireColumn.ColumnWidth = 5;
            ((Range)ws.Columns[2]).EntireColumn.ColumnWidth = 40;

            xlApp.Visible = true;
        }
    }
}