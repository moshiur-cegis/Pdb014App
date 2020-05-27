using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.MeteringPanelModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.MeteringPanelController
{
    public class TblMeteringPanelsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblMeteringPanelsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblMeteringPanels
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblMeteringPanel
                .Include(t => t.AmpereMeter)
                .Include(t => t.AnnuciatorForFeeder)
                .Include(t => t.AnnuciatorForTransformer)
                .Include(t => t.AuxiliaryFlagRelayForTransformer)
                .Include(t => t.ControlSwitchForFeeder)
                .Include(t => t.ControlSwitchForTransformer)
                .Include(t => t.DifferentialRelayForTransformer)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForFeeder)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForTransformer)
                .Include(t => t.KWHandkVARHMeter)
                .Include(t => t.MegaVarMeter)
                .Include(t => t.MegaWattMeter)
                .Include(t => t.MeteringPanelToDimensionAndWeight)
                .Include(t => t.MeteringPanelToSubstation)
                .Include(t => t.RestrictedEarthFaultRelayForTransformer)
                .Include(t => t.TripCircuitSupervisionRelayForFeeder)
                .Include(t => t.TripCircuitSupervisionRelayForTransformer)
                .Include(t => t.TripRelayForFeeder)
                .Include(t => t.TripRelayForTransformer)
                .Include(t => t.VoltMeterWithSelectorSwitch);

            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblMeteringPanels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMeteringPanel = await _context.TblMeteringPanel
                .Include(mp => mp.AmpereMeter)
                .Include(mp => mp.AnnuciatorForFeeder)
                .Include(mp => mp.AnnuciatorForTransformer)
                .Include(mp => mp.AuxiliaryFlagRelayForTransformer)
                .Include(mp => mp.ControlSwitchForFeeder)
                .Include(mp => mp.ControlSwitchForTransformer)
                .Include(mp => mp.DifferentialRelayForTransformer)
                .Include(mp => mp.IdmtOverCurrentAndEarthFaultRelayForFeeder)
                .Include(mp => mp.IdmtOverCurrentAndEarthFaultRelayForTransformer)
                .Include(mp => mp.KWHandkVARHMeter)
                .Include(mp => mp.MegaVarMeter)
                .Include(mp => mp.MegaWattMeter)
                .Include(mp => mp.MeteringPanelToDimensionAndWeight)
                .Include(mp => mp.RestrictedEarthFaultRelayForTransformer)
                .Include(mp => mp.TripCircuitSupervisionRelayForFeeder)
                .Include(mp => mp.TripCircuitSupervisionRelayForTransformer)
                .Include(mp => mp.TripRelayForFeeder)
                .Include(mp => mp.TripRelayForTransformer)
                .Include(mp => mp.VoltMeterWithSelectorSwitch)
                .Include(mp => mp.MeteringPanelToSubstation)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationType)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .FirstOrDefaultAsync(m => m.MeteringPanelId == id);

            if (tblMeteringPanel == null)
            {
                return NotFound();
            }

            return View(tblMeteringPanel);
        }

        // GET: TblMeteringPanels/Create
        public IActionResult Create()
        {
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName");
            ViewData["AnnuciatorIdForFeeder"] = new SelectList(_context.LookupAnnuciator, "Annunciator", "Annunciator");
            ViewData["AnnuciatorIdForTransformer"] = new SelectList(_context.LookupAnnuciator, "Annunciator", "Annunciator");
            ViewData["AuxiliaryFlagRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["ControlSwitchIdForFeeder"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch");
            ViewData["ControlSwitchIdForTransformer"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch");
            ViewData["DifferentialRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["KWHandkVARHMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName");
            ViewData["MegaVarMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName");
            ViewData["MegaWattMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName");
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker");
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName");
            ViewData["RestrictedEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["TripCircuitSupervisionRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["TripCircuitSupervisionRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["TripRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["TripRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName");

            return View();
        }

        // POST: TblMeteringPanels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeteringPanelId,SubstationId,ManufacturersNameCountryOfOrigin,ManufacturersModelNo,SystemNominalVoltage,MaximumSystemVoltage,RatedFrequency,DifferentialRelayIdForTransformer,RestrictedEarthFaultRelayIdForTransformer,IdmtOverCurrentAndEarthFaultRelayIdForTransformer,AuxiliaryFlagRelayIdForTransformer,TripCircuitSupervisionRelayIdForTransformer,TripRelayIdForTransformer,AnnuciatorIdForTransformer,ControlSwitchIdForTransformer,IdmtOverCurrentAndEarthFaultRelayIdForFeeder,TripCircuitSupervisionRelayIdForFeeder,TripRelayIdForFeeder,AnnuciatorIdForFeeder,ControlSwitchIdForFeeder,KWHandkVARHMeterId,VoltMeterId,AmpereMeterId,MegaWattMeterId,MegaVarMeterId,DimensionAndWeightId")] TblMeteringPanel tblMeteringPanel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMeteringPanel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.AmpereMeterId);
            ViewData["AnnuciatorIdForFeeder"] = new SelectList(_context.LookupAnnuciator, "AnnuciatorId", "Annunciator", tblMeteringPanel.AnnuciatorIdForFeeder);
            ViewData["AnnuciatorIdForTransformer"] = new SelectList(_context.LookupAnnuciator, "AnnuciatorId", "Annunciator", tblMeteringPanel.AnnuciatorIdForTransformer);
            ViewData["AuxiliaryFlagRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.AuxiliaryFlagRelayIdForTransformer);
            ViewData["ControlSwitchIdForFeeder"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch", tblMeteringPanel.ControlSwitchIdForFeeder);
            ViewData["ControlSwitchIdForTransformer"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch", tblMeteringPanel.ControlSwitchIdForTransformer);
            ViewData["DifferentialRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.DifferentialRelayIdForTransformer);
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.IdmtOverCurrentAndEarthFaultRelayIdForFeeder);
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.IdmtOverCurrentAndEarthFaultRelayIdForTransformer);
            ViewData["KWHandkVARHMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.KWHandkVARHMeterId);
            ViewData["MegaVarMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.MegaVarMeterId);
            ViewData["MegaWattMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.MegaWattMeterId);
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker", tblMeteringPanel.DimensionAndWeightId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName", tblMeteringPanel.SubstationId);
            ViewData["RestrictedEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.RestrictedEarthFaultRelayIdForTransformer);
            ViewData["TripCircuitSupervisionRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripCircuitSupervisionRelayIdForFeeder);
            ViewData["TripCircuitSupervisionRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripCircuitSupervisionRelayIdForTransformer);
            ViewData["TripRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripRelayIdForFeeder);
            ViewData["TripRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripRelayIdForTransformer);
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.VoltMeterId);

            return View(tblMeteringPanel);
        }

        // GET: TblMeteringPanels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMeteringPanel = await _context.TblMeteringPanel.FindAsync(id);
            if (tblMeteringPanel == null)
            {
                return NotFound();
            }
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.AmpereMeterId);
            ViewData["AnnuciatorIdForFeeder"] = new SelectList(_context.LookupAnnuciator, "AnnuciatorId", "Annunciator", tblMeteringPanel.AnnuciatorIdForFeeder);
            ViewData["AnnuciatorIdForTransformer"] = new SelectList(_context.LookupAnnuciator, "AnnuciatorId", "Annunciator", tblMeteringPanel.AnnuciatorIdForTransformer);
            ViewData["AuxiliaryFlagRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.AuxiliaryFlagRelayIdForTransformer);
            ViewData["ControlSwitchIdForFeeder"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch", tblMeteringPanel.ControlSwitchIdForFeeder);
            ViewData["ControlSwitchIdForTransformer"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch", tblMeteringPanel.ControlSwitchIdForTransformer);
            ViewData["DifferentialRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.DifferentialRelayIdForTransformer);
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.IdmtOverCurrentAndEarthFaultRelayIdForFeeder);
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.IdmtOverCurrentAndEarthFaultRelayIdForTransformer);
            ViewData["KWHandkVARHMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.KWHandkVARHMeterId);
            ViewData["MegaVarMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.MegaVarMeterId);
            ViewData["MegaWattMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.MegaWattMeterId);
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker", tblMeteringPanel.DimensionAndWeightId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName", tblMeteringPanel.SubstationId);
            ViewData["RestrictedEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.RestrictedEarthFaultRelayIdForTransformer);
            ViewData["TripCircuitSupervisionRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripCircuitSupervisionRelayIdForFeeder);
            ViewData["TripCircuitSupervisionRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripCircuitSupervisionRelayIdForTransformer);
            ViewData["TripRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripRelayIdForFeeder);
            ViewData["TripRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripRelayIdForTransformer);
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.VoltMeterId);
            return View(tblMeteringPanel);
        }

        // POST: TblMeteringPanels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeteringPanelId,SubstationId,ManufacturersNameCountryOfOrigin,ManufacturersModelNo,SystemNominalVoltage,MaximumSystemVoltage,RatedFrequency,DifferentialRelayIdForTransformer,RestrictedEarthFaultRelayIdForTransformer,IdmtOverCurrentAndEarthFaultRelayIdForTransformer,AuxiliaryFlagRelayIdForTransformer,TripCircuitSupervisionRelayIdForTransformer,TripRelayIdForTransformer,AnnuciatorIdForTransformer,ControlSwitchIdForTransformer,IdmtOverCurrentAndEarthFaultRelayIdForFeeder,TripCircuitSupervisionRelayIdForFeeder,TripRelayIdForFeeder,AnnuciatorIdForFeeder,ControlSwitchIdForFeeder,KWHandkVARHMeterId,VoltMeterId,AmpereMeterId,MegaWattMeterId,MegaVarMeterId,DimensionAndWeightId")] TblMeteringPanel tblMeteringPanel)
        {
            if (id != tblMeteringPanel.MeteringPanelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMeteringPanel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMeteringPanelExists(tblMeteringPanel.MeteringPanelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.AmpereMeterId);
            ViewData["AnnuciatorIdForFeeder"] = new SelectList(_context.LookupAnnuciator, "AnnuciatorId", "Annunciator", tblMeteringPanel.AnnuciatorIdForFeeder);
            ViewData["AnnuciatorIdForTransformer"] = new SelectList(_context.LookupAnnuciator, "AnnuciatorId", "Annunciator", tblMeteringPanel.AnnuciatorIdForTransformer);
            ViewData["AuxiliaryFlagRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.AuxiliaryFlagRelayIdForTransformer);
            ViewData["ControlSwitchIdForFeeder"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch", tblMeteringPanel.ControlSwitchIdForFeeder);
            ViewData["ControlSwitchIdForTransformer"] = new SelectList(_context.LookupControlSwitch, "ControlSwitchId", "ControlSwitch", tblMeteringPanel.ControlSwitchIdForTransformer);
            ViewData["DifferentialRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.DifferentialRelayIdForTransformer);
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.IdmtOverCurrentAndEarthFaultRelayIdForFeeder);
            ViewData["IdmtOverCurrentAndEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.IdmtOverCurrentAndEarthFaultRelayIdForTransformer);
            ViewData["KWHandkVARHMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.KWHandkVARHMeterId);
            ViewData["MegaVarMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.MegaVarMeterId);
            ViewData["MegaWattMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.MegaWattMeterId);
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker", tblMeteringPanel.DimensionAndWeightId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName", tblMeteringPanel.SubstationId);
            ViewData["RestrictedEarthFaultRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.RestrictedEarthFaultRelayIdForTransformer);
            ViewData["TripCircuitSupervisionRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripCircuitSupervisionRelayIdForFeeder);
            ViewData["TripCircuitSupervisionRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripCircuitSupervisionRelayIdForTransformer);
            ViewData["TripRelayIdForFeeder"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripRelayIdForFeeder);
            ViewData["TripRelayIdForTransformer"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblMeteringPanel.TripRelayIdForTransformer);
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "DifferentMeterId", tblMeteringPanel.VoltMeterId);
            return View(tblMeteringPanel);
        }

        // GET: TblMeteringPanels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMeteringPanel = await _context.TblMeteringPanel
                .Include(t => t.AmpereMeter)
                .Include(t => t.AnnuciatorForFeeder)
                .Include(t => t.AnnuciatorForTransformer)
                .Include(t => t.AuxiliaryFlagRelayForTransformer)
                .Include(t => t.ControlSwitchForFeeder)
                .Include(t => t.ControlSwitchForTransformer)
                .Include(t => t.DifferentialRelayForTransformer)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForFeeder)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForTransformer)
                .Include(t => t.KWHandkVARHMeter)
                .Include(t => t.MegaVarMeter)
                .Include(t => t.MegaWattMeter)
                .Include(t => t.MeteringPanelToDimensionAndWeight)
                .Include(t => t.MeteringPanelToSubstation)
                .Include(t => t.RestrictedEarthFaultRelayForTransformer)
                .Include(t => t.TripCircuitSupervisionRelayForFeeder)
                .Include(t => t.TripCircuitSupervisionRelayForTransformer)
                .Include(t => t.TripRelayForFeeder)
                .Include(t => t.TripRelayForTransformer)
                .Include(t => t.VoltMeterWithSelectorSwitch)
                .FirstOrDefaultAsync(m => m.MeteringPanelId == id);
            if (tblMeteringPanel == null)
            {
                return NotFound();
            }

            return View(tblMeteringPanel);
        }

        // POST: TblMeteringPanels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMeteringPanel = await _context.TblMeteringPanel.FindAsync(id);
            _context.TblMeteringPanel.Remove(tblMeteringPanel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMeteringPanelExists(int id)
        {
            return _context.TblMeteringPanel.Any(e => e.MeteringPanelId == id);
        }
    }
}
