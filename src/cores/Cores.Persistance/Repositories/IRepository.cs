using Cores.Persistance.Entities;
using System.Linq.Expressions;

namespace Cores.Persistance.Repositories;

public interface IRepository<TEntity, TId> where TEntity: Entity<TId>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, bool include = true, bool enableTracking = true);
    //enable tracking sorguların daha hızlı cevap vermesini ssağlar. Büyük verilerde iki kata kadar performans gösterir.
    // include true ise eager loading kullanacağız. false ise lazy.
    //peggination: bir sayfada 20-30 tane veri göstermek. Veri parça parça çekilir. Herkes milyonlarca veri çekseydi db ulaşılamaz olurdu.
    TEntity? Get(Expression<Func<TEntity, bool>> filter, bool include = true, bool enableTracking = true);
    bool Any(Expression<Func<TEntity, bool>> filter, bool enableTracking = true);
}
