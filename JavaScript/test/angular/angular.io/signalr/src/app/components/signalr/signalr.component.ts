import { Component, OnInit } from '@angular/core';

import { SignalRService } from '../../services/signalr-service';

@Component({
  selector: 'app-signalr',
  templateUrl: './signalr.component.html',
  styleUrls: ['./signalr.component.css']
})
export class SignalrComponent implements OnInit {
  messagesList = [] as Array<any>;

  constructor(private _signalRService: SignalRService) {
    _signalRService.on('connected', this.onSignalRServiceConnected);
    _signalRService.on('reconnected', this.onSignalRServiceConnected);
    _signalRService.on('received', this.onSignalRServiceReceived);
    _signalRService.on('error', this.onSignalRServiceError);
  }

  ngOnInit(): void {
    this._signalRService.start();
  }

  onSignalRServiceConnected = () => {
    console.log('connected');
  }

  onSignalRServiceError = (error: any) => {
    console.log(error);
  }

  onSignalRServiceReceived = (data: any) => {
    console.log(data);
    this.messagesList.push(data);
  }

  onSendClick() {
    
  }
}
