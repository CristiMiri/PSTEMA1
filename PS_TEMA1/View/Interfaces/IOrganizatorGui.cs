using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS_TEMA1.View.Interfaces
{
    internal interface IOrganizatorGui : IGUI
    {
        //Participant
        int    getIdParticipant();
        string getNumeParticipant();
        string getEmailParticipant();
        string getTelefonParticipant();
        string getPrezentareParticipant();
        void setIdParticipant(int idParticipant);
        void setNumeParticipant(string numeParticipant);
        void setEmailParticipant(string emailParticipant);
        void setTelefonParticipant(string telefonParticipant);
        void setPrezentareParticipant(string prezentareParticipant);

        //Prezentare
        int    getIdPrezentare();
        string getTitluPrezentare();
        string getAutorPrezentare();
        string getDescrierePrezentare();
        string getDataPrezentare();
        string getOraPrezentare();
        Sectiune getSectiunePrezentare();
        int getConeferintaIdPrezentare();
        void setIdPrezentare(int idPrezentare);
        void setTitluPrezentare(string titluPrezentare);
        void setAutorPrezentare(string autorPrezentare);
        void setDescrierePrezentare(string descrierePrezentare);
        void setDataPrezentare(string dataPrezentare);
        void setOraPrezentare(string oraPrezentare);
        void setSectiunePrezentare(Sectiune sectiunePrezentare);
        void setConferintaIdPrezentare(int conferintaIdPrezentare);


        DataGrid GetTabelPrezentari();
        DataGrid GetTabelParticipanti();
        ComboBox getFilterComboBox();
        ComboBox PrezentarecomboBox();

        Sectiune getFilterSelected();
        void setFilerSelected(Sectiune sectiune);
        

    }
}
