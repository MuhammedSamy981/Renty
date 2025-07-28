import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';
import { UsersService } from 'src/app/services/users.service';
import { ProductDetailDto } from 'src/app/types/product/ProductDetailDto';

@Component({
  selector: 'app-remove-product',
  templateUrl: './remove-product.component.html',
  styleUrls: ['./remove-product.component.css']
})
export class RemoveProductComponent {
  productId?:number;
  product?:ProductDetailDto;
  currentUserId?: string;
  constructor(private productsService:ProductsService,
   private activatedRoute:ActivatedRoute,
   private router:Router,private usersService:UsersService){}

  ngOnInit(): void {
     this.currentUserId=this.usersService.getUserId();
    this.activatedRoute.paramMap.subscribe({
      next:(map)=> {
        this.productId=+map.get('id')!;
        this.productsService.getById(this.productId,this.currentUserId!).subscribe({
          next:(product)=> {
            this.product=product;
          },
          error:(error)=> {
            console.error('Calling API failed',error);
          },
        })
      },
      error:(error)=> {
        console.error('This service was not found',error);
      },
    })
  }

  DeleteProduct(e:Event):void
  {
    e.preventDefault();
    this.productsService.delete(this.productId!).subscribe({
      next:()=> {
        this.router.navigateByUrl("/product/management");
      },
      error:(error)=> {
        console.error('Calling API failed',error);     
      },
    })
  }
}
