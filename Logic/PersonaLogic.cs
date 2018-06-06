using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Z.EntityFramework.Plus;

namespace Logic
{
    public class PersonaLogic
    {
        public static IEnumerable<PERSONA> GetAll()
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    return db.PERSONA.Where(x=> x.Activo == true).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<PERSONA>();
            }
        }

        public static bool Create(PERSONA Persona)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    db.PERSONA.Add(Persona);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool EditPersona(PERSONA Persona)
        {         
            using (FidelEntities db = new FidelEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try {
                        if (Persona.GRUPO_FAMILIAR.Count() > 0)
                            db.GRUPO_FAMILIAR.AddRange(Persona.GRUPO_FAMILIAR);
                        db.Entry(Persona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                        throw;
                    }
                }
                
            }
        }

        public static PERSONA FindPersona(long? id)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    return db.PERSONA.Include("GRUPO_FAMILIAR.PARENTESCO").Where(x=> x.ID_PERSONA == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return new PERSONA();
            }
        }

        public static void DeletePersona(long? id)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    PERSONA Persona = FindPersona(id);
                    if (Persona != null)
                    {
                        db.GRUPO_FAMILIAR.Where(x => Persona.ID_PERSONA == x.ID_PERSONA).Update(x => new GRUPO_FAMILIAR() { Activo = false });
                        Persona.Activo = false;
                        db.Entry(Persona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}