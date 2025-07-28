import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';
import { UsersService } from 'src/app/services/users.service';
import { ProductDetailDto } from 'src/app/types/product/ProductDetailDto';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  currentUserId?:string;
  product?:ProductDetailDto;
  ratingId?:number;
 deletingStatus:boolean=false;
 loginStatus:boolean=false;

 constructor(private productsService:ProductsService,
  private activatedRoute:ActivatedRoute,public usersService:UsersService)
  {}
  
 ngOnInit(): void {
   this.activatedRoute.paramMap.subscribe({
     next:(map)=> {
      this.usersService.isLoggedIn().subscribe(loginStatus=>{
        this.loginStatus=loginStatus;
if(loginStatus==true){
 this.currentUserId=this.usersService.getUserId();}
 else
 {
  this.currentUserId="undefined";
 }})

       const productId=+map.get("id")!;
       this.productsService.getById(productId,this.currentUserId!).subscribe(
         {
           next:(product)=> {
             this.product=product;
             for(let rating of product.ratings!)
             {
               if(rating.userId==this.currentUserId)
               {
                 this.ratingId=rating.id;
               }
             }
           },
           error:(error)=> {
             console.error('Calling API failed',error);
           },
         })
     },
     error:(error)=> {
       console.error('This service is not found',error);
     }, 
   })
 }

 getUpdatedRatingId(ratingId:number)
  {
    this.ratingId=ratingId;
  }


  ShowPhoneNumber(phoneNumber: string,showLink:HTMLElement):void {
  if(this.loginStatus==true)
    {
     showLink.textContent=phoneNumber;
    }
  else
  {
    alert("You must log in first");
  }


}
 
}

