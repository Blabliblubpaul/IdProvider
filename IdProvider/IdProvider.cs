namespace IdProvider;

public class IdProvider {
    private uint idPtr;
    private int poolSize;
    private int idRecycleBufferSize;
    private Stack<uint> idPool;

    public IdProvider(int poolSize = 100, int idRecycleBufferSize = 10) {
        idPtr = 0;
        this.poolSize = poolSize;
        this.idRecycleBufferSize = idRecycleBufferSize;
        idPool = new Stack<uint>(poolSize + idRecycleBufferSize);
        
        FillIdPool();
    }

    public uint NewId() {
        if (idPool.Count > 0) {
            return idPool.Pop();
        }
        
        FillIdPool();
        return idPool.Pop();
    }

    public void FreeId(uint id, bool validateId = false) {
        if (validateId) {
            if (!idPool.Contains(id)) {
                idPool.Push(id);
            }
        }
        else {
            idPool.Push(id);
        }
    }

    /// <summary>
    /// Adds the next poolSize ids to the pool.
    /// </summary>
    public void FillIdPool() {
        idPool.EnsureCapacity(idPool.Count + poolSize + idRecycleBufferSize);

        for (int i = 0; i < poolSize; i++) {
            idPool.Push(idPtr++);
        }
    }

    /// <summary>
    /// Adds ids to the pool until poolSize is reached.
    /// </summary>
    public void FillIdPoolToCapacity() {
        while (idPool.Count < poolSize) {
            idPool.Push(idPtr++);
        }
    }
}