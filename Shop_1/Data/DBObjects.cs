using Shop_1.Data.Models;

namespace Shop_1.Data
{
    public class DBObjects
    {
        /// <summary>
        /// Add objects into DB
        /// </summary>
        /// <param name="app">app</param>
        public static void Initial(AppDBContent content) {

            //добавляем категории в БД, если их нет
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            //добавляем товары в БД, если их нет
            if (!content.Product.Any())
            {
                content.AddRange(
                    new Product
                    {
                        Name = "Мед липовый",
                        ShortDesc = "Классический вкус",
                        LongDesc = "Очень полезный и вкусный мед ",
                        Img = "/img/honey-1.jpg",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Мёд"]
                    },
                    new Product
                    {
                        Name = "Мед разнотравье",
                        ShortDesc = "Ароматная симфония",
                        LongDesc = "Ощути весь букет летних ароматов с нашим медом, собранным в альпийских лугах",
                        Img = "/img/honey-2.jpg",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Мёд"]
                    },
                    new Product
                    {
                        Name = "Перга",
                        ShortDesc = "Покупай пока не сгнила",
                        LongDesc = "Спрессованная пчелами пыльца, богата белком",
                        Img = "/img/perga.jpg",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Продукты пчеловодства"]
                    },
                    new Product
                    {
                        Name = "Воск",
                        ShortDesc = "Древнейший продукт",
                        LongDesc = "Можете использовать на своем свечном заводике",
                        Img = "/img/vosk.jpg",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Продукты пчеловодства"]
                    }
                );
            }

            //сохраняем изменения
            content.SaveChanges();
                
               
        }
        

        /// <summary>
        /// Свойство для создания категорий
        /// </summary>
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                //Если в переменной уже есть значения, просто возвращаем ее
                if (category == null) 
                {
                    //Если нет, то создаем новый список с категориями и возвращаем его
                    var list = new Category[] {
                        new Category { CategoryName = "Мёд", CategoryDesc = "Натуральные сорта отборного продукта" },
                        new Category { CategoryName = "Продукты пчеловодства", CategoryDesc = "Перга, воск, пыльца и др." }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }

        }
        
    }
}
