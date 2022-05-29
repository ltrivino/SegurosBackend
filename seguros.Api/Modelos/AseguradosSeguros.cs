namespace Seguros.Api.Modelos
{
    public class AseguradosSeguros
    {
        public int id { get; set; }
        public Asegurados asegurados { get; set; }
        public int aseguradosId { get; set; }
        public Seguros seguros { get; set; }
        public int segurosId { get; set; }
}
}
