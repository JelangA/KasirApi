namespace cashierAPI.src.util
{
    public class Respons<T>
    {
        public Respons(List<T> data)
        {
            this.data = data;
        }

        public List<T>? data { get; set; }
        public int total => data?.Count ?? 0;
    }
}


