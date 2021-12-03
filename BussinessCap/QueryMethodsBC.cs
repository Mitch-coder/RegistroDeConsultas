using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCap;

namespace BussinessCap
{
    public class QueryMethodsBC
    {
        QueryMethods methods = new QueryMethods();

        public bool Create(EntitieQuery query)
        {
            Querie instant = new Querie ();
            instant.numberWeek = query.numberWeek;
            instant.numberStudent = query.numberStudent;
            instant.topic = query.topic;
            instant.observations = query.observations;
            instant.idStudent = query.idStudent;
            instant.signStudent = query.signStudent;
            instant.Date = query.Date;

            return methods.Create(instant);
        }
        public Querie Read(int id)
        {
            Querie instant = methods.Read(id);
            return instant;
        }
        public bool Update(EntitieQuery query)
        {
            Querie instant = new Querie();
            instant.id = query.id;
            instant.numberWeek = query.numberWeek;
            instant.numberStudent = query.numberStudent;
            instant.topic = query.topic;
            instant.observations = query.observations;
            instant.idStudent = query.idStudent;
            instant.signStudent = query.signStudent;
            instant.Date = query.Date;

            return methods.Update(instant);
        }
        public bool Delete(int id)
        {
            return methods.Delete(id);
        }
        public List<Querie> ReadAll()
        {
            return methods.ReadAll();
        }

    }
}
