using BitchFighting.model;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitchFighting.data
{
    class DatabaseControl : IDatabaseControl
    {
        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "IRoAlZs8vkLSlfYKMzitvZPVwdoEe6nwL5PKkG0b",
            BasePath = "https://heroesbattles.firebaseio.com/"
        };
        private IFirebaseClient _client;

        private static DatabaseControl instance;

        protected DatabaseControl()
        {
            _client = new FirebaseClient(config);
   
            
        }


        public List<Hero> GetAll()
        {
            FirebaseResponse response = _client.Get("heroes");
            List<Hero> todo = response.ResultAs<List<Hero>>();
            return todo;
        }

        public void Set(List<Hero> heroes)
        {
             _client.Set("heroes", heroes);
        }

        public static DatabaseControl getInstance()
        {
            if (instance == null)
                instance = new DatabaseControl();
            return instance;
        }

  
    }
}
