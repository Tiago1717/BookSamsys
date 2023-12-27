namespace MessageHelper{
    public class MessangingHelper<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Obj { get; set; }
        public string Status { get; internal set; }
        public object Data { get; internal set; }
    }
}