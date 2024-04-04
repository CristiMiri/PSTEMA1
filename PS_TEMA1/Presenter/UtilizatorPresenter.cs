using PS_TEMA1.Model;
using PS_TEMA1.Model.Repositories;
using PS_TEMA1.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEMA1_PS.Model.Repositories;

namespace PS_TEMA1.Presenter
{
    internal class UtilizatorPresenter
    {
        
        //Accesarea volumului conferinței'
        private IUtilizatorGui _utilizatorGui;
        private ConferintaRepository _conferintaRepository;
        private PrezentareRepository _prezentareRepository;

        public UtilizatorPresenter(IUtilizatorGui utilizatorGui)
        {
            _utilizatorGui = utilizatorGui;
            _conferintaRepository = new ConferintaRepository();
            _prezentareRepository = new PrezentareRepository();
            LoadConferinte();
            
        }

        public void LoadConferinte()
        {
            List<Prezentare> prezentari = _prezentareRepository.GetPrezentari();
            List<Conferinta> conferinte = _conferintaRepository.GetConferinte();

            // Assuming you have collections of Conferinta and Prezentare objects

            var combinedData = from conferinta in conferinte
                               join prezentare in prezentari on conferinta.Id equals prezentare.Id_conferinta
                               select new
                               {
                                   ConferintaId = conferinta.Id,
                                   ConferintaTitlu = conferinta.Titlu,
                                   ConferintaLocatie = conferinta.Locatie,
                                   ConferintaData = conferinta.Data,
                                   PrezentareId = prezentare.Id,
                                   PrezentareTitlu = prezentare.Titlu,
                                   PrezentareAutor = prezentare.Autor,
                                   PrezentareDescriere = prezentare.Descriere,
                                   PrezentareData = prezentare.Data,
                                   PrezentareOra = prezentare.Ora,
                                   PrezentareSectiune = prezentare.Sectiune,
                                   PrezentareConferintaId = prezentare.Id_conferinta,
                               };

            // Now you can bind the combinedData to your DataGrid
            _utilizatorGui.getTabelConferinte().ItemsSource = combinedData;

        }

        public void LoadRezervari()
        {
            // Load rezervari
        }
    }
}
