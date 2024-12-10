namespace IdProvider;

public class AbstractIdUser : IDisposable {
    public IdProvider IdProvider { get; }
    public uint Id { get; }
    public bool ValidateIdOnFree { get; }
    
    private bool disposed;

    public AbstractIdUser(IdProvider idProvider, bool validateIdOnFree) {
        IdProvider = idProvider;
        ValidateIdOnFree = validateIdOnFree;
        
        Id = idProvider.NextId();
    }

    ~AbstractIdUser() {
        Dispose(false);
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing) {
        if (!disposed) {
            if (ValidateIdOnFree) {
                IdProvider.FreeId(Id, true);
            }
            else {
                IdProvider.FreeId(Id);
            }

            disposed = true;
        }
    }
}