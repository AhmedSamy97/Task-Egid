import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { SignalrService } from '../services/signalr.service';
import { Stock } from '../services/Stock';
import { StockService } from '../services/stock.service';

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  styleUrls: ['./market.component.css']
})
export class MarketComponent implements OnInit, OnDestroy {
  AllStocks: Stock[] = [];
  changedStock$: any;
  constructor(private signalRService: SignalrService, private stockService: StockService) { }
  ngOnDestroy(): void {
    (<Subscription>this.changedStock$).unsubscribe();
  }


  ngOnInit(): void {
    this.signalRService.GetNewStockPrice();
    this.stockService.getAllStock().subscribe(d => {
      this.AllStocks = d;
      //console.log(this.AllStocks)
    })

    //get the new changes
    this.changedStock$ = this.signalRService.StockChangedObservable.subscribe((stocks: Stock[]) => {
      this.AllStocks = stocks;
    })
  }

  ChangePrice(id: number, newprice: any) {
    var stock: Stock = { id, price: newprice, name: '' };
    this.stockService.editStock(stock).subscribe(() => {
      console.log("Stock Updated");

    })

  }

}
