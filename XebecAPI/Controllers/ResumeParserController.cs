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
using Azure;
using Azure.Storage.Blobs;

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
            Console.WriteLine("Setting python Evnironment\n");
            
            //Setting up python environment
            await Installer.SetupPython();
            PythonEngine.Initialize();
            
            //Installing modules
            Installer.TryInstallPip();
            Installer.PipInstallModule("spacy==2.3.7");
            Installer.PipInstallModule("PyMuPDF");
            //Installer.PipInstallModule("spacy-look-data");
            
            dynamic spacy = PythonEngine.ImportModule("spacy");
            


            output.AppendLine("Done !! Installing Spacy");
            output.AppendLine($"Spacy version:{spacy.__version__}");

            dynamic nlp_model = spacy.load("nlp_model");

            string filename = "Alice Clark CV.pdf";

           

            string ResumeFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"CVs");

             // file is downloaded
            // check file download was success or not

            dynamic fname =
                $"{ResumeFilePath}/{filename}";
            StringBuilder text = new StringBuilder(ReadPDF(fname));
            
            // dynamic doc2 = fitz.open(fname);
            // foreach (dynamic page in doc2)
            // {
            //     text.Append(page.get_text());
            // }
            
            
            
            dynamic doc = nlp_model(text.ToString());
            string res = "{";

            foreach (dynamic ent in doc.ents)
            {
                res += $" \"{ent.label_}\" : \"{ent.text.ToString()}\",";
            }
     
            res = res.Substring(0, res.Length - 1);
            res += "}";

             var test = JObject.Parse(res);

            return test;

        }
        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] string url)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            //Download file from Blob storage

            AzureSasCredential credential = new AzureSasCredential(
                "sp=racwdli&st=2022-02-28T08:30:27Z&se=2022-03-11T16:30:27Z&sv=2020-08-04&sr=c&sig=TE%2B2VCz%2B6KKFbYHIkQwxGPOYWVUtht3xBPYZ8bE3kH4%3D");
            BlobClient blobClient = new BlobClient(new Uri(url), credential, new BlobClientOptions());


            string downloadFilePath = Environment.CurrentDirectory + @"\Resumes";

            //var res = await blobClient.DownloadToAsync(downloadFilePath);
            Console.WriteLine($">>>>>>>>>>>>>>>>>>res path{Environment.CurrentDirectory} \n\ndownloadFilePath {downloadFilePath}<<<<<<<<<<<<<<<<<");
            //return Ok("Resume bois");
            Uri uri = new Uri(url);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            string filePath = $"{downloadFilePath}/{filename}";

            var result = blobClient.DownloadTo(filePath); // file is downloaded
            // check file download was success or not
            if (result.Status == 206 || result.Status == 200)
            {
                //string ress = TestSpacy(text);
                //return Ok($"{ress}");
                // You would be knowing this by now
                //return Ok(ReadPDF(filePath));
                StringBuilder output = new StringBuilder("Running python\n");
                Console.WriteLine();

                Console.WriteLine("Running python\n");
                //output.AppendLine( await SetupPython());
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
                    $@"{downloadFilePath}\{filename}";
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
                    res += $" \"{ent.label_}\" : \"{ent.text.ToString()}\",";
                    
                }
     
                res = res.Substring(0, res.Length - 1);
                res += "}";
                Console.WriteLine(res);

                var test = JObject.Parse(res);

                return Ok(test);
            }
            return Ok($"{result.Status}");
        }
        
        
        private string ReadPDF(string filepath)
        {
            //string filePath = @"C:\Users\me\RiderProjects\Work Projects\Real\CV Resume\FixedsumeReader\ScanResume\ScanResume\Server\StaticFiles\Resumes\functionalSample.pdf";

            PdfReader reader = new PdfReader(filepath);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
            }

            reader.Close();

            return text;
        }
        
        [HttpGet("getallfiles")] //Please modify
        public string GetAllFiles(){
            string resumefolder = Environment.CurrentDirectory + @"\Resumes";
            DirectoryInfo d = new DirectoryInfo(resumefolder); //Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.pdf"); //Getting pdf files
            string str = "";
            foreach(FileInfo file in Files )
            {
                str = str + "\n " + file.Name;
            }
            return str;
        }
        
        [HttpGet("getEnv")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public string GetEnv()
        {
            try
            {
                return Environment.CurrentDirectory;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }
    }
}
