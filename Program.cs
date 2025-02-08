using System.Collections;

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
            NameOfStudent.Add("ali", "ali");
            foreach (string s in NameOfStudent.Keys)
                Console.WriteLine(s);

            #endregion
        }
    }
}
