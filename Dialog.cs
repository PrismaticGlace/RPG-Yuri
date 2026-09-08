using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace RPG_Yuri {
    public class Dialog {
        

        static void CreateDoc() {

        }

        static void InsertText(string docName, string Text) {
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(docName, true));

            

        }


    }
}