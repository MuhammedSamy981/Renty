import { AfterContentInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';
import { ProductDto } from 'src/app/types/product/ProductDto';

@Component({
  selector: 'app-products-supervision',
  templateUrl: './products-supervision.component.html',
  styleUrls: ['./products-supervision.component.css']
})
export class ProductsSupervisionComponent implements OnInit,AfterContentInit{
  products?: ProductDto[]; 

  
   currentProductsPage:number = 1;
 sizeOfProductsPage:number = 10;

  paginatedProducts?: ProductDto[];


  constructor(
     private productsService:ProductsService,
     private router: Router
    ){}

        ngAfterContentInit(): void {
      sessionStorage.setItem("productName", "undefined");
    }

  ngOnInit(): void {
        if (sessionStorage.getItem("productName") == null
            || sessionStorage.getItem("productName") == "undefined") 
            {
          this.productsService.getAll().subscribe({
            next: (products) => {
              this.products = products;
              console.log(this.products);
            },
            error: (error) => {
              console.error('Calling API failed', error);
            },
          });
        }
        else {
          this.productsService.getAllByName(sessionStorage.getItem("productName")?.toString()!).subscribe(
            {
              next: (products) => {
                this.products = products;
                console.log(this.products);
              },
              error: (error) => {
                console.error('Calling API failed', error);
              },
            });
        }

  }

  search(product:string): void 
  {
    if(!product){
    product= " ";}
   console.log(product);
   this.router.navigateByUrl("/product/search/" + "undefined" + "/" + "undefined" + "/" + product+"/"+"admin");
   
  }

  GetProductsData(paginatedData: any[]) {
    this.paginatedProducts = paginatedData;
    console.log(this.paginatedProducts);
  }


}
