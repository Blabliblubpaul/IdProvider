namespace IdProvider;

public class IdProvider {
    private uint nextId;
    private int poolSize;
    private int idRecycleBufferSize;
    private readonly Stack<uint> idPool;

    public IdProvider(int poolSize = 100, int idRecycleBufferSize = 10) {
        this.poolSize = poolSize;
        this.idRecycleBufferSize = idRecycleBufferSize;
        idPool = new Stack<uint>(poolSize + idRecycleBufferSize);
        
        FillIdPool();
    }

    /// <summary>
    /// Retrieves the next id from the pool.
    /// </summary>
    /// <returns></returns>
    public uint NextId() {
        if (idPool.Count > 0) {
            return idPool.Pop();
        }
        
        FillIdPool();
        return idPool.Pop();
    }

    /// <summary>
    /// <para>Frees an id to be reused.</para>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="validateId"></param>
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
    /// <para>Adds the next poolSize ids to the pool.</para>
    /// <para>Generally, this method should not be called manually.</para>
    /// </summary>
    public void FillIdPool() {
        idPool.EnsureCapacity(idPool.Count + poolSize + idRecycleBufferSize);
        
        for (int i = poolSize - 1; i >= 0; i--) {
            idPool.Push((uint)(nextId + i));
        }

        nextId += (uint)poolSize;
    }
}