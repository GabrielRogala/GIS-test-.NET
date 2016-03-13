using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GIS_test1.Models;
using System.IO;

namespace GIS_test1.Controllers
{
    public static class Finder
    {
        public static List<Dir> FindDirs(string path) {
            return Find(path,false);
        }

        public static List<Dir> FindFiles(string path)
        {
            return Find(path,true);
        }

        private static List<Dir> Find(string path, bool file) {
            var dirs = new List<Dir> { };
            string[] directories;

            if (file) { 
                directories = Directory.GetFiles(path); 
            } else { 
                directories = Directory.GetDirectories(path); 
            }

            foreach (string dir in directories)
            {
                dirs.Add(new Dir { Name = Path.GetFileName(dir), Path = dir });
            }

            return dirs;
        }
    }
}