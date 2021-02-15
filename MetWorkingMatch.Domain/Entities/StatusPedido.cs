namespace MetWorkingMatch.Domain.Entities
{
    public class StatusPedido
    {
        public int Id { get; set; }
        public string DescricaoStatus { get; set; }

        public StatusPedido()
        {   
        }
        public StatusPedido(int Id)
        {
            this.Id = Id;
        }
    }
}
