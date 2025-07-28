import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-refuse-product',
  templateUrl: './refuse-product.component.html',
  styleUrls: ['./refuse-product.component.css']
})
export class RefuseProductComponent implements OnInit {
  productId?: number;

   constructor(private productsService:ProductsService ,
      private activatedRoute:ActivatedRoute,
      private router:Router){}
   
     ngOnInit(): void {
       this.activatedRoute.paramMap.subscribe({
         next:(map)=> {
           this.productId=+map.get('id')!;
      this.productsService.approve(this.productId,"refused").subscribe({
        next:()=> {
          console.log("Accept product successfully");
          this.router.navigateByUrl("/admin");
        },
        error:(error)=>{
          console.error('Calling API failed',error);
        },
      })
          },
    error:(error)=> {
      console.error('This service was not found',error);
    },
  })
     }
}
