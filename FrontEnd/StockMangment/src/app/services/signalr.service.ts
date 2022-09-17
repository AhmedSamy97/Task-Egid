import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { Observable, Subject } from 'rxjs';
import { Stock } from './Stock';
@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public hubConnection: signalR.HubConnection | undefined;
  constructor() { }
  changedStock$: Subject<Stock[]> = new Subject<Stock[]>();

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5265/StockPrice")
      .build();
    this.hubConnection.start()
      .then(() => console.log("connection started !"))
      .catch(err => console.log("Error while starting connection" + err));
  }
  public get StockChangedObservable(): Observable<Stock[]> {
    return this.changedStock$.asObservable();
  }
  public GetNewStockPrice() {
    this.hubConnection?.on("ReceiveMessage", data => {
      this.changedStock$.next(data)
    });
  }
}
