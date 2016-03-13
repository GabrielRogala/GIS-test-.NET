using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_test1.Controllers
{
    public static class Deleter
    {
        public static string Delete(string directoryPath, string fileName)
        {
            string mess = "";

            if (System.IO.File.Exists(directoryPath+"/"+fileName)){
                System.IO.File.Delete(directoryPath + "/" + fileName);
                mess = "usunięto plik \"" + fileName + "\" z katalogu \"" + directoryPath + "\"";
            }else{
                mess = "Plik \"" + fileName + "\" nie istnieje";
            }

            return mess;
        }
    }
}