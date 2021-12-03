using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataCap
{
    public class QueryMethods
    {
        public bool Create(Querie querie)
        {
            using(queriesEntities db=new queriesEntities())
            {
                db.Queries.Add(querie);
                db.SaveChanges();
                return true;
            }
        }
        public Querie Read(int id)
        {
            using (queriesEntities db = new queriesEntities())
            {
                Querie q = db.Queries.Find(id);
                return q;
            }
        }
        public bool Update(Querie querie)
        {
            using (queriesEntities db = new queriesEntities())
            {
                Querie q = db.Queries.Find(querie.id);
                q.id = querie.id;
                q.numberWeek = querie.numberWeek;
                q.numberStudent = querie.numberStudent;
                q.topic = querie.topic;
                q.observations = querie.observations;
                q.idStudent = querie.idStudent;
                q.signStudent = querie.signStudent;
                q.Date = querie.Date;
                db.Entry(q).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }
        public bool Delete(int id)
        {
            using (queriesEntities db = new queriesEntities())
            {
                db.Queries.Remove(db.Queries.Find(id));
                db.SaveChanges();
                return true;
            }
        }
        public List<Querie> ReadAll()
        {
            using(queriesEntities db = new queriesEntities())
            {
                var queries = from d in db.Queries select d;
                return queries.ToList();
            }
        }
    }
}
