import { Component, OnInit } from '@angular/core';
import { SignalrService } from './services/signalr.service';
import { StockService } from './services/stock.service';
import { Stock } from './services/Stock';
import { BehaviorSubject, Subject } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'StockMangment';

  constructor(private signalRService: SignalrService) {
    this.signalRService.startConnection();

  }




}
