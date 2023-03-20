namespace Customer.Helpers.Services { }

public class BaseService<T> where T : class
{
    private string _apiName;
    private HttpClient client;

    ~BaseService()
    {
        client.Dispose();
    }

    public BaseService(string baseUrl, string apiName)
    {
        _apiName = apiName;

        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    public virtual async Task<bool> Create(T entity)
    {
        var response = await client.PostAsJsonAsync(_apiName, entity);
        return response.IsSuccessStatusCode;
    }

    public virtual async Task<bool> Delete(int id)
    {
        var response = await client.DeleteAsync(_apiName + id);
        return response.IsSuccessStatusCode;
    }

    public virtual async Task<T> Get(int id)
    {
        T entity = null;

        var response = await client.GetAsync(_apiName + id);

        if (response.IsSuccessStatusCode)
            entity = await response.Content.ReadAsAsync<T>();

        return entity;
    }

    public virtual async Task<T> Get(Guid id)
    {
        T entity = null;

        var response = await client.GetAsync(_apiName + id);

        if (response.IsSuccessStatusCode)
            entity = await response.Content.ReadAsAsync<T>();

        return entity;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        var entities = new List<T>();

        var response = await client.GetAsync(_apiName + "list");

        if (response.IsSuccessStatusCode)
            entities = await response.Content.ReadAsAsync<List<T>>();

        return entities;
    }

    public virtual async Task<bool> Update(T entity)
    {
        var response = await client.PutAsJsonAsync(_apiName, entity);
        return response.IsSuccessStatusCode;
    }

}
