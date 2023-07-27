import { Injectable } from '@angular/core';
import { Product } from './product';
import { LoggerService } from './logger.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {


  constructor(private loggerService: LoggerService)
  { 
   
      this.loggerService.log("Product Service Constructed");
  }

  public getProducts() {

    this.loggerService.log("getProducts called");

    let products: Product[];

    products = [
        new Product(1, 'Memory Card', 500),
        new Product(2, 'Pen Drive', 750),
        new Product(3, 'Power Bank', 100)
    ]

    this.loggerService.log(products);

    return products;
}
}
