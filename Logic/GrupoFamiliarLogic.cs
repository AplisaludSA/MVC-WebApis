using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GrupoFamiliarLogic
    {

        public static IEnumerable<GRUPO_FAMILIAR> GetAll( Expression<System.Func<GRUPO_FAMILIAR, bool>> function )
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.GRUPO_FAMILIAR.Where(function).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static GRUPO_FAMILIAR Find(long? id)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.GRUPO_FAMILIAR.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Save(List<GRUPO_FAMILIAR> GrupoFamiliar)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    db.GRUPO_FAMILIAR.AddRange(GrupoFamiliar);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception )
            {
                return false;
            }
        }

        public static bool Delete(List<long> GrupoFamiliar)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                   var datos =  db.GRUPO_FAMILIAR.Where(x => GrupoFamiliar.Contains(x.ID_GRUPO_FAMILIAR));
                    db.GRUPO_FAMILIAR.RemoveRange(datos);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
