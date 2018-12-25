﻿/* ============================================================================== 
* 功能描述：MyConfig 
* 创 建 者：全国祥
* 联系方式：13826503059
* 创建日期：2018/12/21 14:53:56 
* ==============================================================================*/


using System.IO;

namespace ExcelToLua.Res
{
    public class MyConfig
    {
        /// <summary>
        /// 配置表目录
        /// </summary>
        public static string excelDir = "excels/";
        /// <summary>
        /// 导出lua目录
        /// </summary>
        public static string luaDir = "luas/";

        public static string xlsx = ".xlsx";
        public static string xls = ".xls";


        public static string dirfile = "temp/dir.txt";

        //关联表的关键字
        public static string linkTable = "L:";

        static string[] columnStr = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


        public static void ReadDir()
        {
            string str = File.ReadAllText(Res.MyConfig.dirfile);
            if (!string.IsNullOrEmpty(str))
            {
                string[] liststr = str.Split('\n');
                Res.MyConfig.excelDir = liststr[0];
                Res.MyConfig.luaDir = liststr[1];
            }
            else
            {
                Res.MyConfig.excelDir = System.Environment.CurrentDirectory +"/"+ Res.MyConfig.excelDir;
                Res.MyConfig.luaDir = System.Environment.CurrentDirectory +"/"+ Res.MyConfig.luaDir;
                Res.MyConfig.excelDir = Res.MyConfig.excelDir.Replace("\\", "/");
                Res.MyConfig.luaDir = Res.MyConfig.luaDir.Replace("\\", "/");
            }
        }
        /// <summary>
        /// 改变Excel目录
        /// </summary>
        /// <param name="exceldir"></param>
        /// <param name="luadir"></param>
        public static void ChangedExcelDir(string excel)
        {
            excelDir = excel.Replace("\\", "/") + "/"; 
            string str = excelDir + "\n" + luaDir;
            File.WriteAllText(dirfile, str);
        }

        /// <summary>
        /// 改变Lua目录
        /// </summary>
        /// <param name="exceldir"></param>
        /// <param name="luadir"></param>
        public static void ChangedLuaDir( string lua)
        {
            luaDir = lua.Replace("\\", "/") +"/";
            string str = excelDir + "\n" + luaDir;
            File.WriteAllText(dirfile, str);
        }

        /// <summary>
        /// 获取配置表全局路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFullExcelFile(string fileName)
        {
            return excelDir + fileName + xlsx;
        }

        public static string ColumnToA_Z(int column)
        {
            string A_Z = "";
            int A = column / 26 - 1;
            int B = (column - 1) % 26;
            if (A >= 0)
            {
                A_Z = columnStr[A] + columnStr[B];
            }
            else
            {
                A_Z = columnStr[B];
            }

            return A_Z;
        }
    }
}
