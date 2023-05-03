namespace pika.api.metadatos.mock
{
    public class ServicioMock : IServicioMock
    {
        List<EntidadMock> entidadMock = new List<EntidadMock>();

        public List<EntidadMock> LaLista()
        {
            if(entidadMock.Count == 0)
            {
                entidadMock = Mocker.EntidadesMock();
            }

            return entidadMock;
        }
    }
}
