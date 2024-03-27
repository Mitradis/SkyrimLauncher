using System;
using System.Collections.Generic;
using System.IO;

namespace SkyrimSELauncher
{
    public static class FuncClear
    {
        static List<string> ignoreImportList = new List<string>();
        static List<string> ingoredFoldersImportList = new List<string>();

        public static List<string> ignoreList()
        {
            return new List<string>() {
            };
        }
        static List<string> ingoredFoldersList()
        {
            return new List<string>() {
            };
        }
        public static void clearGameFolder()
        {
            ignoreImportList = ignoreList();
            string line = FuncParser.stringRead(FormMain.pathLauncherINI, "Clearing", "IgnoreList");
            if (!String.IsNullOrEmpty(line))
            {
                ignoreImportList.AddRange(line.Split(new string[] { "¦" }, StringSplitOptions.RemoveEmptyEntries));
            }
            ingoredFoldersImportList = ingoredFoldersList();
            line = FuncParser.stringRead(FormMain.pathLauncherINI, "Clearing", "FoldersIgnored");
            if (!String.IsNullOrEmpty(line))
            {
                ingoredFoldersImportList.AddRange(line.Split(new string[] { "¦" }, StringSplitOptions.RemoveEmptyEntries));
            }
            changeSeparator(ignoreImportList, FormMain.pathSeparator);
            changeSeparator(ingoredFoldersImportList, FormMain.pathSeparator);
            clearFolder(FormMain.pathGameFolder);
            ingoredFoldersImportList.Clear();
            ignoreImportList.Clear();
        }
        static void changeSeparator(List<string> list, string line)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                list[i] = list[i].Replace("|", line);
            }
        }
        static void clearFolder(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string line in Directory.EnumerateFiles(path))
                {
                    if (!ignoreImportList.Exists(s => s.StartsWith(line.Remove(0, FormMain.gameDirLength), StringComparison.OrdinalIgnoreCase)))
                    {
                        FuncFiles.deleteAny(line);
                    }
                }
                foreach (string line in Directory.EnumerateDirectories(path))
                {
                    string dirName = line.Remove(0, FormMain.gameDirLength);
                    if (!ignoreImportList.Exists(s => s.StartsWith(dirName, StringComparison.OrdinalIgnoreCase)))
                    {
                        FuncFiles.deleteAny(line);
                    }
                    else if (!ingoredFoldersImportList.Exists(s => s.Equals(dirName, StringComparison.OrdinalIgnoreCase)))
                    {
                        clearFolder(line);
                    }
                }
                if (Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0)
                {
                    FuncFiles.deleteAny(path);
                }
            }
        }
    }
}