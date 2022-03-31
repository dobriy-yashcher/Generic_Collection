namespace Generic_Collection
{
    public class LocalFileLogger<T> : ILogger
    {
        string path;

        public LocalFileLogger(string path)
        {
            this.path = path;
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(path, $"[Info]: [{typeof(T).Name}] : {message} \n");
        }
        public void LogWarning(string message)
        {
            File.AppendAllText(path, $"[Warning] : [{typeof(T).Name}] : {message} \n");
        }
        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(path, $"[Error] : [{typeof(T).Name}] : {message}. {ex.Message} \n");
        }
    }
}
