using System;
using System.Collections.Generic;
using System.Linq;

namespace JSC_Portal.Models
{
    public class TestModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class TestModelManager
    {
        readonly List<TestModel> _heroes = new List<TestModel>() {
            new TestModel { ID = 1, Name = "Bristleback", Type="Strength"},
            new TestModel { ID = 2, Name ="Abbadon", Type="Strength"},
            new TestModel { ID = 3, Name ="Spectre", Type="Agility"},
            new TestModel { ID = 4, Name ="Juggernaut", Type="Agility"},
            new TestModel { ID = 5, Name ="Lion", Type="Intelligence"},
            new TestModel { ID = 6, Name ="Zues", Type="Intelligence"},
            new TestModel { ID = 7, Name ="Trent", Type="Strength"},
        };

        public IEnumerable<TestModel> GetAll { get { return _heroes; } }

        public List<TestModel> GetHeroesByType(string type)
        {
            return _heroes.Where(o => o.Type.ToLower().Equals(type.ToLower())).ToList();
        }
    }
}
