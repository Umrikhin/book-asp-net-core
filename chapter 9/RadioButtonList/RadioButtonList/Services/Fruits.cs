using RadioButtonList.Models;

namespace RadioButtonList.Services
{
    public class Fruits : IFruits
    {
        private List<Fruit> dataFruit;
        public Fruits()
        {
            dataFruit = new List<Fruit>()
            {
                new Fruit() { id = 1, nm = "Яблоки" },
                new Fruit() { id = 2, nm = "Сливы" },
                new Fruit() { id = 3, nm = "Груши"  },
                new Fruit() { id = 4, nm = "Абрикос"  },
                new Fruit() { id = 5, nm = "Манго"  },
                new Fruit() { id = 6, nm = "Апельсин" }
            };
        }
        List<Fruit> IFruits.fruits => dataFruit;
    }
}
