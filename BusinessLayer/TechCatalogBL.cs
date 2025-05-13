using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class TechCatalogBL
    {
        private TechCatalogDL techCatalogDL;

        public TechCatalogBL() { 
            techCatalogDL = new TechCatalogDL();
        }

        public ObservableCollection<TechnicalCatalog> GetTechnicalCatalogs()
        {
            try
            {
                return (techCatalogDL.GetTechnicalCatalogs());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<TechnicalCatalog> GetTechnicalCatalogsOfType(string indicationType)
        {
            try
            {
                return (techCatalogDL.GetTechnicalCatalogsOfType(indicationType));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<TechnicalCatalog> GetTechnicalCatalogs(List<MedicineTestPrescription> medicineTestPrescriptions)
        {
            return techCatalogDL.GetTechnicalCatalogs(true)
                .Where(technicalCatalog => medicineTestPrescriptions.Select(m => m.TechnicalCatalogId).Contains(technicalCatalog.id)).ToList();
        }

        public int Add(TechnicalCatalog technicalCatalog)
        {
            return techCatalogDL.Add(technicalCatalog);
        }

        public int Update(TechnicalCatalog technicalCatalog)
        {
            return techCatalogDL.Update(technicalCatalog);
        }
        public int Delete(int id)
        {
            try
            {
                return techCatalogDL.Delete(id);
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
