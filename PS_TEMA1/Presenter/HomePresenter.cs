using PS_TEMA1.Model.Repositories;
using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS_TEMA1.View.Interfaces;
using TEMA1_PS.Model.Repositories;

namespace PS_TEMA1.Presenter
{
    internal class HomePresenter
    {
        private IHomeGui _homeGui;        
        private PrezentareRepository _prezentareRepository;
        private ParticipantiRepository _participantiRepository;

        public HomePresenter(IHomeGui homeGui)
        {
            _homeGui = homeGui;
            
            _participantiRepository = new ParticipantiRepository();
            _prezentareRepository = new PrezentareRepository();
            _homeGui.getTabelConferinte().ItemsSource = _prezentareRepository.GetPrezentari();
            this.setPrezentari();
        }

        internal void cautareSectiune()
        {
            Sectiune sectiune = _homeGui.getFilterSelected();
            if(sectiune == Sectiune.TOATE)
                _homeGui.getTabelConferinte().ItemsSource = _prezentareRepository.GetPrezentari();
            else
                _homeGui.getTabelConferinte().ItemsSource = _prezentareRepository.GetPrezentarebySectiune(sectiune);          
        }

        internal void inscriereConferinta()
        {
            Participant participant = validData();
            try
            {
                if (participant == null)
                {
                    _homeGui.showMessage("Eroare", "Datele introduse sunt invalide!");
                    return;
                }
                _participantiRepository.addParticipant(participant);
                _homeGui.showMessage("Succes", "Inscriere efectuata cu succes!");
            }
            catch (Exception e)
            {
                _homeGui.showMessage("Eroare", "Datele introduse sunt invalide!");
            }            
        }

        private Participant validData()
        {
            try
            {
                String nume = _homeGui.getNume();
                String email = _homeGui.getEmail();
                String telefon = _homeGui.getTelefon();
                String prezentare = _homeGui.getPrezentareSelectata();
                if (String.IsNullOrEmpty(nume) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(telefon) || String.IsNullOrEmpty(prezentare))
                    return null;
                Prezentare prezentareObj = _prezentareRepository.GetPrezentarebyTitlu(prezentare);
                Participant participant = new Participant();
                participant.Nume = nume;
                participant.Email = email;
                participant.Telefon = telefon;
                participant.IdPrezentare = prezentareObj.Id;
                return participant;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void setPrezentari()
        {
            List<String> list = new List<String>();
            List<Prezentare> prezentari = _prezentareRepository.GetPrezentari();
            foreach (Prezentare prezentare in prezentari)
            {
                list.Add(prezentare.Titlu);
            }
            _homeGui.setPrezentariSelection(list);
        }
    }
}
