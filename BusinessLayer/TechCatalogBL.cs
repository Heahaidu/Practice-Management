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

        public int Add(TechnicalCatalog technicalCatalog)
        {
            return techCatalogDL.Add(technicalCatalog);
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
