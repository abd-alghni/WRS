using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WRS.Dtos;
using WRS.Services.Reports;
using WRS.ViewModels;

namespace WRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly WRSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // Insert a table into a word processing document.
        /*        public static void CreateTable(string fileName, CreateReportDto dto)
                {
                    // Use the file name and path passed in as an argument 
                    // to open an existing Word 2007 document.

                    using (WordprocessingDocument doc
                        = WordprocessingDocument.Open(fileName, true))
                    {
                        // Create an empty table.
                        Table table = new Table();

                        // Create a TableProperties object and specify its border information.
                        TableProperties tblProp = new TableProperties(
                            new TableBorders(
                                new TopBorder()
                                {
                                    Val =
                                    new EnumValue<BorderValues>(BorderValues.Dashed),
                                    Size = 10
                                },
                                new BottomBorder()
                                {
                                    Val =
                                    new EnumValue<BorderValues>(BorderValues.Dashed),
                                    Size = 10
                                },
                                new LeftBorder()
                                {
                                    Val =
                                    new EnumValue<BorderValues>(BorderValues.Dashed),
                                    Size = 10
                                },
                                new RightBorder()
                                {
                                    Val =
                                    new EnumValue<BorderValues>(BorderValues.Dashed),
                                    Size = 10
                                },
                                new InsideHorizontalBorder()
                                {
                                    Val =
                                    new EnumValue<BorderValues>(BorderValues.Dashed),
                                    Size = 10
                                },
                                new InsideVerticalBorder()
                                {
                                    Val =
                                    new EnumValue<BorderValues>(BorderValues.Dashed),
                                    Size = 10
                                }
                            )
                        );

                        // Append the TableProperties object to the empty table.
                        table.AppendChild<TableProperties>(tblProp);

                        // Create a row.
                        TableRow tr = new TableRow();

                        // Create a cell.
                        TableCell tc1 = new TableCell();

                        // Specify the width property of the table cell.
                        tc1.Append(new TableCellProperties(
                            new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "7000" }));

                        // Specify the table cell content.
                        //       tc1.Append(new Paragraph(new Run(new Text(dto.DataSource))));

                        // Append the table cell to the table row.
                        tr.Append(tc1);

                        // Create a second table cell by copying the OuterXml value of the first table cell.
                        TableCell tc2 = new TableCell();

                        // Specify the width property of the table cell.
                        tc2.Append(new TableCellProperties(
                            new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

                        // Specify the table cell content.
                        //      tc2.Append(new Paragraph(new Run(new Text(dto.Date.ToString()))));
                        // Append the table cell to the table row.
                        tr.Append(tc2);

                        // Append the table row to the table.
                        table.Append(tr);

                        // Append the table to the document.
                        doc.MainDocumentPart.Document.Body.Append(table);
                    }
                }
        */
        /*[HttpPost("ImportFile")]
        public async Task<IActionResult> ImportFile()
        {
            var files = Request.Form.Files;
            if (!files.Any())
            {
                return BadRequest();
            }
            //upload file
            var file = files.FirstOrDefault();
            string fileName = await Helper.FileHelper.Upload(file);

            //read file
            string path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);
            var word = WordprocessingDocument.Open(path, true);
            var paragraphs = word.MainDocumentPart.Document.Body.Descendants<Paragraph>().ToList();
            var table = word.MainDocumentPart.RootElement.Descendants<Table>().ToList();
            var rows = table[0].Elements<TableRow>().ToList();
            var dta = new List<Report>();

            return Ok(dta);
        }*/

        /*[HttpPost("ExportDataToWord")]
        public async Task<IActionResult> ExportDataToWord(CreateReportDto dto)
        {
            var data = new Data()
            {
                Date = DateTime.Now,
                Query = dto.Query,
                DataSource = dto.DataSource,
            };

            var path = Path.Combine(Directory.GetCurrentDirectory(), "templates", "templates.docx");
            CreateTable(path, dto);



            using (WordprocessingDocument wordDoc1 = WordprocessingDocument.Open(path, false))
            using (WordprocessingDocument wordDoc2 = WordprocessingDocument.Open(newPath, true))
            {
                ThemePart themePart1 = wordDoc1.MainDocumentPart.ThemePart;
                ThemePart themePart2 = wordDoc2.MainDocumentPart.ThemePart;

                using (StreamReader streamReader = new StreamReader(themePart1.GetStream()))
                using (StreamWriter streamWriter = new StreamWriter(themePart2.GetStream(FileMode.Create)))
                {
                    streamWriter.Write(streamReader.ReadToEnd());
                }
            }


            byte[] files;

            using (var word = WordprocessingDocument.Open(path, true))
            {
                var number = word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Number»"));
                if (number != null)
                {
                    word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Number»")).Text = data.Number;
                }
                var date = word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Date»"));
                if (date != null)
                {
                    word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Date»")).Text = data.Date.ToString();
                }
                var company = word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Company»"));
                if (company != null)
                {
                    word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Company»")).Text = data.Company;
                }
                var address = word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Address»"));
                if (address != null)
                {
                    word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Address»")).Text = data.Address;
                }
                var contactPerson = word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Contact person»"));
                if (contactPerson != null)
                {
                    word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«string»")).Text = data.str;
                }
                var str = word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«string»"));
                if (str != null)
                {
                    word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(x => x.Text.Contains("«Contact person»")).Text = data.ContactPerson;
                }

                string exportName = $"Export_{Guid.NewGuid()}.docx";
                string newPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", exportName);


                word.SaveAs(newPath);
                files = System.IO.File.ReadAllBytes(newPath);

            }


            return Ok();
            return File(
                fileContents: files,
                contentType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileDownloadName: "tem.docx"
                );


        }*/

        /*[HttpGet]
        public IActionResult QueryBuild(Query SqlQuery)
        {
            return Ok();
        }*/

        [HttpPost("GetAllReports")]
        public async Task<IActionResult> GetAll()
        {
            var reports = await _reportService.GetAllReports();
            return Ok(reports);
        }

            [HttpPost("Create")]
        public async Task<IActionResult> CreateReport(CreateReportDto dto)
        {
            var report = _reportService.CreateReport(dto);
            return Ok(report);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateReport(UpdateReportDto Id)
        {
            var report = await _reportService.UpdateReport(Id);
            return Ok(report);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteReport(int Id)
        {
            var report = await _reportService.DeleteReport(Id);
            return Ok(report);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetReport(int id)
        {
            var report = await _reportService.GetReport(id);
            return Ok(report);
        }
    }
}
