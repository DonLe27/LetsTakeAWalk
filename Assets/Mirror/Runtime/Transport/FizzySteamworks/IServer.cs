namespace Mirror.FizzySteam
{
  public interface IServer
  {
    void ReceiveData();
    void Send(int connectionId, byte[] data, int channelId);
    bool Disconnect(int connectionId);
    void FlushData();
    string ServerGetClientAddress(int connectionId);
    void Shutdown();
  }
}