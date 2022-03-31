namespace Generic_Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                var logInt = new LocalFileLogger<int>("C:/Users/Admin/source/repos/Generic_Collection/test.txt");
                var logString = new LocalFileLogger<string>("C:/Users/Admin/source/repos/Generic_Collection/test.txt");
                int y = 10; // - for test logInt

                // logInt
                try
                {
                    int x = 100 / y;
                    logInt.LogInfo(x.ToString());
                }
                catch (ArithmeticException e)
                {
                    logInt.LogWarning(y.ToString());
                }
                catch (Exception e)
                {
                    logInt.LogError("0", e);
                }

                // logString
                try
                {
                    string s = "e"; // - for test logString
                    int x = Convert.ToInt32(s);
                    logString.LogInfo(s);
                }
                catch (FormatException e)
                {
                    logString.LogWarning("FormatException");
                }
                catch (Exception e)
                {
                    logString.LogError("Exception", e);
                }
            }

            {

                var list = new List<Entity>()
                {
                    new Entity { Id = 1, ParentId = 0, Name = "Root entity"},

                    new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"},

                    new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"},

                    new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"},

                    new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"}
                };
                var res = ToDic(list);
            }

        }

        public static Dictionary<int, List<Entity>> ToDic(List<Entity> lst)
        {
            var dic = new Dictionary<int, List<Entity>>();

            foreach (var item in lst)
            {
                dic.TryAdd(item.ParentId, new List<Entity>());
                dic[item.ParentId].Add(item);
            }

            return dic;
        }
    }
}