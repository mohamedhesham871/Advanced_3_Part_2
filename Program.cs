using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Advanced_3_Part_2
{
    internal class Program
    {
        class stringWithcomparer : IEqualityComparer
        {
            public new bool Equals(object? x, object? y)
            {
                string? sx = x as string;
                string? sy = y as string;

                return sx?.ToLower().Equals(sy?.ToLower()) ?? (sy is null) ? true : false;
            }

            public int GetHashCode(object obj)
            {
                string gg = obj as string;
                return gg.ToLower().GetHashCode();
            }
        }
        class stringWithcomparerToDictionary : IEqualityComparer<string>
        {
           
            public bool Equals(string? sx, string? sy)
            {
                return sx?.ToLower().Equals(sy?.ToLower()) ?? (sy is null) ? true : false;
            }

          
            public int GetHashCode([DisallowNull] string gg)
            {
                return gg?.ToLower().GetHashCode()??0 ;
            }
        }


        #region Movie Class
        class Movie
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }

            public Movie(int id, string title, string des, int price)
            {
                ID = id;
                Title = title;
                Description = des;
                Price = price;
            }
            public override string ToString()
            {
                return $"{ID} ,name {Title},Description {Description} ,price {Price}";
            }
            public override bool Equals(object? obj)
            {
                Movie? movie = obj as Movie;
                return this.ID.Equals(movie?.ID??0) && this.Title.Equals(movie?.Title??"") && this.Price.Equals(movie?.Price??0);
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(ID, Title, Price);
            }
        }

            #endregion
            static void Main(string[] args)
        {
            #region Demo Of HashTabel
            Hashtable AnyThing = new Hashtable();//Non-Genric Collection
            //Boxing and UnBoxing  --> UnSafe Casting
            
            AnyThing.Add(10, "aLi");
            AnyThing.Add("ALi", 10);
            //foreach (DictionaryEntry thing in AnyThing)
            //    Console.WriteLine(thing.Key +"  "+thing.Value);


            Hashtable NameOfStudent = new Hashtable(new stringWithcomparer());
            NameOfStudent.Add("Ali", "Omarn");
            //   NameOfStudent.Add("ali", "ali");  Throw Exception
            //foreach (string s in NameOfStudent.Keys)
            //    Console.WriteLine(s);

            #endregion

            #region Demo OF Dictionary
            //Generic Collection  --- same hashtable  it's Best  no Boxing and Unboxing
            // has Unique keys
            Dictionary<string, int> Note = new Dictionary<string, int>(new stringWithcomparerToDictionary()) { { "Hesham",0} };
            Note.Add("Omar", 1);
            Note.Add("Mariam", 2);
            Note.Add("OLa", 4);
            Note.Add("Mohamed", 3);

            //Check if it's Found Because Should Contain Unique Keys
            bool isFound=  Note.TryAdd("mohamed", 9);
            Console.WriteLine(isFound == true ? "Added New Name" : "Name is Found");

            // Can Also use ContainKey
            if (!Note.ContainsKey("Mohamed"))
                Note.Add("Mohamed", 9);



            isFound = Note.TryGetValue("Hesham", out int id);
            if (isFound == true)
            {
                //Hesham has ID 0 so i will use Bool to check if it's Found or Not
                Console.WriteLine(id);
            }
            //Remove Value 
            Note.Remove("mariam");
            // Loop on Keys and Values
                //foreach(var item in Note)
                //{
                //    Console.WriteLine($"Name of Person {item.Key} and his ID is {item.Value}");
                //}
            //Loop on Keys 
            Console.WriteLine("-------------------");
                //foreach (var names in Note.Keys)
                //{
                //    Console.WriteLine(names);
                //}
            Console.WriteLine("--------------------");
            //Loop on Values 
                //foreach(var ID in Note.Values)
                //{
                //    Console.WriteLine(ID);
                //}
            //----------------------------------
            #endregion

            #region Demo Of HashSet
            HashSet<int> num = new HashSet<int>(); 
            //Generic collection  and Unique Data Like List But it's  Unique
            num.Add(2);//Add
            num.Add(4);//Add
            num.Add(6);//Add
            num.Add(2);// No  (with No Exception) -->Ignore


            HashSet<Movie> list = new HashSet<Movie>()
            {
                new Movie(1,"Comedy Life 01","text",200),
                new Movie(2,"Comedy Life 02","text",100),
                new Movie(3,"Comedy Life 03","text",400),

            };
            list.Add(new Movie(1, "Comedy Life 01", "text", 200));
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            
            #endregion
        }
    }
}
