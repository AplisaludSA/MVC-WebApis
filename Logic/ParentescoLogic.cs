using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Logic
{
    public class ParentescoLogic
    {
        public static IEnumerable<PARENTESCO> GetAll(Expression<Func<PARENTESCO,bool>> exp)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    var datos =  db.PARENTESCO.Where(exp).ToList();
                    db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    return datos;
                }
            }
            catch (Exception)
            {
                return new List<PARENTESCO>();
            }
        }

        public static bool Create(PARENTESCO Parentesco)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    db.PARENTESCO.Add(Parentesco);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void EditParentesco(PARENTESCO Parentesco)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    db.Entry(Parentesco).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PARENTESCO FindParentesco(long? id)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                    return db.PARENTESCO.Find(id);
            }
            catch (Exception)
            {
                return new PARENTESCO();
            }
        }

        public static void DeleteParentesco(long? id)
        {
            try
            {
                using (FidelEntities db = new FidelEntities())
                {
                    PARENTESCO Parentesco = FindParentesco(id);
                    if (Parentesco != null)
                    {
                        db.PARENTESCO.Remove(Parentesco);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
