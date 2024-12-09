namespace IdProvider;

public class MyIdClass : AbstractIdUser {
    public static readonly IdProvider idProvider = new();
    
    public MyIdClass() : base(idProvider, false) { }
}