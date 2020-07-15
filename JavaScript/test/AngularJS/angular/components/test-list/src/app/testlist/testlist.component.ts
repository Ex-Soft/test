import { Component, OnInit, Input } from '@angular/core';
import { OrderApiResponse } from '../types/order-api-response.type';
import { OrderService } from '../services/order.service';
import { Item } from '../models/Item';
import { IOrder } from '../models/IOrder';
import { Order } from '../models/Order';

@Component({
  selector: 'app-testlist',
  templateUrl: './testlist.component.html',
  styleUrls: ['./testlist.component.css']
})
export class TestlistComponent implements OnInit {
  order: IOrder;

  constructor(private orderService: OrderService) { }

  @Input() url: string;

  ngOnInit(): void {
    this.getOrder(this.url);
  }

  getOrder(url: string): void {
    this.orderService.getData(url)
      .subscribe((order: OrderApiResponse) => {
        this.order = new Order(order.id, new Date(order.date), order.items.map((item) => new Item(item.id, item.name, item.price, item.count)));
      });
  }
}
