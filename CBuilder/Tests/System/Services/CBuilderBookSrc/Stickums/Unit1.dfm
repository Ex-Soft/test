object Stickum: TStickum
  OldCreateOrder = False
  DisplayName = 'Stickum'
  ServiceStartName = '.\LocalSystem'
  OnExecute = ServiceExecute
  OnStart = ServiceStart
  OnStop = ServiceStop
  Left = 220
  Top = 175
  Height = 640
  Width = 870
  object ServerSocket1: TServerSocket
    Active = False
    Port = 711
    ServerType = stNonBlocking
    OnClientRead = ServerSocket1ClientRead
    Left = 144
    Top = 112
  end
end
