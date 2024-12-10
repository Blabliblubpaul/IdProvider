namespace IdProvider;

class Program {
    private static List<MyIdClass> idClasses;
    private static Random random;
    
    static void Main(string[] args) {
        idClasses = new List<MyIdClass>(50);
        random = new Random();
        
        for (int i = 0; i < idClasses.Capacity; i++) {
            idClasses.Add(new MyIdClass());
        }

        Console.WriteLine("############################");
        Console.WriteLine("Start:");
        foreach (MyIdClass idClass in idClasses) {
            Console.WriteLine(idClass.Id);
        }
        Console.WriteLine("############################\n");

        Console.WriteLine("############################");
        Console.WriteLine("Removed:");
        int toRemove = random.Next(7, 10);
        for (int i = 0; i < toRemove; i++) {
            int remove = random.Next(0, idClasses.Count);
            MyIdClass c = idClasses[remove];
            // idClasses.RemoveAt(remove);
            
            Console.WriteLine(c.Id);
            c.Dispose();
        }
        Console.WriteLine("############################\n");
        
        // Console.WriteLine("############################");
        // Console.WriteLine("Partially removed:");
        // foreach (MyIdClass idClass in idClasses) {
        //     Console.WriteLine(idClass.Id);
        // }
        // Console.WriteLine("############################\n");
        //
        // Console.WriteLine("############################");
        // Console.WriteLine("New:");
        // for (int i = 0; i < toRemove; i++) {
        //     MyIdClass c = new();
        //     Console.WriteLine(c.Id);
        // }
        // Console.WriteLine("############################\n");
        //
        // GC.Collect();
        
        Console.WriteLine("############################");
        Console.WriteLine("New after Dispose:");
        for (int i = 0; i < 20; i++) {
            MyIdClass c = new();
            idClasses.Add(c);
            Console.WriteLine(c.Id);
        }
        Console.WriteLine("############################\n");
        
        Console.WriteLine("############################");
        Console.WriteLine("Result:");
        foreach (MyIdClass idClass in idClasses) {
            Console.WriteLine(idClass.Id);
        }
        Console.WriteLine("############################\n");
    }
}