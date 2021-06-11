using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_JSON_001
{
    enum Sex 
    { maile ,
      femaile
    }

    [Serializable]
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        public User() { }
        public User(string name, int age, Sex sex) => (Name, Age, Sex) = (name, age, sex);

        public override string ToString()
        {
            return $"Name={Name} , Age={Age}, Sex={Sex}";
        }
    }
}
