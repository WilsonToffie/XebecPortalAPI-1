using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Included;
using Python.Runtime;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json.Linq;

namespace XebecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeParserController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        public async Task<JObject> Test()
        {
            StringBuilder output = new StringBuilder("Running python\n");
            Console.WriteLine();

            Console.WriteLine("Running python\n");
           //output.AppendLine(await SetupPython());
            //Console.WriteLine();
            //output.AppendLine(await InstallSpacy());


            Console.WriteLine("Setting python Evnironment\n");

            await Installer.SetupPython();
            PythonEngine.Initialize();
            dynamic sys = PythonEngine.ImportModule("sys");

            Console.WriteLine("Done !! Setting python Evnironment\n");
            output.AppendLine("Done !! Setting python Evnironment\n");
            output.AppendLine($"Python version:{sys.version}");

            await Installer.SetupPython();
            Installer.TryInstallPip();
            Installer.PipInstallModule("spacy==2.3.7");
            //Installer.PipInstallModule("spacy-look-data");
            PythonEngine.Initialize();
            dynamic spacy = PythonEngine.ImportModule("spacy");


            output.AppendLine("Done !! Installing Spacy");
            output.AppendLine($"Spacy version:{spacy.__version__}");

            dynamic nlp_model = spacy.load("nlp_model");
            Installer.PipInstallModule("PyMuPDF");
            dynamic fitz = PythonEngine.ImportModule("fitz");



            dynamic fname =
                @"C:\Users\Kian\Source\Repos\XebecPortalAPI\XebecAPI\CVs\Alice Clark CV.pdf";
            dynamic doc2 = fitz.open(fname);

            StringBuilder text = new StringBuilder();

            foreach (dynamic page in doc2)
            {
                text.Append(page.get_text());
            }

            dynamic doc = nlp_model(text.ToString());
            string res = "{";

            foreach (dynamic ent in doc.ents)
            {
                res += $" \"{ent.label_.upper()}\" : \"{ent.text.ToString()}\",";
            }
     
            res = res.Substring(0, res.Length - 1);
            res += "}";

             var test = JObject.Parse(res);

            return test;

        }
    }
}
