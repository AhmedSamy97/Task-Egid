import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from './../services/Order';
import { OrderView } from './OrderView';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = "http://localhost:5265/api/order"
  constructor(private http: HttpClient) { }

  getOrders() {
    return this.http.get<OrderView[]>(this.apiUrl);
  }
  addOrder(order: Order) {
    return this.http.post(this.apiUrl, order);
  }
}
