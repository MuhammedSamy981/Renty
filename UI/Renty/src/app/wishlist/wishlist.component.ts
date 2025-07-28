import { Component, OnInit } from '@angular/core';
import { WishlistDto } from '../types/wishlist/WishlistDto';
import { WishlistsService } from '../services/wishlists.service';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { WishlisUpdateOrCreateDto } from '../types/wishlist/WishlisUpdateOrCreateDto';
import { ProductDto } from '../types/product/ProductDto';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {
  wishlistLoading:boolean=false;
 wishlist?:WishlistDto;
  currentUserId?: string;

  currentPage:number = 1;
 sizeOfPage:number = 10;
  paginatedProducts?: ProductDto[];

  constructor(private wishlistsService:WishlistsService,public usersService:UsersService,
   private router:Router){}
   
  ngOnInit(): void {
 this.currentUserId=this.usersService.getUserId();
            this.wishlistsService.getById(this.currentUserId).subscribe({
      next:(wishlist)=> {
        this.wishlistLoading=true;
        this.wishlist=wishlist;
        console.log(this.wishlist);
      },
      error:(error)=>{
        console.error('Calling API failed',error);
      },
    })


  }

  removeBookmark(productId:number,product_card:HTMLElement):void
  {
    const wishlist:WishlisUpdateOrCreateDto=
    {
       id:this.currentUserId!,
       productIds:[productId]
    };

    this.wishlistsService.removeFromList(wishlist).subscribe(
      {
        next: () => {
         alert("Deleted successfully")
        },
        error: () => {
          alert('Deleted failed');
        }
      }
    )
  }

          GetData(paginatedData: any[]) {
    this.paginatedProducts = paginatedData;
    console.log(this.paginatedProducts);
  }
}
