import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/products.service';
import { UsersService } from 'src/app/services/users.service';
import { ProductDto } from 'src/app/types/product/ProductDto';

@Component({
  selector: 'app-products-management',
  templateUrl: './products-management.component.html',
  styleUrls: ['./products-management.component.css']
})
export class ProductsManagementComponent implements OnInit
{
 products?:ProductDto[];
   currentPage:number = 1;
 sizeOfPage:number = 10;
  paginatedProducts?: ProductDto[];
 constructor(private usersService:UsersService,
   private productsService:ProductsService){}

 ngOnInit(): void {
const currentUserId=this.usersService.getUserId();
      this.productsService.getAllByUserId(currentUserId).subscribe({
        next:(products)=> {
          this.products=products;
          console.log(this.products);
          
        },
        error:(err)=>{
          console.error('Calling API failed',err);
        },
      })





 }
 
        GetData(paginatedData: any[]) {
    this.paginatedProducts = paginatedData;
    console.log(this.paginatedProducts);
  }
}

