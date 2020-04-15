using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using Pdb014App.Models.PDB;
using Pdb014App.Models.PDB.ConductorModels;
using Pdb014App.Models.PDB.InsulatorModels;
using Pdb014App.Models.PDB.PoleModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.AuditModule
{
    public class AuditController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public void ImportExportModel(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

        }

        private readonly PdbDbContext _context;

        public AuditController(PdbDbContext context)
        {
            _context = context;
        }


        public IActionResult Audit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostImport(IFormFile file)
        {

            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine("wwwroot\\ImportExport", file.FileName);
                var stream = new FileStream(fullPath, FileMode.Create);

                file.CopyTo(stream);
                stream.Position = 0;
                if (sFileExtension == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                }
                else
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                }

                #region Export Error Data

                string sWebRootFolder = "wwwroot\\ImportExport";
                string sFileName = @"demo.xlsx";
                var memory = new MemoryStream();
                var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write);

                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Demo");

                IRow rowe = excelSheet.CreateRow(0);

                int errorCount = 0;

                #endregion

                LookUpConductorType dtRow;


                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;

                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    dtRow = new LookUpConductorType();

                    if (row.GetCell(0) == null || row.GetCell(1) == null)
                    {
                        if (errorCount == 0)
                        {
                            rowe.CreateCell(0).SetCellValue("ID");
                            rowe.CreateCell(1).SetCellValue("Name");
                            rowe.CreateCell(2).SetCellValue("Comments");

                            rowe = excelSheet.CreateRow(1);
                            rowe.CreateCell(0).SetCellValue(row.GetCell(0) != null ? row.GetCell(0).ToString() : " ");
                            rowe.CreateCell(1).SetCellValue(row.GetCell(1) != null ? row.GetCell(1).ToString() : " ");
                            rowe.CreateCell(2).SetCellValue("Some Data can not be empty");

                        }
                        else
                        {
                            rowe = excelSheet.CreateRow(errorCount + 1);
                            rowe.CreateCell(0).SetCellValue(row.GetCell(0) != null ? row.GetCell(0).ToString() : " ");
                            rowe.CreateCell(1).SetCellValue(row.GetCell(1) != null ? row.GetCell(1).ToString() : " ");
                            rowe.CreateCell(2).SetCellValue("Some Data can not be empty");
                        }
                        errorCount++;
                        continue;
                    }

                    dtRow.ConductorTypeId = row.GetCell(0).ToString();
                    dtRow.ConductorTypeName = row.GetCell(1).ToString();
                    _context.LookUpConductorType.Add(dtRow);
                    _context.SaveChanges();
                }

                if (errorCount > 0)
                {
                    workbook.Write(fs);
                    var streame = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open);
                    await streame.CopyToAsync(memory);
                    memory.Position = 0;
                    return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
                }

            }
            else
            {
                return View("Audit");
            }

            return View("Audit");
        }

        public async Task<IActionResult> PoleDataImport(IFormFile file)
        {

            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine("wwwroot\\ImportExport", file.FileName);
                var streamRead = new FileStream(fullPath, FileMode.Create);

                file.CopyTo(streamRead);
                streamRead.Position = 0;

                if (sFileExtension == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(streamRead); //This will read the Excel 97-2000 formats  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                }
                else
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(streamRead); //This will read 2007 Excel format  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                }

                #region Export Error Data

                string sWebRootFolder = "wwwroot\\ImportExport";
                string sFileName = @"PoleError.xlsx";
                var memory = new MemoryStream();
                var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write);

                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("PoleError");
                IRow rowe = excelSheet.CreateRow(0);
                int errorCount = 0;


                #endregion


                TblPole poleItems;
                TblCrossArmInfo crossArmItems;
                //TblInsulatorDisk diskItems;
                //TblInsulatorPinAndPost pinPostItems;
                //TblInsulatorShackleOrGuy shackleOrGuyItems;

                TblInsulator insulator;
                TblGuy guy;



                for (int i = (sheet.FirstRowNum + 7); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    poleItems = new TblPole();


                    try
                    {
                        #region Pole Insert
                        
                        var wireCondition = 1;
                        if (row.GetCell(20).ToString() == "M")
                        {
                            wireCondition = 2;
                        }
                        else if (row.GetCell(20).ToString() == "B")
                        {
                            wireCondition = 3;
                        }

                        poleItems.PoleId = row.GetCell(2).ToString();
                        poleItems.SurveyDate = Convert.ToDateTime(row.GetCell(43).ToString());
                        poleItems.RouteCode = "201040101"; //Route Id
                        poleItems.FeederLineId = "20104010108"; //FeederLineId
                        poleItems.SurveyorName = row.GetCell(46).ToString();
                        poleItems.PoleNo = row.GetCell(2).ToString();
                        poleItems.PreviousPoleNo = row.GetCell(3).ToString();
                        poleItems.Latitude = Convert.ToDecimal(row.GetCell(44).NumericCellValue.ToString());
                        poleItems.Longitude = Convert.ToDecimal(row.GetCell(45).NumericCellValue.ToString());
                        poleItems.PoleTypeId = row.GetCell(12) != null ? row.GetCell(12).ToString() : " ";
                        poleItems.PoleConditionId = row.GetCell(13) != null ? row.GetCell(13).ToString() : " ";
                        poleItems.LineTypeId = Convert.ToInt32(row.GetCell(14).ToString());
                        poleItems.BackSpan = row.GetCell(15) != null ? row.GetCell(15).ToString() : " ";
                        poleItems.TypeOfWireId = row.GetCell(16) != null
                            ? Convert.ToInt32(row.GetCell(16).ToString())
                            : (int?) null;
                        poleItems.NoOfWireHt =
                            row.GetCell(17) != null ? Convert.ToInt32(row.GetCell(17).ToString()) : 0;
                        poleItems.NoOfWireLt =
                            row.GetCell(18) != null ? Convert.ToInt32(row.GetCell(18).ToString()) : 0;
                        poleItems.WireLength =
                            row.GetCell(19) != null ? Convert.ToDecimal(row.GetCell(19).ToString()) : 0;
                        poleItems.WireConditionId = wireCondition;
                        poleItems.MSJNo = row.GetCell(21) != null ? row.GetCell(21).ToString() : " ";
                        poleItems.SleeveNo = row.GetCell(22) != null ? row.GetCell(22).ToString() : " ";
                        poleItems.TwistNo = row.GetCell(23) != null ? row.GetCell(23).ToString() : " ";
                        poleItems.PhaseAId = row.GetCell(24) != null ? row.GetCell(24).ToString() : " ";
                        poleItems.PhaseBId = row.GetCell(25) != null ? row.GetCell(25).ToString() : " ";
                        poleItems.PhaseCId = row.GetCell(26) != null ? row.GetCell(26).ToString() : " ";
                        poleItems.Neutral = row.GetCell(27) != null ? row.GetCell(27).ToString() : " ";
                        poleItems.StreetLight = row.GetCell(28) != null ? row.GetCell(28).ToString() : " ";

                        poleItems.TransformerExist = row.GetCell(38) != null ? row.GetCell(38).ToString() : " ";
                        poleItems.CommonPole = row.GetCell(40) != null ? row.GetCell(40).ToString() : " ";
                        poleItems.Tap = row.GetCell(39) != null ? row.GetCell(39).ToString() : " ";

                        _context.TblPole.Add(poleItems);
                        await _context.SaveChangesAsync();
                        #endregion

                        #region for cross arm
                                              
                        int fettingConditionId = 1;

                        if (row.GetCell(31).ToString() == "M")
                        {
                            fettingConditionId = 2;
                        }
                        else if (row.GetCell(31).ToString() == "B")
                        {
                            fettingConditionId = 3;
                        }

                       

                        if (row.GetCell(29).ToString().Contains(",") || row.GetCell(30).ToString().Contains(","))
                        {

                            string[] typesOfArmsId = row.GetCell(29).ToString().Split(new char[] {','});

                            string[] NoOfArms = row.GetCell(30).ToString().Split(new char[] {','});

                            for (int j = 0; j < typesOfArmsId.Length; j++)
                            {
                                crossArmItems = new TblCrossArmInfo();
                                crossArmItems.PoleId = row.GetCell(2).ToString();
                                crossArmItems.TypeOfFittingsId = Convert.ToInt32(typesOfArmsId[j]);
                                crossArmItems.NoOfSetFittings = Convert.ToInt32(NoOfArms[j]);
                                crossArmItems.FittingsConditionId = fettingConditionId;
                                crossArmItems.Materials = "A";
                                _context.TblCrossArmInfo.Add(crossArmItems);
                                await _context.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            crossArmItems = new TblCrossArmInfo();
                            crossArmItems.PoleId = row.GetCell(2).ToString();
                            crossArmItems.TypeOfFittingsId = Convert.ToInt32(row.GetCell(29).ToString());
                            crossArmItems.NoOfSetFittings = Convert.ToInt32(row.GetCell(30).ToString());
                            crossArmItems.FittingsConditionId = fettingConditionId;
                            crossArmItems.Materials = "A";
                            _context.TblCrossArmInfo.Add(crossArmItems);
                            await _context.SaveChangesAsync();
                        }
                        #endregion 

                        #region for insulator
                        if (row.GetCell(32).ToString()!=null) { 
                        int insulatorConditionId = 1;

                        if (row.GetCell(34).ToString() == "M")
                        {
                            insulatorConditionId = 2;
                        }
                        else if (row.GetCell(34).ToString() == "B")
                        {
                            insulatorConditionId = 3;
                        }

                        if (row.GetCell(32).ToString().Contains(",") || row.GetCell(33).ToString().Contains(","))
                        {

                            string[] typesOfInsulatorId = row.GetCell(32).ToString().Split(new char[] {','});

                            string[] NoOfInsulator = row.GetCell(33).ToString().Split(new char[] {','});

                            for (int j = 0; j < typesOfInsulatorId.Length; j++)
                            {
                                insulator = new TblInsulator();
                                insulator.PoleId = row.GetCell(2).ToString();
                                insulator.InsulatorTypeId = Convert.ToInt32(typesOfInsulatorId[j]);
                                insulator.Quantity = Convert.ToInt32(NoOfInsulator[j]);
                                insulator.ConditionId = insulatorConditionId;

                                _context.TblInsulator.Add(insulator);
                                await _context.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            insulator = new TblInsulator();
                            insulator.PoleId = row.GetCell(2).ToString();
                            insulator.InsulatorTypeId = Convert.ToInt32(row.GetCell(32).ToString());
                            ;
                            insulator.Quantity = Convert.ToInt32(row.GetCell(33).ToString());
                            ;
                            insulator.ConditionId = insulatorConditionId;

                            _context.TblInsulator.Add(insulator);
                            await _context.SaveChangesAsync();
                        }
                    }
                        #endregion
                         
                        #region Guy
                        if (row.GetCell(35) != null)
                        {

                            int guyConditionId = 1;

                        if (row.GetCell(37).ToString() == "M")
                        {
                            guyConditionId = 2;
                        }
                        else if (row.GetCell(37).ToString() == "B")
                        {
                            guyConditionId = 3;
                        }

                        if (row.GetCell(32).ToString().Contains(",") || row.GetCell(33).ToString().Contains(","))
                        {

                            string[] typesOfGuyId = row.GetCell(35).ToString().Split(new char[] {','});

                            string[] NoOfGuy = row.GetCell(36).ToString().Split(new char[] {','});

                            for (int j = 0; j < typesOfGuyId.Length; j++)
                            {
                                guy = new TblGuy();
                                guy.PoleId = row.GetCell(2).ToString();
                                guy.GuyTypeId = Convert.ToInt32(typesOfGuyId[j]);
                                guy.NoOfSet = Convert.ToInt32(NoOfGuy[j]);
                                guy.ConditionId = guyConditionId;

                                _context.TblGuy.Add(guy);
                                await _context.SaveChangesAsync();
                            }
                        }
                        else
                        {

                            guy = new TblGuy();
                            guy.PoleId = row.GetCell(2).ToString();
                            guy.GuyTypeId = row.GetCell(35) != null
                                ? Convert.ToInt32(row.GetCell(35).ToString())
                                : (int?) null;
                            guy.NoOfSet = row.GetCell(36) != null
                                ? Convert.ToInt32(row.GetCell(36).ToString())
                                : (int?) null;
                            ;
                            guy.ConditionId = row.GetCell(37) != null ? guyConditionId : (int?) null;
                            ;
                            _context.TblGuy.Add(guy);
                            await _context.SaveChangesAsync();

                        }
                    }

                    #endregion
                    }
                    catch (Exception e)
                    {
                        if (errorCount==0)
                        {
                            //HSSFCellStyle fCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();

                            //fCellStyle.FillForegroundColor = HSSFColor.Blue.Index;
                            //fCellStyle.FillPattern = FillPattern.SolidForeground;

                            //HSSFFont ffont = (HSSFFont)workbook.CreateFont();
                            //ffont.FontHeight = 20 * 20;
                            //ffont.Color = HSSFColor.Red.Index;
                            //fCellStyle.SetFont(ffont);

                            //fCellStyle.VerticalAlignment = VerticalAlignment.Center;
                            //fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

                           // cell.CellStyle = fCellStyle;


                            for (int r = 0; r < 7; r++)
                            {
                                
                                for (int k = 0; k < 57; k++)
                                {
                                    rowe.CreateCell(k).SetCellValue(sheet.GetRow(r).GetCell(k) != null ?sheet.GetRow(r).GetCell(k).ToString():" ");
                                    //rowe.RowStyle = fCellStyle;
                                }
                                errorCount++;
                                rowe = excelSheet.CreateRow(errorCount);
                            }
                        }
                        else
                        {
                            //sheet.SetActiveCellRange[string.Format("C{0}", i)].Style = sheet.SetActiveCellRange[string.Format("A{0}", i)].Style;
                            //excelSheet.SetActiveCellRange(0, 56, 0, 7) = sheet.SetActiveCellRange(0, 56, 0, 7);
                            //poleItems.Latitude = Convert.ToDecimal(row.GetCell(44).NumericCellValue.ToString());
                            //poleItems.Longitude = Convert.ToDecimal(row.GetCell(45).NumericCellValue.ToString());

                            for (int k = 0; k < 57; k++)
                            {
                                //if (k==43 || k==44) {
                                //    rowe.CreateCell(k).SetCellValue(row.GetCell(k) != null ? row.GetCell(k).NumericCellValue.ToString() : " ");
                                //}
                                //else {
                                    rowe.CreateCell(k).SetCellValue(row.GetCell(k)!= null ? row.GetCell(k).ToString() : " ");
                                //}
                            }
                            rowe.CreateCell(57).SetCellValue(e.Message);
                            rowe = excelSheet.CreateRow(errorCount);
                        }

                        errorCount++;
                        continue;
                    }
                }
                if (errorCount > 0)
                {
                    streamRead.Close();
                    workbook.Write(fs);
                    var streamWrite = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open);
                    await streamWrite.CopyToAsync(memory);
                    memory.Position = 0;
                    streamWrite.Close();
                    return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
                }
            }
            else
            {
                return View("Audit");
            }
            return View("Audit");
        }
    }

}