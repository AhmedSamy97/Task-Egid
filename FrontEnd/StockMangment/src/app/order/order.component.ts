import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ModalDismissReasons, NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { StockService } from './../services/stock.service';
import { Stock } from './../services/Stock';
import { OrderService } from './../services/order.service';
import { OrderView } from './../services/OrderView';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  modalReference: NgbModalRef;
  closeResult: string = "";
  modalOptions: NgbModalOptions;
  users: string[] = ["Broker", "Client"];
  AllStocks: Stock[] = [];
  AllOrders: OrderView[] = [];
  orderModel: any;
  //selectedOption: any;

  constructor(private modalService: NgbModal, private stockService: StockService, private orderService: OrderService) {
    this.modalOptions = {
      backdrop: 'static',
      backdropClass: 'customBackdrop'
    }
  }
  open(content: any) {
    this.modalReference = this.modalService.open(content, this.modalOptions);
    this.modalReference.result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  private getDismissReason(reason: any): string {
    this.orderModel = {};
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  ngOnInit(): void {
    this.GetOrders();
    this.GetStocks();
  }
  GetStocks() {
    this.stockService.getAllStock().subscribe(stocks => {
      this.AllStocks = stocks;
    })
  }
  GetOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.AllOrders = orders;
    })
  }
  CalculateStockOrder(id: string) {
    this.stockService.getStockData(id).subscribe((d: Stock) => {
      let Price = d.price;
      let Qty = this.getRandomNumber(10, 1);
      let User = this.users[this.getRandomNumber(1, 0)];
      let Total = Price * Qty;
      let Commission = this.calculateCommission(User, Total);
      this.orderModel = { StockId: id, Price, Qty, User, Total, Commission };
    })
  }
  private getRandomNumber(max: number, min: number) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }
  calculateCommission(userType: string, total: number) {
    if (userType == "Broker") {
      return total * (1 / 100);
    }
    return total * (2 / 100);
  }
  PlaceOrder() {
    if (this.orderModel != null || this.orderModel != undefined) {
      this.orderModel = { ...this.orderModel, Quantity: this.orderModel.Qty };
      this.orderService.addOrder(this.orderModel).subscribe(() => {
        this.modalReference.close();
        this.getDismissReason("Order placed!");
        this.GetOrders();
      })
    }
  }
}


