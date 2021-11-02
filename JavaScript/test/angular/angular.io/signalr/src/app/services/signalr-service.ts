import { Injectable } from '@angular/core';
import { EventEmitter } from 'events';
import * as signalR from '@microsoft/signalr';

@Injectable({ providedIn: 'root' })
export class SignalRService extends EventEmitter {
  private _connection: signalR.HubConnection;
  private _connectedEventName = 'connected';
  private _reconnectedEventName = 'reconnected';
  private _receivedEventName = 'received';
  private _errorEventName = 'error';

  /* private _signalRHubUrl = 'http://localhost:49987';
  private _chatEndpoint = '/chatHub';
  private _methodName = 'ReceiveMessage'; */

  private _signalRHubUrl = 'https://notificationhub-dit.nonprod.customercare.vip.nordstrom.com';
  private _chatEndpoint = '/hubs/delta';
  private _methodName = 'SendDelta';

  constructor() {
    super();

    this._connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Trace)
      .withUrl(this._signalRHubUrl + this._chatEndpoint, {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .build();

    this._connection.onclose(error => {
      console.log(error);
      this.start();
    });
    
    this._connection.onreconnecting(error => {
      console.log(`Connection lost due to error "${error}". Reconnecting.`);
    });

    this._connection.onreconnected(() => {
      this.emit(this._reconnectedEventName);
    });

    this._connection.on(this._methodName, (user, message) => {
      this.emit(this._receivedEventName, { user, message });
    });
  }

  start() {
    this._connection.start()
    .then(() => {
      if (this._connection.state === signalR.HubConnectionState.Connected) {
        this.emit(this._connectedEventName);
      }
    })
    .catch((error) => {
      console.log(error);
      this.emit(this._errorEventName, error);
      setTimeout(() => this.start(), 5000);
    });
  }
}
