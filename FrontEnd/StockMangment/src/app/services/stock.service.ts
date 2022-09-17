import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Stock } from './Stock';

@Injectable({
  providedIn: 'root'
})
export class StockService {
  private apiUrl = "http://localhost:5265/api/stock"
  constructor(private http: HttpClient) { }

  public getAllStock() {
    return this.http.get<Stock[]>(this.apiUrl);
  }
  public editStock(stock: Stock) {
    return this.http.post(this.apiUrl + "/edit", stock);
  }
  public getStockData(id: string) {
    return this.http.get<Stock>(this.apiUrl + "/" + id);
  }
}
