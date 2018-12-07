import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { OrderService } from '../order.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  orderData:any = [];
  currentOrder:any = {};
  orderOutput:any = {};
  @Input() orderEntry: any;

  constructor(public rest:OrderService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getOrders();
    this.clearOrderEntry();
  }

  getOrders() {
    this.orderData = [];
    this.rest.getOrders().subscribe((data: {}) => {
      console.log(data);
      this.orderData = data;      
    });
  }

  addOrder(originalOrder) {
    console.log(originalOrder);
    this.rest.addOrder(originalOrder).subscribe((result) => {
      this.orderOutput = result;
      console.log(this.orderOutput);
      this.getOrders();
    }, (err) => {
      console.log(err);
    });
  }

  length(obj) {
    return Object.keys(obj).length;
  }

  private clearOrderEntry = function() {
    this.orderEntry = {
      id: undefined,
      originalOrder: '',
      orderFinal: ''
    };

  };

}
