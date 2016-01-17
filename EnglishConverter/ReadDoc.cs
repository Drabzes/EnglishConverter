using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Packaging;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace EnglishConverter
{
    class ReadDoc
    {
        

        public void findbolt()
        {
              
        }

        public static List<Engelswoodje> getWordDescription(string path)
        {
            //EngelswoordjeCol woordjesCol = new EngelswoordjeCol();
            List<Engelswoodje> woordjesCol = new List<Engelswoodje>();

            System.IO.Packaging.Package wordPackage = Package.Open(path, FileMode.Open, FileAccess.Read);
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(wordPackage))
            {
                Body body = wordDocument.MainDocumentPart.Document.Body;
                if (body != null)
                {
                    foreach (Paragraph par in body.Descendants<Paragraph>())
                    {
                        List<string> list = new List<string>();
                        string zin = par.InnerText;

                        foreach (Run run in par.Descendants<Run>())
                        {
                            //voor elke prop in een woordje
                            foreach (RunProperties props in run.Descendants<RunProperties>())
                            {
                                // elk woordje dat vet is zoeken
                                if (props.Bold != null)
                                {
                                    list.Add(run.InnerText);
                                    //engels woordje uit de zin halen en vervangen door ..... (puntjes)
                                    zin = Swapwoordjes.swap(run.InnerText, zin);
                                }
 
                            }       
                        }
                        //elke regel die niet leeg is.
                        if ( !par.InnerText.Equals(""))
                        {
                            //kijken wat het eerste woordje is
                            int i = 0;
                            //voor elk woordje dat gevonden is toevoegen aan engelsewoordjecol
                            foreach ( string woord in list)
                            {
                                i++;
                                if( i == 1)
                                {
                                    Engelswoodje wor = new Engelswoodje(woord, "", zin);
                                    woordjesCol.Add(wor);
                                }else
                                {
                                    i++;
                                    Engelswoodje wor = new Engelswoodje(woord, "");
                                    woordjesCol.Add(wor);
                                }
                            }
                        }
                    }
                }
            }
            return woordjesCol;
        }
    }
}
