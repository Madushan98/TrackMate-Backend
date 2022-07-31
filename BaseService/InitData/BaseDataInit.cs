using Microsoft.EntityFrameworkCore;

namespace Base.InitData;

public abstract class BaseDataInit<T> where T : class
{
    public virtual void Init(ModelBuilder modelBuilder)
    {
        var trackEntities = Data();
        if (trackEntities == null) return;
       

        modelBuilder.Entity<T>().HasData(trackEntities);
    }
    public abstract List<T> Data();
}